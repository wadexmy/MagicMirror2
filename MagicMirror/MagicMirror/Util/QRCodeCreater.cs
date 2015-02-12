﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace MagicMirror.Util
{
    class QRCodeCreater
    {
        public Image GetQRCode(string content)
        {
            Image img = new Image();
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeScale = 3;
                System.Drawing.Bitmap bitmap = qrCodeEncoder.Encode(content, System.Text.Encoding.UTF8);
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    stream.Seek(0, SeekOrigin.Begin);
                    bi.StreamSource = stream;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                    img.Source = bi;
                }
                bitmap.Dispose();
                bitmap = null;
            }
            catch {
                img = null;
            }
            return img;
        }
    }
}