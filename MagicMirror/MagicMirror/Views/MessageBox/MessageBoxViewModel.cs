using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using MagicMirror;

namespace MagicMirror.Views
{
    internal class MessageBoxViewModel:INotifyPropertyChanged
    {
        public MessageBoxResult Result { get; set; }

        private bool isOkDefault;
        private bool isYesDefault;
        private bool isNoDefault;
        private bool isCancelDefault;

        private string title;
        private string message;
        private MessageBoxButton buttonOption;
        private MessageBoxOptions options;
        
        private Visibility yesNoVisibility;
        private Visibility cancelVisibility;
        private Visibility okVisibility;

        private HorizontalAlignment contentTextAlignment;
        private FlowDirection contentFlowDirection;
        private FlowDirection titleFlowDirection;

        private ICommand yesCommand;
        private ICommand noCommand;
        private ICommand cancelCommand;
        private ICommand okCommand;
        private ICommand escapeCommand;
        private ICommand closeCommand;

        private MessageBoxWindow view;
        private ImageSource messageImageSource;
        
        public MessageBoxViewModel(MessageBoxWindow view,string title,string message,MessageBoxButton buttonOption,
            MessageBoxImage image,MessageBoxResult defaultResult,MessageBoxOptions options)
        {
            Title = title;
            Message = message;
            ButtonOption = buttonOption;
            Options = options;

            SetDirections(options);
            SetButtonVisibility(buttonOption);
            SetImageSource(image);
            SetButtonDefault(defaultResult);
            this.view = view;
        }

        public MessageBoxButton ButtonOption
        {
            get { return buttonOption; }
            set
            {
                if (buttonOption != value)
                {
                    buttonOption = value;
                    NotifyPropertyChange("ButtonOption");
                }
            }
        }

        public MessageBoxOptions Options
        {
            get { return options; } 
            set
            {
                if (options != value)
                {
                    options = value;
                    NotifyPropertyChange("Options");
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChange("Title");
                }
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChange("Message");
                }
            }
        }

        public ImageSource MessageImageSource
        {
            get { return messageImageSource; }
            set
            {
                messageImageSource = value;
                NotifyPropertyChange("MessageImageSource");
            }
        }

        public Visibility YesNoVisibility
        {
            get { return yesNoVisibility; }
            set
            {
                if (yesNoVisibility != value)
                {
                    yesNoVisibility = value;
                    NotifyPropertyChange("YesNoVisibility");
                }
            }
        }

        public Visibility CancelVisibility
        {
            get { return cancelVisibility; }
            set
            {
                if (cancelVisibility != value)
                {
                    cancelVisibility = value;
                    NotifyPropertyChange("CancelVisibility");
                }
            }
        }

        public Visibility OkVisibility
        {
            get { return okVisibility; }
            set
            {
                if (okVisibility != value)
                {
                    okVisibility = value;
                    NotifyPropertyChange("OkVisibility");
                }
            }
        }

        public HorizontalAlignment ContentTextAlignment
        {
            get { return contentTextAlignment; }
            set
            {
                if (contentTextAlignment != value)
                {
                    contentTextAlignment = value;
                    NotifyPropertyChange("ContentTextAlignment");
                }
            }
        }

        public FlowDirection ContentFlowDirection
        {
            get { return contentFlowDirection; }
            set
            {
                if (contentFlowDirection != value)
                {
                    contentFlowDirection = value;
                    NotifyPropertyChange("ContentFlowDirection");
                }
            }
        }


        public FlowDirection TitleFlowDirection
        {
            get { return titleFlowDirection; }
            set
            {
                if (titleFlowDirection != value)
                {
                    titleFlowDirection = value;
                    NotifyPropertyChange("TitleFlowDirection");
                }
            }
        }


        public bool IsOkDefault
        {
            get { return isOkDefault; }
            set 
            {
                if (isOkDefault != value)
                {
                    isOkDefault = value;
                    NotifyPropertyChange("IsOkDefault");
                }
            }
        }

        public bool IsYesDefault
        {
            get { return isYesDefault; }
            set
            {
                if (isYesDefault != value)
                {
                    isYesDefault = value;
                    NotifyPropertyChange("IsYesDefault");
                }
            }
        }
        
        public bool IsNoDefault
        {
            get { return isNoDefault; }
            set
            {
                if (isNoDefault != value)
                {
                    isNoDefault = value;
                    NotifyPropertyChange("IsNoDefault");
                }
            }
        }
        
        public bool IsCancelDefault
        {
            get { return isCancelDefault; }
            set
            {
                if (isCancelDefault != value)
                {
                    isCancelDefault = value;
                    NotifyPropertyChange("IsCancelDefault");
                }
            }
        }

        // called when the yes button is pressed
        public ICommand YesCommand
        {
            get
            {
                if (yesCommand == null)
                    yesCommand = new DelegateCommand(() => 
                        {
                            Result = MessageBoxResult.Yes;
                            view.Close();
                        });
                return yesCommand;
            }
        }

        // called when the no button is pressed
        public ICommand NoCommand
        {
            get
            {
                if (noCommand == null)
                    noCommand = new DelegateCommand(() => 
                        {
                            Result = MessageBoxResult.No;
                            view.Close();
                        });
                return noCommand;
            }
        }

