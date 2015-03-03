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
    public partial class TryingProductAlertWin : Window
    {
        public TryingProductAlertWin()
        {
            InitializeComponent();
            
            mainGridScaleTransform.CenterX = SystemParameters.PrimaryScreenWidth / 2;
            mainGridScaleTransform.CenterY = SystemParameters.PrimaryScreenHeight / 2;

            (this.Resources["LoadStoryboard"] as Storyboard).Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard unLoadStoryboard = this.Resources["UnLoadStoryboard"] as Storyboard;
            unLoadStoryboard.Completed += (se, ee) =>
            {
                this.Close();
            };
            unLoadStoryboard.Begin();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point=e.GetPosition(mainClientArea);
            if (point.X > 0 && point.X < mainClientArea.Width 
                && point.Y > 0 && point.Y < mainClientArea.Height)
                return;
            (this.Resources["mainClientAreaStoryboard"] as Storyboard).Begin();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window1 win = new Window1();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }
    }
}
