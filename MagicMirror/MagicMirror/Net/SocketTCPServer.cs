using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MagicMirror.Net
{
    public delegate void StreamDataAcceptHandler(string AccepterID, SocketEntity AcceptData);
    public delegate void AsySocketEventHandler(string SenderID, string EventMessage);
    public delegate void AcceptEventHandler(SocketTCPServer AcceptedSocket);
    public delegate void AsySocketClosedEventHandler(string SocketID, string ErrorMessage);

    public class StateObject
    {
        // 客户端 socket.
        public Socket workSocket = null;
        // 接收 buffer大小.
        public const int BufferSize = 1048576;
        // 接收 buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    /// <summary>
    /// 网络传输服务对象
    /// <remarks>
    /// 可以作为客户端或者服务器端，发送和接收数据
    /// </remarks>
    /// </summary>
    public class SocketTCPServer
    {
        public SocketTCPServer(string iPAddress, int port)
        {
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPAddress ip = Dns.GetHostAddresses(iPAddress)[0];
                IPEndPoint ipe = new IPEndPoint(ip, port);
                id = Guid.NewGuid().ToString();
                mSocket.Bind(ipe);
            }
            catch (Exception)
            {

            }
        }

        public SocketTCPServer(Socket linkObject)
        {
            mSocket = linkObject;
            id = Guid.NewGuid().ToString();
        }

        #region 私有字段

        private Socket mSocket = null;

        private string id = "";

        #endregion

        #region 公共属性

        public static string EndChar
        {
            get
            {
                return new string((char)0, 1);
            }
        }

        public string ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// 发送、接受数据的结尾标志
        /// </summary>
        public static char LastSign
        {
            get
            {
                return (char)0;
            }
        }

        /// <summary>
        ///服务器角色反转,作为客户端后连接的服务器Socket
        /// </summary>
        public Socket LinkedSocket
        {
            get
            {
                return mSocket;
            }
            set
            {
                mSocket = value;
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 接受连接的事件
        /// </summary>
        public event AcceptEventHandler OnClientConnected;
        /// <summary>
        /// 接收二进制数据事件
        /// </summary>
        public event StreamDataAcceptHandler OnByteDataReceived;
        /// <summary>
        /// 数据发送成功事件
        /// </summary>
        public event AsySocketEventHandler OnDataSended;
        /// <summary>
        /// 异常关闭的事件
        /// </summary>
        public event AsySocketClosedEventHandler OnClosed;
        #endregion

        #region 启动监听，并开始等待接收数据

        /// <summary>
        /// 监听
        /// </summary>
        public void Listen(int backlog)
        {
            if (mSocket == null)
                throw new ArgumentNullException("连接不存在");
            mSocket.Listen(backlog);
            //异步接收请求
            mSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }


        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket handler = mSocket.EndAccept(ar);
            SocketTCPServer newSocket = new SocketTCPServer(handler);
            //激发事件
            if (OnClientConnected != null)
                OnClientConnected(newSocket);
            //重新监听
            mSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        /// <summary>
        /// 开始接受数据
        /// </summary>
        public void BeginAcceptData()
        {
            if (mSocket == null)
                throw new ArgumentNullException("连接对象为空");

            //开始接收数据
            StateObject state = new StateObject();
            state.workSocket = mSocket;

            mSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            //receiveDone.WaitOne();
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = ar.AsyncState as StateObject;
                //读取数据
                int bytesRead = mSocket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(UTF8Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    string sb = state.sb.ToString();
                    if (sb.Substring(sb.Length - 1, 1) == EndChar)
                    {
                        //接收完成
                        //激发事件
                        state = new StateObject();
                        state.workSocket = mSocket;
                    }

                    mSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                    SocketEntity entity = SocketEntity.GetSocketEntity(state.buffer);
                    if (OnByteDataReceived != null)
                        OnByteDataReceived(id, entity);
                }
            }
            catch (SocketException se)
            {
                if (OnClosed != null)
                    OnClosed(ID, se.Message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        #endregion

        #region 发送数据

        public void SendData(int Type, string Name, byte[] Content, DateTime date, string fileName)
        {
            if (mSocket == null)
                throw new ArgumentNullException("连接不存在");
            if (Content == null)
                return;
            SocketEntity my = new SocketEntity(Type, Name, Content, date, fileName);
            byte[] SendData = my.GetBytes();
            mSocket.BeginSend(SendData, 0, SendData.Length, 0, new AsyncCallback(SendCallBack), mSocket);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                mSocket.EndSend(ar);
                //触发事件
                if (OnDataSended != null)
                    OnDataSended(id, "OK");
            }
            catch (SocketException se)
            {
                if (OnClosed != null)
                    OnClosed(ID, se.Message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        #endregion
    }
}
