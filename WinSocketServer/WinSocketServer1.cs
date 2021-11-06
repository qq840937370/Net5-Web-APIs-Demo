using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSocketServer
{
    public partial class WinSocketServer1 : Form
    {
        public WinSocketServer1()
        {
            InitializeComponent();
        }

        private void WinSockerServer1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 打开服务
        /// </summary>
        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            if (txtIPAddress.Enabled == true)
            {
                MessageBox.Show("请先确认地址");
                return;
            }
            string IpAdress = txtIPAddress.Text;
            txtInfo.AppendText("打开监听" + DateTime.Now.ToString() + "\n");
            Start(IpAdress);
        }



        /// <summary>
        /// 关闭服务
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (httpListener.IsListening)
            {
                try
                {
                    httpListener.Stop();
                    txtInfo.AppendText("成功关闭" + DateTime.Now.ToString() + "\n");
                    lblListen.Text = "服务为关闭状态";
                }
                catch (Exception ex)
                {
                    txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                }
            }
            else
            {
                txtInfo.AppendText("此时服务并未处于监听状态，无法关闭" + DateTime.Now.ToString() + "\n");
                lblListen.Text = "服务为关闭状态";
                return;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "修改")
            {
                txtIPAddress.Enabled = true;
                btnModify.Text = "确定";
            }
            else if (btnModify.Text == "确定")
            {
                txtIPAddress.Enabled = false;
                btnModify.Text = "修改";
            }
        }

        /// <summary>
        /// 广播
        /// </summary>
        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            string jsonmessage = RequestMsg.SerializeJson(txtAvalue.Text, txtBvalue.Text);
            txtInfo.AppendText("广播" + DateTime.Now.ToString() + ":\n");
            txtInfo.AppendText("内容：" + jsonmessage + "\n");
            Broadcast(jsonmessage);
        }
        /// <summary>
        /// 显示链接列表
        /// </summary>
        private void btnShowCon_Click(object sender, EventArgs e)
        {
            int ConnectionCount = _sockets.Count;
            txtInfo.AppendText("服务端当前存储了" + ConnectionCount + "个客户端连接:\n" + DateTime.Now.ToString() + "\n");
            foreach (WebSocket innersocket in _sockets)
            {
                txtInfo.AppendText(innersocket.GetHashCode().ToString() + innersocket.State.ToString() + "\n");
            }
        }

        #region 监听方法
        private static List<WebSocket> _sockets = new List<WebSocket>();  // 存储当前所有连接的静态列表
        private static HttpListener httpListener = new HttpListener();    // HttpListener

        /// <summary>
        /// 开启Socket服务，对参数地址进行监听
        /// </summary>
        /// <param name="ipAdress">监听地址，记得以 / 结尾</param>
        private async void Start(string ipAdress)
        {
            try
            {
                httpListener.Prefixes.Add(ipAdress); // 添加监听的URL范围
                // 通过连接名称可以区分多个websocket服务。如可以通过 http://localhost:8080/learn http://localhost:8080/work 使用两个服务，不过需要多线程和两个http监听对象等
                httpListener.Start();
                lblListen.Text = "监听中...";
                while (true)
                {
                    // http端口监听获取内容
                    HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                    if (httpListenerContext.Request.IsWebSocketRequest)  // 如果是websocket请求
                    {
                        // 处理SocketRequest
                        ProcessRequest(httpListenerContext);
                    }
                    else
                    {
                        httpListenerContext.Response.StatusCode = 400;
                        httpListenerContext.Response.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
            }
        }

        /// <summary>
        /// 处理端口监听到的请求
        /// </summary>
        /// <param name="httpListenerContext"></param>
        private async void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            WebSocketContext webSocketContext = null;  // WebSocketContext 类用于访问websocket握手中的信息
            try
            {
                webSocketContext = await httpListenerContext.AcceptWebSocketAsync(subProtocol: null);  // 配置协议为空
                // 获取客户端IP
                string ipAddress = httpListenerContext.Request.RemoteEndPoint.Address.ToString();
                txtInfo.AppendText("客户端IP地址:" + ipAddress + "\n");
            }
            catch (Exception e)  // 如果出错
            {
                httpListenerContext.Response.StatusCode = 500;
                httpListenerContext.Response.Close();
                txtInfo.AppendText("Exception:" + e.ToString() + DateTime.Now.ToString() + "\n");
                return;
            }
            // 获取websocket连接
            WebSocket webSocket = webSocketContext.WebSocket;
            _sockets.Add(webSocket);         // 此处将web socket对象加入一个静态列表中
            SendToNewConnection(webSocket);  // 将当前服务器上最新的数据（a,b的值）发送过去

            try
            {
                // 我们定义一个常数，它将表示接收到的数据的大小。 它是由我们建立的，我们可以设定任何值。 我们知道在这种情况下，发送的数据的大小非常小。
                const int maxMessageSize = 2048;
                // received bits的缓冲区

                while (webSocket != null && webSocket.State == WebSocketState.Open)  // 如果连接是打开的
                {
                    // 此句放在while里面，每次使用都重新初始化。如果放在外面，由于没有进行清空操作，下一次接收的数据若比上一次短，则会多出一部分内容。
                    var receiveBuffer = new ArraySegment<Byte>(new Byte[maxMessageSize]);

                    WebSocketReceiveResult receiveResult = null;
                    byte[] payloadData = null;
                    do
                    {
                        // 读取数据。此类的实例表示在 WebSocket 上执行单个 ReceiveAsync 操作所得到的结果
                        receiveResult = await webSocket.ReceiveAsync(receiveBuffer, CancellationToken.None);
                        // 字节数组
                        payloadData = receiveBuffer.Array.Where(b => b != 0).ToArray();
                    }
                    while (!receiveResult.EndOfMessage);  // 如果指示已完整接收消息则停止

                    // 如果输入帧为取消帧，发送close命令。
                    // MessageType指示当前消息是utf-8消息还是二进制信息。Text(0,明文形式),Close(2，收到关闭消息，接受已完成),Binary(1,消息采用二进制格式)
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, String.Empty, CancellationToken.None);
                        _sockets.Remove(webSocket);  // 从列表移除当前连接

                    }
                    else
                    {
                        // 因为我们知道这是一个字符串，我们转换它                        
                        string receiveString = System.Text.Encoding.UTF8.GetString(payloadData, 0, payloadData.Length);

                        try  // 将反序列化内容放入try中，避免无法匹配、内容为空等可能报错的地方
                        {
                            // 将转换后的字符串内容进行json反序列化。参考：https://www.cnblogs.com/yinmu/p/12160343.html
                            TestValue tv = JsonConvert.DeserializeObject<TestValue>(receiveString);
                            // 将收到的a,b的值显示到文本框
                            if (tv != null)
                            {
                                string valueA = string.Empty, valueB = string.Empty;
                                if (tv.a != null && tv.a.Length > 0) { valueA = tv.a; }
                                if (tv.a != null && tv.b.Length > 0) { valueB = tv.b; }
                                txtAvalue.Text = valueA;
                                txtBvalue.Text = valueB;
                            }

                            RefreshConnectionList();  // 先清理无效的连接，否则会导致服务端websocket被dispose

                            //  当接收到文本消息时，对当前服务器上所有web socket连接进行广播
                            foreach (var innerSocket in _sockets)
                            {
                                await innerSocket.SendAsync(new ArraySegment<byte>(payloadData), WebSocketMessageType.Text, true, CancellationToken.None);
                            }
                        }
                        catch (Exception ex)
                        {
                            // 如果json反序列化出了问题
                            txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");  // 将错误类型显示出来
                            txtInfo.AppendText(receiveString + DateTime.Now.ToString() + "\n");  // 将收到的原始字符串显示出来
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e.GetType().ToString() == "System.Net.WebSockets.WebSocketException")
                {
                    // 客户端关闭时会抛出此错误
                    txtInfo.AppendText("连接已关闭" + DateTime.Now.ToString() + "\n");
                }
                else
                {
                    txtInfo.AppendText(e.ToString() + DateTime.Now.ToString() + "\n");
                }
            }
        }
        #endregion

        #region 广播
        /// <summary>
        /// 服务端主动向所有客户端广播
        /// </summary>
        /// <param name="jsonmessage">传过来的应该是序列化后的json字符串，接收方会通过TestValue类进行反序列化获取a,b的内容</param>
        public async void Broadcast(string jsonmessage)
        {
            try
            {
                Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonmessage);
                RefreshConnectionList();//先清理无效的连接，否则会导致服务端websocket被dispose
                //当接收到文本消息时，对当前服务器上所有web socket连接进行广播
                foreach (var innerSocket in _sockets)
                {
                    await innerSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                MessageBox.Show("某些连接出了问题，如果广播多次出问题，请重启服务端");
            }
        }
        /// <summary>
        /// 监听到一个新的websocket连接后，将服务器当前最新数据同步过去
        /// </summary>
        /// <param name="currentWebsocket">当前新接入的websocket连接</param>
        public async void SendToNewConnection(WebSocket currentWebsocket)
        {
            try
            {
                string jsonmessage = RequestMsg.SerializeJson(txtAvalue.Text, txtBvalue.Text);
                Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonmessage);

                if (currentWebsocket.State == WebSocketState.Open)
                {
                    await currentWebsocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);//try访问已释放对象问题
                }
                else
                {
                    //此处并不对该链接进行移除，会导致调用本方法后的代码出问题，只需在进行发送时确认状态即可
                    txtInfo.AppendText("新接入连接:" + currentWebsocket.GetHashCode().ToString() + "的连接状态不为open，因此停止向其同步数据" + DateTime.Now.ToString() + "\n");
                }
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
            }
        }

        /// <summary>
        /// 刷新当前websocket连接列表，如果状态为Closed，则移除。连接异常断开后会被dispose，如果访问会报错，但可以获取状态为closed
        /// </summary>
        public static void RefreshConnectionList()
        {
            if (_sockets != null)//lock不能锁定空值
            {
                lock (_sockets)//锁定数据源
                {
                    //System.InvalidOperationException: 集合已修改；可能无法执行枚举操作。
                    //使用foreach不能执行删除、修改，这是规定。你可以使用for循环遍历修改。删除数据正确做法，for循环 i 要从大到小
                    for (int i = _sockets.Count - 1; i >= 0; i--)
                    {
                        if (_sockets[i].State != WebSocketState.Open)
                        {
                            _sockets.Remove(_sockets[i]);
                        }
                    }
                }
            }

        }
        #endregion
    }
}
