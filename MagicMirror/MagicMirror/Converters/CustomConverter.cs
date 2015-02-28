using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using MagicMirror.Util;

namespace MagicMirror.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    internal class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? Visibility.Visible :
            (parameter != null && ((string)parameter) == "Hidden" ? Visibility.Hidden : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// 网页地址转化为商品二维码转化
    /// </summary>
    internal class QRCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string productUrl = "";
                if (value == null || value.ToString() == "")
                {
                    productUrl = "";
                }
                productUrl = string.Format("www.{0}.com", productUrl);
                QRCodeCreater creater = new QRCodeCreater();
                return creater.GetQRCode(productUrl);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// 简单的数字转化为人数说明文字
    /// </summary>
    internal class IntToPersonDescConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = System.Convert.ToInt32(value);
            return string.Format("({0}人)", count);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// 商品描述为空时进行格式转化
    /// </summary>
    internal class DescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.ToString() == "") {
                return "（暂无商品说明）";
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// 选择题选项编辑控件宽度和父级宽度调节转化类
    /// </summary>
    internal class IndentParentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double parentWidth = System.Convert.ToDouble(value);
                return parentWidth - 10;
            }
            catch (Exception)
            {
                return 100;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// 图片高度和宽度比例转换器
    /// </summary>
    internal class HeightDependWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double width = System.Convert.ToDouble(value);
                return width*3/4;
            }
            catch (Exception)
            {
                return 100;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class IndexToNumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int n = 0;
            if (value != null)
            {
                Int32.TryParse(value.ToString(), out n);
            }
            return n + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int n = 0;
            if (value != null)
            {
                Int32.TryParse(value.ToString(), out n);
            }
            return n - 1;
        }

    }
}
