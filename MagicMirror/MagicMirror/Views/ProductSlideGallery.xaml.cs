using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;
using MagicMirror.Models;
using MagicMirror.Util;

namespace MagicMirror.Views
{
    /// <summary>
    /// ProductSlideGallery.xaml 的交互逻辑
    /// </summary>
    public partial class ProductSlideGallery : UserControl
    {
        private const int ScenePicturesCount = 10;

        /// <summary>
        /// 数据服务对象
        /// </summary>
        private DataService dataservice;

        /// <summary>
        /// 当前屏幕显示的产品
        /// </summary>
        private Dictionary<int, ProductBiz> HomeProductDic;
        
        private bool isCompleted = false;

        public ProductSlideGallery()
        {
            InitializeComponent();

            dataservice = new DataService();
            HomeProductDic = new Dictionary<int, ProductBiz>();

            menuButtons.btnTrying.Visibility = Visibility.Collapsed;
            menuButtons.btnBuy.Visibility = Visibility.Collapsed;
            (this.Resources["BusyIndicatorStoryboard"] as Storyboard).Begin(this);

            Thread thread = new Thread(() => {
                IList<ProductBiz> homeProducts = dataservice.GetFirstPageProducts(ScenePicturesCount);
                PrepareProducts3DView(homeProducts);
            });
            thread.Start();
        }

        #region ===商品初始化加载===

        private void PrepareProducts3DView(IList<ProductBiz> products)
        {
            try
            {
                //设置空间上的位置偏移
                double[] xPositons = GetXPositons(ScenePicturesCount);
                double[] yPositons = GetYPositons(ScenePicturesCount);
                double[] zPositons = GetZPositons(ScenePicturesCount);

                //目前使用示例图片
                if (Global.ProductDemoImages.Count < ScenePicturesCount)
                {
                    MessageBox.Show("至少在目录\"Resources\"/Products中放入" + ScenePicturesCount + "张图片哦！");
                    Window.GetWindow(this).Close();
                    return;
                }

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    for (int index = 0; index < ScenePicturesCount; index++)
                    {
                        products[index].Picture = Global.ProductDemoImages[index];

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
            (this.Resources["BusyIndicatorStoryboard"] as Storyboard).Stop();
            tbBusyIndicator.Visibility = Visibility.Collapsed;
            (this.Resources["LoadedStoryboard"] as Storyboard).Begin(this);
            for (int index = 0; index < ScenePicturesCount; index++)
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
        /// Y轴方向偏移
        /// </summary>
        /// <param name="ScenePicturesCount"></param>
        /// <returns></returns>
        private double[] GetZPositons(int ScenePicturesCount)
        {
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
                                ProductBiz selSku = HomeProductDic[selIndex];
                                if (selSku != null)
                                {
                                    Global.tryingOnProductImage = Global.ProductDemoImages[selIndex];
                                    if (Global.UserInterface == UserInterface.FittingRoom)
                                    {
                                        Global.MainFrame.Navigate(new Uri("/Views/ProductTryingOnControl.xaml", UriKind.Relative), selSku);
                                    }
                                    else {
                                        Global.MainFrame.Navigate(new Uri("/Views/ProductDetailControl.xaml", UriKind.Relative), selSku);
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

        void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //因为ProductTryingOnControl需要添加动画，所以要预先订阅TryingOnProducts改变事件
            Global.productViewModel.AddProduct(e.ExtraData as ProductBiz);
            //导航结束后马上解除绑定事件
            Global.MainFrame.Navigated -= MainFrame_Navigated;
        }

        #endregion

        #region ===功能按钮菜单显示和隐藏===
        
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isCompleted) return;
            Storyboard menuShowStoryboard;
            if (menuButtons.Visibility == Visibility.Collapsed)
            {
                menuButtons.Visibility = Visibility.Visible;
                menuShowStoryboard = this.Resources["buttonMenuInStoryboard"] as Storyboard;
            }
            else {
                menuShowStoryboard = this.Resources["buttonMenuOutStoryboard"] as Storyboard;
                menuShowStoryboard.Completed += (ss, ee) =>
                {
                    menuButtons.Visibility = Visibility.Collapsed;
                };
            }
            menuShowStoryboard.Begin(this);
        }

        #endregion
    }
}
