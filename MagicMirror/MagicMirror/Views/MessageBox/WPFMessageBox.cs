using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MagicMirror.Views
{
    /// <summary>
    /// Custom MessageBox
    /// </summary>
    public static class WPFMessageBox
    {

        public static MessageBoxResult Show(string messageBoxText)
        {
            return ShowCore(null, messageBoxText);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return ShowCore(null, messageBoxText, caption);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText)
        {
            return ShowCore(owner, messageBoxText);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return ShowCore(null, messageBoxText, caption, button);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return ShowCore(owner, messageBoxText, caption);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return ShowCore(null, messageBoxText, caption, button, icon);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
        {
            return ShowCore(owner, messageBoxText, caption, button);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return ShowCore(null, messageBoxText, caption, button, icon, defaultResult);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return ShowCore(owner, messageBoxText, caption, button, icon);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            return ShowCore(null, messageBoxText, caption, button, icon, defaultResult, options);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return ShowCore(owner, messageBoxText, caption, button, icon, defaultResult);
        }

        /// <summary>
        /// Displays a message box in front of the specified window. The message box
        /// displays a message, title bar caption, button, and icon; and accepts a default
        /// message box result, complies with the specified options, and returns a result.
        /// </summary>
        /// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="button">A System.Windows.MessageBoxButton value that specifies which button or buttons to display.</param>
        /// <param name="icon"> A System.Windows.MessageBoxImage value that specifies the icon to display.</param>
        /// <param name="defaultResult">A System.Windows.MessageBoxResult value that specifies the default result of the message box.</param>
        /// <param name="options">A System.Windows.MessageBoxOptions value object that specifies the options.</param>
        /// <returns>A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.</returns>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            return ShowCore(owner, messageBoxText, caption, button, icon, defaultResult, options);
        }

        private static MessageBoxResult ShowCore(Window owner,string messageBoxText,string caption = "",MessageBoxButton button = MessageBoxButton.OK, 
            MessageBoxImage icon = MessageBoxImage.None,MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        {
            return MessageBoxWindow.Show(
                delegate(Window messageBoxWindow)
                {
                    messageBoxWindow.Owner = owner;
                },
                messageBoxText, caption, button, icon, defaultResult, options);
        }
    }
}
