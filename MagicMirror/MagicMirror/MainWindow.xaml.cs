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
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Inter.Reader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Inter;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Impls;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.DataTransferObjects.Reader;
using Newtonsoft.Json;
using Com.IotLead.Hardware.Device.PcX86.Domain.DataTransferObjects;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Impls.RFIDReader;
using System.Threading;

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

            //系统导航控件
            Global.MainFrame = NavigationFrame;

            Global.MenuButtonBar = menuButtons;

            //后台执行系统空闲加载时进入商品动画页面
            RunSlideShowThread();
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Top = 650;
            this.Left = 650;
            //this.WindowState = WindowState.Maximized;

            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            SystemEvents_DisplaySettingsChanged(this, null);

            menuButtons.senseReaderOpened += menuButtons_senseReaderOpened;
        }

        #region ===感应输入===

        private IRfidReaderControllerImpl readerControllerImpler;

        private IRfidReaderController readerController = null;

        private List<string> epcs = new List<string>();

        /// <summary>
        /// 点击查询按钮后开始读取
        /// </summary>
        private void menuButtons_senseReaderOpened()
        {
            if (!System.IO.File.Exists(Global.readerConfigPath)) throw new Exception("找不到读写器配置文件！");
            var file = System.IO.File.ReadAllText(Global.readerConfigPath);
            var localReaderSettings = JsonConvert.DeserializeObject<ReaderWithAntennaDto>(file);

            if (localReaderSettings == null) throw new Exception("请先维护设备！");
            if (localReaderSettings.Reader.Model == "R500")
            {
                readerControllerImpler = new ImpinjR500ReaderControllerImpl();
                readerControllerImpler.ReaderTagsHandle += readerControllerImpler_ReaderTagsHandle;
                try
                {
                    readerControllerImpler.ConnectAndStart();
                }
                catch (Exception ex)
                {
                    WPFMessageBox.Show("连接设备失败！" + ex.Message);
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
                    WPFMessageBox.Show("连接设备失败！" + ex.Message);
                }
            }
            //超时关闭感应输入
            System.Timers.Timer t = new System.Timers.Timer(3000);
            t.Elapsed += (s, e) =>
            {
                if (readerControllerImpler != null) {
                    readerControllerImpler.ReaderTagsHandle -= readerControllerImpler_ReaderTagsHandle;
                    readerControllerImpler.StopAndDisconnect();
                }
                    
                if (readerController != null) {
                    readerController.ReaderTagsHandle -= readerControllerImpler_ReaderTagsHandle;
                    readerController.StopAndDisconnect();
                }
            };
            t.AutoReset = false;
            t.Enabled = true;
        }

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

            //导航结束后马上解除绑定事件
            Global.MainFrame.Navigated -= MainFrame_Navigated;
        }

        #endregion

        //根据实际应用设置主屏宽高比例
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            //获取屏幕实际宽度、高度和比例
            double ScreenWidth = SystemParameters.PrimaryScreenWidth;
            double ScreenHeight = SystemParameters.PrimaryScreenHeight;
            double ratio = ScreenWidth * 1.0 / ScreenHeight;
            double reqRatio = Global.UserInterface == UserInterface.FittingRoom ?
                Global.FittingRoomRatio : Global.ShoppingAssistRatio;
            if (ratio >= reqRatio)
            {
                this.Height = ScreenHeight * 0.4;
                this.Width = this.Height * reqRatio;
            }
            else
            {
                this.Width = ScreenWidth * 0.4;
                this.Height = this.Width / reqRatio;
            }
        }

        #region 系统空闲进入三维图片动画线
        /// <summary>
        /// 系统空闲进入三维图片动画线
        /// </summary>
        private void RunSlideShowThread()
        {
            DispatcherTimer Timer_SlideShow = new DispatcherTimer();
            Timer_SlideShow.Tick += new EventHandler((s, e) =>
            {
                try
                {
                    if (SystemIdleHelper.GetIdleTime() >= 10)
                    {
                        NavigationFrame.Navigate(new Uri("/Views/ProductSlideGallery.xaml", UriKind.Relative));
                    }
                }
                catch { }
            });
            Timer_SlideShow.Interval = new TimeSpan(0, 0, 1);
            Timer_SlideShow.Start();
        }
        #endregion
        

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }

}
