using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Controls;
using MagicMirror.Models;

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

        public static UserInterface UserInterface
        {
            get
            {
                return GetAppConfig("HomeUI") == "FittingRoom" ? UserInterface.FittingRoom : UserInterface.ShoppingAssistant;;
            }
        }

        private static ProductViewModel _prodectViewModel;

        public static ProductViewModel prodectViewModel { 
            get{
                if (_prodectViewModel == null)
                {
                    _prodectViewModel = new ProductViewModel();
                }
                return _prodectViewModel;
            }
        }

        public static string tryingOnProductImage;

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
