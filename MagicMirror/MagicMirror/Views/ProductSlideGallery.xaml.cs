using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MagicMirror.Models;
using MagicMirror.Net;
using System.Windows.Media.Media3D;
using MagicMirror.Util;
using System.Windows.Media.Animation;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;

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
        private Dictionary<int, ProductBiz> CurrentShowProducts;
        
        private bool isCompleted = false;

        public ProductSlideGallery()
        {
            InitializeComponent();

            dataservice = new DataService();
            CurrentShowProducts = new Dictionary<int, ProductBiz>();

            Thread thread = new Thread(() => {
                //TODO：这里假设了系统至少有ScenePicturesCount件产品，否则系统运行时会出问题的
                IList<ProductBiz> ProductBizs = dataservice.GetFirstPageProducts(ScenePicturesCount);
                PrepareProducts3DView(ProductBizs);
            });
            thread.Start();
        }

        #region ===商品初始化加载===

        private void PrepareProducts3DView(IList<ProductBiz> ProductBizs)
        {
            try
            {
                //假设X,Y轴偏移量数组长度必须大于ScenePicturesCount
                double[] xPositons = ShuffleUtil.Shuffle<double>(
                   new double[] { -8.5, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 8.5 });
                double[] yPositons = ShuffleUtil.Shuffle<double>(
                   new double[] { -3, -2.5, -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2, 2.5, 3 });
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    for (int index = 0; index < ScenePicturesCount; index++)
                    {
                        ModelVisual3D modelVisual3D = new ModelVisual3D();
                        GeometryModel3D geometryModel3D = new GeometryModel3D();
                        //TODO：目前因为使用的是示例图片，图片采用1,2,3.....ScenePicturesCount.jpg的命名方式
                        string imagepath = System.IO.Path.Combine(Global.AssemblyPath, "Resources", "Products", (index + 1) + ".jpg");
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(imagepath);
                        double ratio = bmp.Width * 1.0 / bmp.Height;

                        double zPosition; //Z轴偏移量
                        //设置材质
                        if ((index % 2 == 0))
                        {
                            zPosition = 0.5 * (index + 1);
                            geometryModel3D.Material = Image3DViewUtil.PrepareMaterial(imagepath, true);
                            geometryModel3D.BackMaterial = Image3DViewUtil.PrepareMaterial(imagepath, false);
                        }
                        else
                        {
                            zPosition = -0.5 * (index + 1);
                            geometryModel3D.Material = Image3DViewUtil.PrepareMaterial(imagepath, false);
                            geometryModel3D.BackMaterial = Image3DViewUtil.PrepareMaterial(imagepath, true);
                        }
                        //设置空间形状
                        geometryModel3D.Geometry = Image3DViewUtil.PrepareGeometry(imagepath, xPositons[index], yPositons[index], zPosition, ratio);
                        //设置局部旋转效果
                        geometryModel3D.Transform = SetRotateTransform3D(index);
                        modelVisual3D.Content = geometryModel3D;
                        //将产品添加到三维场景中
                        mainScene.Children.Add(modelVisual3D);

                        CurrentShowProducts.Add(index, ProductBizs[index]);
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
            (this.Resources["LoadedStoryboard"] as Storyboard).Begin(this);
            for (int index = 0; index < ScenePicturesCount; index++)
            {
                string AxisAngleRot3DName = "axisAngleRotation" + index;
                DoubleAnimation element = new DoubleAnimation();
                element.Duration = new Duration(TimeSpan.FromSeconds(60));
                element.From = -20.0;
                element.To = 20.0;
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

        #region ===商品选择===

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
                                string imageIndex = System.IO.Path.GetFileNameWithoutExtension(imagesource);
                                ProductBiz product = CurrentShowProducts[int.Parse(imageIndex)];
                                if (product != null)
                                {
                                    //进入试衣间主面板
                                    Global.MainFrame.Navigate(new Uri("/Views/ProductTryingOnControl.xaml", UriKind.Relative));
                                }
                            }
                            catch { }
                        }
                    }
                }
                return HitTestResultBehavior.Stop;
            }, pointparams);
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
