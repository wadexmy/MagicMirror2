using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Controls;
using MagicMirror.Models;
using System.IO;

namespace MagicMirror
{
    class Global
    {
        /// <summary>
        /// 应用程序根目录
        /// </summary>
        public static string AssemblyPath = Environment.CurrentDirectory;

        /// <summary>
        /// 系统服务访问地址
        /// </summary>
        public static string ServerAddressUrl = GetAppConfig("ServerAddress");

        /// <summary>
        /// 默认的用户名称
        /// </summary>
        public static string UserName = GetAppConfig("UserName");

        /// <summary>
        /// 默认的用户密码
        /// </summary>
        public static string Password = GetAppConfig("Password");

        /// <summary>
        /// 默认背景图片
        /// </summary>
        public static string BackgroundImage = Path.Combine(AssemblyPath, GetAppConfig("BackgroundImage"));

        /// <summary>
        /// 系统导航主界面
        /// </summary>
        public static Frame MainFrame;

        /// <summary>
        /// 试衣间主界面
        /// </summary>
        public static string FittingRoomPage = "Views/FittingRoom.xaml";
        
        /// <summary>
        /// 导购屏主界面
        /// </summary>
        public static string ShoppingAssistantPage = "Views/ShoppingAssistant.xaml";

        /// <summary>
        /// 试衣间宽高比例
        /// </summary>
        public static double FittingRoomRatio = 16 * 1.0 / 9;

        /// <summary>
        /// 导购屏宽高比例
        /// </summary>
        public static double ShoppingAssistRatio = 9 * 1.0 / 16;

        /// <summary>
        /// 感应输入
        /// </summary>
        public static string readerConfigPath = Path.Combine(AssemblyPath,GetAppConfig("ReaderSettings"));

        /// <summary>
        /// 系统空闲自动进入动画屏时间间隔
        /// </summary>
        public static int IdleDuration = int.Parse(GetAppConfig("IdleDuration"));

        /// <summary>
        /// 首页动画屏播放图片数
        /// </summary>
        public static int HomeAnimatePictureCount =int.Parse(GetAppConfig("HomeAnimatePictureCount"));

        /// <summary>
        /// 图片旋转一周所需时间
        /// </summary>
        public static int AnimateCircleDuration = int.Parse(GetAppConfig("AnimateCircleDuration"));

        public static DataService _dataservice;
        /// <summary>
        /// API服务调用对象
        /// </summary>
        public static DataService dataservice{
            get {
                if (_dataservice == null)
                {
                    _dataservice = new DataService();
                }
                return _dataservice;
            }
            set {
                _dataservice = value;
            }
        }

        /// <summary>
        /// 主应用程序名称
        /// </summary>
        public static UserInterface UserInterface
        {
            get
            {
                return GetAppConfig("HomeUI") == "FittingRoom" ? 
                        UserInterface.FittingRoom : UserInterface.ShoppingAssistant;
            }
        }

        private static ProductViewModel _prodectViewModel;
        /// <summary>
        /// View Model
        /// </summary>
        public static ProductViewModel productViewModel { 
            get{
                if (_prodectViewModel == null)
                {
                    _prodectViewModel = new ProductViewModel();
                }
                return _prodectViewModel;
            }
        }

        private static List<string> _productDemoImages;
        public static List<string> ProductDemoImages
        {
            get {
                if (_productDemoImages == null || _productDemoImages.Count == 0) 
                {
                    string imageDir = System.IO.Path.Combine(Global.AssemblyPath, "Resources", "Products");
                    _productDemoImages = Directory.GetFiles(imageDir, "*.jpg").Concat(Directory.GetFiles(imageDir, "*.png")).ToList();
                }
                return _productDemoImages;
            }
        }

        #region ===声音文件===
        
        private static string switchSound;
        /// <summary>
        /// 开关声音文件
        /// </summary>
        public static string SwitchSound
        {
            get
            {
                if (string.IsNullOrEmpty(switchSound))
                {
                    switchSound = GetAppConfig("SwitchSound");
                }
                return switchSound;
            }
        }
        private static string nitifySound;
        /// <summary>
        /// 提示声音文件
        /// </summary>
        public static string NotifySound
        {
            get
            {
                if (string.IsNullOrEmpty(nitifySound))
                {
                    nitifySound = GetAppConfig("NotifySound");
                }
                return nitifySound;
            }
        }

        private static string dingSound;
        /// <summary>
        /// 状态完成声音文件
        /// </summary>
        public static string DingSound
        {
            get
            {
                if (string.IsNullOrEmpty(dingSound))
                {
                    dingSound = GetAppConfig("DingSound");
                }
                return dingSound;
            }
        }

        #endregion

        #region ===private method===
        
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        #endregion
    }
}
