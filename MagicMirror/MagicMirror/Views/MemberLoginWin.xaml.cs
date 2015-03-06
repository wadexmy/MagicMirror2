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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace MagicMirror.Views
{
    /// <summary>
    /// TryingProductAlertWin.xaml 的交互逻辑
    /// </summary>
    public partial class MemberLoginWin : Window
    {
        public MemberLoginWin()
        {
            InitializeComponent();
            
            mainGridScaleTransform.CenterX = SystemParameters.PrimaryScreenWidth / 2;
            mainGridScaleTransform.CenterY = SystemParameters.PrimaryScreenHeight / 2;

            //窗口启动动画
            (this.Resources["LoadStoryboard"] as Storyboard).Begin();
        }

        //窗口关闭动画
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Storyboard unLoadStoryboard = this.Resources["UnLoadStoryboard"] as Storyboard;
            unLoadStoryboard.Completed += (se, ee) =>
            {
                this.Close();
            };
            unLoadStoryboard.Begin();
        }

        //模态窗口用户区域外鼠标点击，窗口闪动动画效果
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point=e.GetPosition(mainClientArea);
            if (point.X > 0 && point.X < mainClientArea.Width 
                && point.Y > 0 && point.Y < mainClientArea.Height)
                return;
            (this.Resources["mainClientAreaStoryboard"] as Storyboard).Begin();
        }
    }
}
