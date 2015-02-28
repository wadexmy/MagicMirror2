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
using Microsoft.Win32;
using MagicMirror.Models;
using System.Windows.Threading;
using MagicMirror.Views;

namespace MagicMirror
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //NavigationFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));

            //系统导航控件
            Global.MainFrame = NavigationFrame;

            //后台执行系统空闲加载时进入商品动画页面
            RunSlideShowThread();

            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //this.WindowState = WindowState.Maximized;
            TryingProductAlertWin alertWin = new TryingProductAlertWin();
            alertWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            alertWin.Show();
            this.WindowState = WindowState.Minimized;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            SystemEvents_DisplaySettingsChanged(this, null);
            this.Top = 600;
            this.Left = 800;
        }

        //根据实际应用设置主屏宽高比例
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            //获取屏幕实际宽度、高度和比例
            double ScreenWidth = SystemParameters.PrimaryScreenWidth;
            double ScreenHeight = SystemParameters.PrimaryScreenHeight;
            double ratio = ScreenWidth * 1.0 / ScreenHeight;
           
            double reqRatio = Global.UserInterface == UserInterface.FittingRoom ?
                Global.FittingRoomRatio : Global.ShoppingAssistRatio;
            if (ratio >= reqRatio)
            {
                this.Height = ScreenHeight*0.4;
                this.Width = this.Height * reqRatio;
            }
            else
            {
                this.Width = ScreenWidth * 0.4;
                this.Height = this.Width / reqRatio;
            }
        }

        /// <summary>
        /// 图片轮播线程
        /// </summary>
        private void RunSlideShowThread()
        {
            DispatcherTimer Timer_SlideShow = new DispatcherTimer();
            Timer_SlideShow.Tick += new EventHandler((s, e) =>
            {
                try
                {
                    if (SystemIdleHelper.GetIdleTime() >= 5)
                    {
                        NavigationFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));
                    }
                }
                catch { }
            });
            Timer_SlideShow.Interval = new TimeSpan(0, 0, 1);
            Timer_SlideShow.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove(); 
        }
    }
}
