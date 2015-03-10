using System;
using System.Windows;
using System.Windows.Controls;
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
                btnSearchProducts.Visibility = Visibility.Collapsed;
                btnAllProducts.Visibility = Visibility.Collapsed;
                btnUserLogin.Visibility = Visibility.Collapsed;
                btnTrying.Visibility = Visibility.Collapsed;
                btnFocus.Visibility = Visibility.Collapsed;
            }
        }
        public delegate void SenseReaderOpened();

        public event SenseReaderOpened senseReaderOpened;

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Global.productViewModel.TryingOnProducts.Clear();
            Global.MainFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));
        }

        private void btnAllProducts_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetRowSpan(Global.MainFrame, 1);
            Global.MenuButtonBar.Visibility = Visibility.Visible;
            Global.MainFrame.Navigate(new Uri("/Views/AllProductsControl.xaml", UriKind.Relative));
        }

        private void btnTrying_Click(object sender, RoutedEventArgs e)
        {
            TryingProductAlertWin tryingWin = new TryingProductAlertWin();
            tryingWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tryingWin.Show();
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            CallAlertWin callAlertWin = new CallAlertWin();
            callAlertWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            callAlertWin.Show();
        }

        private void btnUserLogin_Click(object sender, RoutedEventArgs e)
        {
            MemberLoginWin loginWin = new MemberLoginWin();
            loginWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWin.Show();
        }

        /// <summary>
        /// 通过感应器获取EPC并且加载商品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchProducts_Click(object sender, RoutedEventArgs e)
        {
            if (senseReaderOpened != null) {
                senseReaderOpened();
            }
        }
    }
}
