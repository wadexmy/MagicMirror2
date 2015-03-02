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

namespace MagicMirror.Views
{
    /// <summary>
    /// MainButtonMenuBar.xaml 的交互逻辑
    /// </summary>
    public partial class MainButtonMenuBar : UserControl
    {
        public MainButtonMenuBar()
        {
            InitializeComponent();

            if (Global.UserInterface == UserInterface.FittingRoom) {
                btnAllProducts.Visibility = Visibility.Collapsed;
                btnUserLogin.Visibility = Visibility.Collapsed;
                btnTrying.Visibility = Visibility.Collapsed;
                //btnFocus.Visibility = Visibility.Collapsed;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void btnAllProducts_Click(object sender, RoutedEventArgs e)
        {
            Global.MainFrame.Navigate(new Uri("/Views/AllProductsControl.xaml", UriKind.Relative));
        }

        private void btnTrying_Click(object sender, RoutedEventArgs e)
        {
            TryingProductAlertWin tryingWin = new TryingProductAlertWin();
            tryingWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tryingWin.Show();
        }
    }
}
