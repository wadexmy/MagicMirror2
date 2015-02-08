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

            NavigationFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));
            Config.MainFrame = NavigationFrame;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            SystemEvents_DisplaySettingsChanged(this, null);
        }

        //根据实际应用设置主屏宽高比例
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            //获取屏幕实际宽度、高度和比例
            double ScreenWidth = SystemParameters.PrimaryScreenWidth;
            double ScreenHeight = SystemParameters.PrimaryScreenHeight;
            double ratio = ScreenWidth * 1.0 / ScreenHeight;
           
            double reqRatio = Config.UserInterface == UserInterface.FittingRoom ?
                Config.FittingRoomRatio : Config.ShoppingAssistRatio;
            if (ratio >= reqRatio)
            {
                this.Height = ScreenHeight;
                this.Width = this.Height * reqRatio;
            }
            else
            {
                this.Width = ScreenWidth;
                this.Height = this.Width / reqRatio;
            }
        }
    }
}
