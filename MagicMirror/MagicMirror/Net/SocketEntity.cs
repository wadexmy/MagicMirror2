using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MagicMirror.Net
{
    /// <summary>
    /// 数据传输报文实体协议类
    /// </summary>
    [Serializable]
    public class SocketEntity
    {
        /// <summary>
        /// 消息类型
        /// <remarks>
        /// 0:文本；1：图片；2：文件
        /// </remarks>
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数据传输端说明
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据传输内容
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 数据传输时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 传输文件名称
        /// </summary>
        public string FileName{ get; set; }

        public SocketEntity(int type, string name, byte[] content,DateTime date,string fileName)
        {
            this.Type = type;
            this.Name = name;
            this.Content = content;
            this.Date = date;
            this.FileName = fileName;
        }

        /// <summary>
        /// 序列化
        /// </summary>
        public byte[] GetBytes()
        {
            byte[] binaryDataResult = null;
            MemoryStream memStream = new MemoryStream();
            IFormatter brFormatter = new BinaryFormatter();

            brFormatter.Serialize(memStream, this);
            binaryDataResult = memStream.ToArray();
            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        /// <summary>   
        /// 反序列化   
        /// </summary>   
        /// <param name="byPacket"></param>   
        /// <returns></returns>   
        public static SocketEntity GetSocketEntity(byte[] byPacket)
        {
            MemoryStream memStream = new MemoryStream(byPacket);
            IFormatter brFormatter = new BinaryFormatter();
            SocketEntity entity;
            try
            {
                entity = (SocketEntity)brFormatter.Deserialize(memStream);
            }
            catch (Exception)
            {
                throw new InvalidCastException("反序列化网络传输数据失败");
            }
            memStream.Close();
            memStream.Dispose();
            return entity;
        }
    }
}
