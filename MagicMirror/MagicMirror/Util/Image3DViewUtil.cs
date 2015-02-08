using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MagicMirror.Util
{
    /// <summary>
    /// 生成产品图片在三维场景中的空间形状、材质
    /// </summary>
    class Image3DViewUtil
    {
        /// <summary>
        /// 设置三维实体在控件的位置
        /// 默认都排列在Z=0的位置上，具体Z轴偏移又
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="isFront"></param>
        /// <returns></returns>
        public static MeshGeometry3D PrepareGeometry(string imageFile, double xShift, double yShift, double zShift, double ratio)
        {
            MeshGeometry3D geometry = new MeshGeometry3D();
            try
            {
                geometry.TriangleIndices = new Int32Collection(new int[] { 0, 1, 2, 0, 2, 3 });
                geometry.TextureCoordinates = new PointCollection(new Point[] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0) });
                geometry.Positions = new Point3DCollection()
                {
                    new Point3D(-1+xShift,1/ratio+yShift,zShift),
                    new Point3D(-1+xShift,-1/ratio+yShift,zShift),
                    new Point3D(1+xShift,-1/ratio+yShift,zShift),
                    new Point3D(1+xShift,1/ratio+yShift,zShift)
                };
            }
            catch { }
            return geometry;
        }

        /// <summary>
        /// 生成材质
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="isFront"></param>
        /// <returns></returns>
        public static MaterialGroup PrepareMaterial(string imageFile, bool isFront)
        {
            MaterialGroup materialGroup = new MaterialGroup();
            try
            {
                DiffuseMaterial dMaterial = new DiffuseMaterial();
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(imageFile));
                imgBrush.Stretch = Stretch.UniformToFill;
                imgBrush.TileMode = TileMode.None;
                imgBrush.AlignmentX = AlignmentX.Left;
                imgBrush.AlignmentY = AlignmentY.Top;
                imgBrush.Opacity = isFront ? 1.0 : 0.5;
                dMaterial.Brush = imgBrush;
                materialGroup.Children.Add(dMaterial);

                //SpecularMaterial sMaterial = new SpecularMaterial();
                //sMaterial.SpecularPower = 85.3333;
                //sMaterial.Brush = new SolidColorBrush(Colors.White);
                //materialGroup.Children.Add(sMaterial);
            }
            catch { 
            
            }
            return materialGroup;
        }
    }
}