        // called when the cancel button is pressed
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new DelegateCommand(() =>
                        {
                            Result = MessageBoxResult.Cancel;
                            view.Close();
                        });
                return cancelCommand;
            }
        }

        // called when the ok button is pressed
        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                    okCommand = new DelegateCommand(() => 
                        {
                            Result = MessageBoxResult.OK;
                            view.Close();
                        });
                return okCommand;
            }
        }

        // called when the escape key is pressed
        public ICommand EscapeCommand
        {
            get
            {
                if (escapeCommand == null)
                    escapeCommand = new DelegateCommand(() =>
                    {
                        switch (ButtonOption)
                        {
                            case MessageBoxButton.OK:
                                Result = MessageBoxResult.OK;
                                view.Close();
                                break;
                            case MessageBoxButton.YesNoCancel:
                            case MessageBoxButton.OKCancel:
                                Result = MessageBoxResult.Cancel;
                                view.Close();
                                break;

                            case MessageBoxButton.YesNo:
                                // ignore close
                                break;
                            default:
                                break;
                        }
                    });
                return escapeCommand;
            }
        }

        // called when the form is closed by via close button click or programmatically
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new DelegateCommand(() =>
                    {
                        if (Result == MessageBoxResult.None)
                        {
                            switch (ButtonOption)
                            {
                                case MessageBoxButton.OK:
                                    Result = MessageBoxResult.OK;
                                    break;

                                case MessageBoxButton.YesNoCancel:
                                case MessageBoxButton.OKCancel:
                                    Result = MessageBoxResult.Cancel;
                                    break;
                                case MessageBoxButton.YesNo:
                                    //ignore close
                                    break;
                                default:
                                    break;
                            }
                        }
                        view.Close();
                    });
                return closeCommand;
            }
        }

        private void SetDirections(MessageBoxOptions options)
        {
            switch (options)
            { 
                case MessageBoxOptions.None:
                    ContentTextAlignment = HorizontalAlignment.Left;
                    ContentFlowDirection = FlowDirection.LeftToRight;
                    TitleFlowDirection = FlowDirection.LeftToRight;
                    break;

                case MessageBoxOptions.RightAlign:
                    ContentTextAlignment = HorizontalAlignment.Right;
                    ContentFlowDirection = FlowDirection.LeftToRight;
                    TitleFlowDirection = FlowDirection.LeftToRight;
                    break;

                case MessageBoxOptions.RtlReading:
                    ContentTextAlignment = HorizontalAlignment.Right;
                    ContentFlowDirection = FlowDirection.RightToLeft;
                    TitleFlowDirection = FlowDirection.RightToLeft;
                    break;

                case MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading:
                    ContentTextAlignment = HorizontalAlignment.Left;
                    ContentFlowDirection = FlowDirection.RightToLeft;
                    TitleFlowDirection = FlowDirection.RightToLeft;
                    break;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void SetButtonDefault(MessageBoxResult defaultResult)
        {
            switch (defaultResult)
            { 
                case MessageBoxResult.OK:
                    IsOkDefault = true;
                    break;

                case MessageBoxResult.Yes:
                    IsYesDefault = true;
                    break;

                case MessageBoxResult.No:
                    IsNoDefault = true;
                    break;

                case MessageBoxResult.Cancel:
                    IsCancelDefault = true;
                    break;

                default:
                    break;
            }
        }

        private void SetButtonVisibility(MessageBoxButton buttonOption)
        {
            switch (buttonOption)
            {
                case MessageBoxButton.YesNo:
                    OkVisibility = CancelVisibility = Visibility.Collapsed;
                    break;

                case MessageBoxButton.YesNoCancel:
                    OkVisibility = Visibility.Collapsed;
                    break;

                case MessageBoxButton.OK:
                    YesNoVisibility = CancelVisibility = Visibility.Collapsed;
                    break;

                case MessageBoxButton.OKCancel:
                    YesNoVisibility = Visibility.Collapsed;
                    break;

                default:
                    OkVisibility = CancelVisibility = YesNoVisibility = Visibility.Collapsed;
                    break;
            }
        }

        private void SetImageSource(MessageBoxImage image)
        {
            switch (image)
            {
                //case MessageBoxImage.Hand:
                //case MessageBoxImage.Stop:
                case MessageBoxImage.Error:
                    MessageImageSource = SystemIcons.Error.ToImageSource();
                    break;

                //case MessageBoxImage.Exclamation:
                case MessageBoxImage.Warning:
                    MessageImageSource = SystemIcons.Warning.ToImageSource();
                    break;

                case MessageBoxImage.Question:
                    MessageImageSource = SystemIcons.Question.ToImageSource();
                    break;

                //case MessageBoxImage.Asterisk:
                case MessageBoxImage.Information:
                    MessageImageSource = SystemIcons.Information.ToImageSource();
                    break;

                default:
                    MessageImageSource = null;
                    break;
            }
        }
    }

    internal static class IconUtilities
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        public static ImageSource ToImageSource(this Icon icon)
        {
            Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            if (!DeleteObject(hBitmap))
            {
                throw new Win32Exception();
            }
            return wpfBitmap;
        }
    } 
}
