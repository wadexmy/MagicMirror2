using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Media;
using System.Windows.Input;
using System.Windows.Controls;

namespace MagicMirror.Views
{
    /// <summary>
    /// 消息弹出框
    /// <remarks>
    /// 简单的继承于CustomWindow
    /// </remarks>
    /// </summary>
    public class MessageBoxWindow : Window
    {
        [ThreadStatic]
        private static MessageBoxWindow messageBoxWindow;

        private MessageBoxViewModel viewModel;

        private TextBlock headerTitle;
        private bool CanMaximize = true;

        static MessageBoxWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxWindow), new FrameworkPropertyMetadata(typeof(MessageBoxWindow)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            headerTitle = GetTemplateChild("PART_Title") as TextBlock;
            if (headerTitle != null)
            {
                headerTitle.MouseDown += (s1, e1) =>
                {
                    if (e1.LeftButton == MouseButtonState.Pressed)
                    {
                        DragMove();
                    }
                };
            }
        }

        public static MessageBoxResult Show(Action<Window> setOwner,string messageBoxText, string caption,MessageBoxButton button, 
            MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            if ((options & MessageBoxOptions.DefaultDesktopOnly) == MessageBoxOptions.DefaultDesktopOnly)
            {
                throw new NotImplementedException();
            }

            if ((options & MessageBoxOptions.ServiceNotification) == MessageBoxOptions.ServiceNotification)
            {
                throw new NotImplementedException();
            }

            messageBoxWindow = new MessageBoxWindow();
            setOwner(messageBoxWindow);
            PlayMessageBeep(icon);

            messageBoxWindow.viewModel = new MessageBoxViewModel(messageBoxWindow, caption, messageBoxText, button, icon, defaultResult, options);
            messageBoxWindow.DataContext = messageBoxWindow.viewModel;

            messageBoxWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            messageBoxWindow.AllowsTransparency = true;
            messageBoxWindow.WindowStyle = System.Windows.WindowStyle.None;
            messageBoxWindow.ShowInTaskbar = false;
            messageBoxWindow.Topmost = true;
            messageBoxWindow.Width = 320;
            messageBoxWindow.Height = 200;
            messageBoxWindow.Icon = null;
            messageBoxWindow.ResizeMode = ResizeMode.NoResize;
            messageBoxWindow.CanMaximize = false; 
            //必须在show之前设置窗口的样式
            messageBoxWindow.ShowDialog();
            return messageBoxWindow.viewModel.Result;
        }

        private static void PlayMessageBeep(MessageBoxImage icon)
        {
            switch (icon)
            {
                case MessageBoxImage.Error:
                    SystemSounds.Hand.Play();
                    break;
                case MessageBoxImage.Warning:
                    SystemSounds.Exclamation.Play();
                    break;

                case MessageBoxImage.Question:
                    SystemSounds.Question.Play();
                    break;
                case MessageBoxImage.Information:
                    SystemSounds.Asterisk.Play();
                    break;
                default:
                    SystemSounds.Beep.Play();
                    break;
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            switch (viewModel.Options)
            {
                case MessageBoxOptions.None:
                    break;
                case MessageBoxOptions.RightAlign:
                    viewModel.ContentTextAlignment = HorizontalAlignment.Right;
                    break;
                case MessageBoxOptions.RtlReading:
                    break;
                case MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading:
                    break;
            }

            //根据情况关闭按钮不可用以及从窗口标题栏去除不必要的按钮项
            //var systemMenuHelper = new SystemMenuHelper(this);
            if (viewModel.ButtonOption == MessageBoxButton.YesNo)
            {

                //systemMenuHelper.DisableCloseButton = true;
            }
            //systemMenuHelper.RemoveResizeMenu = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            viewModel.CloseCommand.Execute(null);
        }
    }
}
