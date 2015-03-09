using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;

namespace MagicMirror
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static EventWaitHandle ProgramStarted;
        private bool CreatedNew;

        protected override void OnStartup(StartupEventArgs e)
        {
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "MyStartEvent", out CreatedNew);
            if (CreatedNew)
            {
                try
                {
                    MainWindow mainWin = new MainWindow();
                    MainWindow = mainWin;
                    mainWin.Show();
                }
                catch (Exception err)
                {
                    MessageBox.Show("系统启动失败！/n" + err.Message, "系统错误");
                    Current.Shutdown(2);
                }
            }
            else
            {
                Environment.Exit(-2);
            }
        }
    }
}
