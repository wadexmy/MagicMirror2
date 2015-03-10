using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Threading;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Impls;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Inter;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.DataTransferObjects.Reader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Impls.RFIDReader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Inter.Reader;
using Com.IotLead.Hardware.Device.PcX86.Domain.DataTransferObjects;
using MagicMirror.Models;
using MagicMirror.Util;
using Newtonsoft.Json;


namespace MagicMirror.Views
{
    /// <summary>
    /// ProductSlideGallery.xaml 的交互逻辑
    /// </summary>
    public partial class ProductSlideGallery : UserControl
    {
        /// <summary>
        /// 当前屏幕显示的产品
        /// </summary>
        private Dictionary<int, ProductBiz> HomeProductDic;
        
        private bool isCompleted = false;

        #region ===感应输入===

        private IRfidReaderControllerImpl readerControllerImpler = null;

        private IRfidReaderController readerController = null;

        public string readerConfigPath = Global.readerConfigPath;

        #endregion

        public ProductSlideGallery()
        {
            InitializeComponent();

            HomeProductDic = new Dictionary<int, ProductBiz>();

            Grid.SetRowSpan(Global.MainFrame,2);
            Global.MenuButtonBar.btnTrying.Visibility = Visibility.Collapsed;
            Global.MenuButtonBar.btnBuy.Visibility = Visibility.Collapsed;
            Global.MenuButtonBar.btnClose.Visibility = Visibility.Collapsed;

            Thread thread = new Thread(() =>
            {
                IList<ProductBiz> homeProducts = Global.dataservice.GetFirstPageProducts(Global.HomeAnimatePictureCount);
                PrepareProducts3DView(homeProducts);
            });
            thread.Start();
            try
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(Global.BackgroundImage));
                this.Background = imgBrush;
            }
            catch (Exception)
            {
                this.Background = TryFindResource("cloudBackground") as ImageBrush;
            }
            this.Loaded += new RoutedEventHandler(ProductSlideGallery_Loaded);
        }

        private void ProductSlideGallery_Loaded(object sender, RoutedEventArgs e)
        {
            //只有试衣间才支持加载初始屏时启动感应输入
            if (Global.UserInterface == UserInterface.ShoppingAssistant)
                return;
            if (!System.IO.File.Exists(readerConfigPath)) throw new Exception("找不到读写器配置文件！");
            var file = System.IO.File.ReadAllText(readerConfigPath);
            var localReaderSettings = JsonConvert.DeserializeObject<ReaderWithAntennaDto>(file);

            if (localReaderSettings == null) throw new Exception("请先维护设备！");
            if (localReaderSettings.Reader.Model == "R500")
            {
                readerControllerImpler = new ImpinjR500ReaderControllerImpl();
                readerControllerImpler.ReaderTagsHandle += readerControllerImpler_ReaderTagsHandle;
                try
                {
                    //_readerControllerImpler.StopAndDisconnect();
                    readerControllerImpler.ConnectAndStart();
                }
                catch (Exception ex)
                {
                    //WPFMessageBox.Show("连接设备失败！" + ex.Message);
                }
            }
            else
            {
                var reader = new Reader()
                {
                    Code = localReaderSettings.Reader.Code,
                    IpAddress = localReaderSettings.Reader.Ip,
                    Port = localReaderSettings.Reader.Port,
                    MemoryBank = 0,
                    ReaderAntennas = localReaderSettings.ReaderAntennaList.Select(v => new ReaderAntenna
                    {
                        Enable = true,
                        MaxRxSensitivity = v.MaxRxSensitivity,
                        MaxTransmitPower = v.MaxTransmitPower,
                        PortNumber = (ushort)v.AntennaIndex,
                        RxSensitivityInDbm = v.RxSensitivityInDbm,
                        TxPowerInDbm = v.TxPowerInDbm
                    }).ToList()
                };
                readerController = new MotorolaRfidReaderControllerImpl(reader);
                readerController.ReaderTagsHandle += readerControllerImpler_ReaderTagsHandle;
                try
                {
                    readerController.ConnectAndStart();
                }
                catch (Exception ex)
                {
                    //WPFMessageBox.Show("连接设备失败！" + ex.Message);
                }
            }
        }

        List<string> epcs = new List<string>();

        private void readerControllerImpler_ReaderTagsHandle(object sender, RfidReaderEventArgs e)
        {
            List<ProductBiz> epcProducts = new List<ProductBiz>();
            
            foreach (var epc in e.EpcDtos)
            {
                epcs.Add(epc.EpcCode);
            }

            IList<SkuInfoBiz> SkuInfos = Global.dataservice.GetSkusByEpcList(epcs);
            if (SkuInfos == null) return;
            for (int i = 0; i < SkuInfos.Count; i++)
            {
                ProductBiz product = ProductBiz.GetProductBySkuInfo(SkuInfos[i]);
                product.ImagePath = Global.ProductDemoImages[i];
                epcProducts.Add(product);
            }
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
            {
                if (Global.UserInterface == UserInterface.FittingRoom)
                {
                    Global.MainFrame.Navigate(new Uri("/Views/ProductTryingOnControl.xaml", UriKind.Relative), epcProducts);
                }
                else
                {
                    Global.MainFrame.Navigate(new Uri("/Views/ProductDetailControl.xaml", UriKind.Relative), epcProducts);
                }
                Global.MainFrame.Navigated += MainFrame_Navigated;
            });
        }

        #region ===商品初始化加载===

        private void PrepareProducts3DView(IList<ProductBiz> products)
        {
            if (products == null)  return;
            try
            {
                //设置空间上的位置偏移
                double[] xPositons = GetXPositons(Global.HomeAnimatePictureCount);
                double[] yPositons = GetYPositons(Global.HomeAnimatePictureCount);
                double[] zPositons = GetZPositons(Global.HomeAnimatePictureCount);

                //目前使用示例图片
                if (Global.ProductDemoImages.Count < Global.HomeAnimatePictureCount)
                {
                    MessageBox.Show("至少在目录\"Resources\"/Products中放入" + Global.HomeAnimatePictureCount + "张图片哦！");
                    Window.GetWindow(this).Close();
                    return;
                }

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    for (int index = 0; index < Global.HomeAnimatePictureCount; index++)
                    {
                        products[index].ImagePath = Global.ProductDemoImages[index];

                        ModelVisual3D modelVisual3D = new ModelVisual3D();
                        GeometryModel3D geometryModel3D = new GeometryModel3D();
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(Global.ProductDemoImages[index]);
                        double ratio = bmp.Width * 1.0 / bmp.Height;

                        //设置材质
                        if (index % 2 == 0)
                        {
                            geometryModel3D.Material = Image3DViewUtil.PrepareMaterial(Global.ProductDemoImages[index], true);
                            geometryModel3D.BackMaterial = Image3DViewUtil.PrepareMaterial(Global.ProductDemoImages[index], false);
                        }
                        else
                        {
                            geometryModel3D.Material = Image3DViewUtil.PrepareMaterial(Global.ProductDemoImages[index], false);
                            geometryModel3D.BackMaterial = Image3DViewUtil.PrepareMaterial(Global.ProductDemoImages[index], true);
                        }
                        //设置空间形状
                        geometryModel3D.Geometry = Image3DViewUtil.PrepareGeometry(Global.ProductDemoImages[index], xPositons[index], yPositons[index], zPositons[index], ratio);
                        //设置局部旋转效果
                        geometryModel3D.Transform = SetRotateTransform3D(index);
                        modelVisual3D.Content = geometryModel3D;
                        //将产品添加到三维场景中
                        mainScene.Children.Add(modelVisual3D);

                        HomeProductDic.Add(index, products[index]);
                    }

                    //启动动画
                    StartAnimation();
                    isCompleted = true;
                });
            }
            catch{}
        }

        /// <summary>
        /// 设置局部旋转效果
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private RotateTransform3D SetRotateTransform3D(int index)
        {
            RotateTransform3D rotateTrans3D = new RotateTransform3D();
            AxisAngleRotation3D axisAngleRotation = new AxisAngleRotation3D();
            string AxisAngleRot3DName = "axisAngleRotation" + index;
            if (this.FindName(AxisAngleRot3DName) != null)
                this.UnregisterName(AxisAngleRot3DName);
            this.RegisterName(AxisAngleRot3DName, axisAngleRotation);
            int rotateOrentation = (new Random()).Next(3);
            switch ((new Random()).Next(3))
            {
                case 1:
                    axisAngleRotation.Axis = new Vector3D(0, 0, 1);
                    break;
                case 2:
                    axisAngleRotation.Axis = new Vector3D(0, 1, 0);
                    break;
                default:
                    axisAngleRotation.Axis = new Vector3D(0, 0, 1);
                    break;
            }
            axisAngleRotation.Angle = 0;
            rotateTrans3D.Rotation = axisAngleRotation;
            return rotateTrans3D;
        }

        /// <summary>
        /// 启动动画
        /// </summary>
        private void StartAnimation()
        {
            busyGrid.Visibility = Visibility.Collapsed;
            viewLoading.Visibility = Visibility.Collapsed;

            Storyboard loadStoryboard = new Storyboard();
            DoubleAnimation angleRotationAnimation = new DoubleAnimation();
            angleRotationAnimation.From = 0;
            angleRotationAnimation.To = 360;
            angleRotationAnimation.AutoReverse = false;
            angleRotationAnimation.RepeatBehavior = RepeatBehavior.Forever;
            angleRotationAnimation.Duration = new Duration(TimeSpan.FromSeconds(Global.AnimateCircleDuration));
            Storyboard.SetTargetName(angleRotationAnimation, "angleRotation");
            Storyboard.SetTargetProperty(angleRotationAnimation, new PropertyPath(AxisAngleRotation3D.AngleProperty));
            loadStoryboard.Children.Add(angleRotationAnimation);
            loadStoryboard.Begin(this);

            for (int index = 0; index < Global.HomeAnimatePictureCount; index++)
            {
                string AxisAngleRot3DName = "axisAngleRotation" + index;
                DoubleAnimation element = new DoubleAnimation();
                element.Duration = new Duration(TimeSpan.FromSeconds(60));
                element.From = -10.0;
                element.To = 10.0;
                element.AutoReverse = true;
                element.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTargetName(element, AxisAngleRot3DName);
                Storyboard.SetTargetProperty(element, new PropertyPath(AxisAngleRotation3D.AngleProperty));

                Storyboard rotateStoryboard = new Storyboard();
                rotateStoryboard.Children.Add(element);
                rotateStoryboard.Begin(this);
            }
        }

        #endregion

        #region ===空间位置偏移量设置===
        
        /// <summary>
        /// X轴方向偏移
        /// </summary>
        /// <param name="ScenePicturesCount"></param>
        /// <returns></returns>
        private double[] GetXPositons(int ScenePicturesCount)
        {
            double[] xPositons = new double[ScenePicturesCount];
            
            for (int i = 0; i < ScenePicturesCount; i++)
            {
                xPositons[i] = i <= ScenePicturesCount / 2 ? -i : i - ScenePicturesCount / 2.0;
                if (Global.UserInterface == UserInterface.ShoppingAssistant)//高大于宽时
                {
                    xPositons[i] = xPositons[i] / 2.0;
                }
            }
            xPositons = ShuffleUtil.Shuffle<double>(xPositons);
            return xPositons;
        }

        /// <summary>
        /// Y轴方向偏移
        /// </summary>
        /// <param name="ScenePicturesCount"></param>
        /// <returns></returns>
        private double[] GetYPositons(int ScenePicturesCount)
        {
            double[] yPositons = new double[ScenePicturesCount];
            
            for (int i = 0; i < ScenePicturesCount; i++)
            {
                yPositons[i] = i <= ScenePicturesCount / 2 ? -i : i - ScenePicturesCount / 2.0;
                if (Global.UserInterface == UserInterface.FittingRoom)//宽大于高时
                {
                    yPositons[i] = yPositons[i] / 2.0;
                }
                else {
                    yPositons[i] = yPositons[i] * 1.5;
                }
            }
            yPositons = ShuffleUtil.Shuffle<double>(yPositons);
            return yPositons;
        }


        /// <summary>
        /// Z轴方向偏移
        /// </summary>
        /// <param name="ScenePicturesCount"></param>
        /// <returns></returns>
        private double[] GetZPositons(int ScenePicturesCount)
        {
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate()
            {
                sceneTransform3d.OffsetZ = -10 - ScenePicturesCount * 0.5;
            });
           
            double[] zPositons = new double[ScenePicturesCount];

            for (int i = 0; i < ScenePicturesCount; i++)
            {
                zPositons[i] = i % 2 == 0 ? 0.5 * (i + 1) : -0.5 * (i + 1);
            }
            return zPositons;
        }

        #endregion

        #region ===选择===

        /// <summary>
        /// 采用命中测试得到三维场景中选中的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void viewport3D_MouseLeftButtonDown(object sender, MouseButtonEventArgs args)
        {
            Point mousePosition = args.GetPosition(viewport3D);
            PointHitTestParameters pointparams = new PointHitTestParameters(mousePosition);
            //测试 Viewport3D 中的结果
            VisualTreeHelper.HitTest(viewport3D, null, rawresult =>
            {
                RayHitTestResult rayResult = rawresult as RayHitTestResult;
                if (rayResult != null)
                {
                    RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;
                    if (rayMeshResult != null)
                    {
                        GeometryModel3D hitgeo = rayMeshResult.ModelHit as GeometryModel3D;
                        MaterialGroup priorMaterial = hitgeo.Material as MaterialGroup;
                        DiffuseMaterial difuseMaterial = priorMaterial.Children[0] as DiffuseMaterial;
                        if (difuseMaterial != null && difuseMaterial.Brush is ImageBrush)
                        {
                            ImageBrush imgBrush = difuseMaterial.Brush as ImageBrush;
                            try
                            {
                                string imagesource = imgBrush.ImageSource.ToString();
                                string imageName = System.IO.Path.GetFileName(imagesource);
                                int selIndex = 0;
                                for (int i = 0; i < Global.ProductDemoImages.Count; i++)
                                {
                                    if (System.IO.Path.GetFileName(Global.ProductDemoImages[i]) == imageName)
                                    {
                                        selIndex = i;
                                    }
                                }
                                ProductBiz selPruduct = HomeProductDic[selIndex];
                                if (selPruduct != null)
                                {
                                    Grid.SetRowSpan(Global.MainFrame, 1);
                                    if (Global.UserInterface == UserInterface.FittingRoom)
                                    {
                                        Global.MainFrame.Navigate(new Uri("/Views/ProductTryingOnControl.xaml", UriKind.Relative), selPruduct);
                                    }
                                    else {
                                        Global.MainFrame.Navigate(new Uri("/Views/ProductDetailControl.xaml", UriKind.Relative), selPruduct);
                                    }
                                    Global.MainFrame.Navigated += MainFrame_Navigated;
                                }
                            }
                            catch { }
                        }
                    }
                }
                return HitTestResultBehavior.Stop;
            }, pointparams);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData is ProductBiz)
            {
                //因为ProductTryingOnControl需要添加动画，所以要预先订阅TryingOnProducts改变事件
                Global.productViewModel.AddProduct(e.ExtraData as ProductBiz);
            }
            else if (e.ExtraData is List<ProductBiz>)
            {
                Global.productViewModel.AddProducts(e.ExtraData as List<ProductBiz>);
            }
            Global.MenuButtonBar.Visibility = Visibility.Visible;

            //界面切换后关闭感应输入
            if (readerControllerImpler != null)
            {
                readerControllerImpler.ReaderTagsHandle -= readerControllerImpler_ReaderTagsHandle;
                readerControllerImpler.StopAndDisconnect();
            }

            if (readerController != null)
            {
                readerController.ReaderTagsHandle -= readerControllerImpler_ReaderTagsHandle;
                readerController.StopAndDisconnect();
            }
            //导航结束后马上解除绑定事件
            Global.MainFrame.Navigated -= MainFrame_Navigated;
        }

        #endregion

        #region ===功能按钮菜单显示和隐藏===

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isCompleted) return;
            Storyboard menuShowStoryboard;
            if (Global.MenuButtonBar.Visibility == Visibility.Hidden)
            {
                Global.MenuButtonBar.Visibility = Visibility.Visible;
                menuShowStoryboard = App.Current.MainWindow.Resources["buttonMenuInStoryboard"] as Storyboard;
            }
            else
            {
                menuShowStoryboard = App.Current.MainWindow.Resources["buttonMenuOutStoryboard"] as Storyboard;
                menuShowStoryboard.Completed += (ss, ee) =>
                {
                    Global.MenuButtonBar.Visibility = Visibility.Hidden;
                };
            }
            menuShowStoryboard.Begin(App.Current.MainWindow);
        }

        #endregion
    }
}
