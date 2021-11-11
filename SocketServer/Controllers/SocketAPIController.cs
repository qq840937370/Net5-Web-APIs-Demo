using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer.Controllers
{
    // Socker服务器
    [ApiController]
    [Route("api/[controller]")]
    public class SocketAPIController : ControllerBase
    {
        /// <summary>
        /// 单个WebSocket通讯示例
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task WebSocketGet ()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)  // 如果是WebSocket请求
            {
                using (WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
                {
                    await ProcessingRequestAsync(webSocket); 
                }

            }
            else
            {
                HttpContext.Response.StatusCode = 400;  //不是websocket客户端请求，返回400
            }
        }

        /// <summary>
        /// 异步处理客户端的请求，接受消息，发送消息，关闭连接
        /// </summary>
        /// <param name="webSocket"></param>
        /// <returns></returns>
        private async Task ProcessingRequestAsync(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];  // 接收到的数据的大小,一般2048和4096都可以
            var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (webSocket != null && webSocket.State == WebSocketState.Open)  // 如果连接正常且是打开的，循环处理信息
            {
                receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);  // 此句放在while里面，每次使用都重新初始化。如果放在外面，由于没有进行清空操作，下一次接收的数据若比上一次短，则会多出一部分内容。
                
                // 业务处理
                var serverMsg = Encoding.UTF8.GetBytes($"服务器: “你好！你上传了: {Encoding.UTF8.GetString(buffer)}”");  

                // 向客户端发送消息
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), receiveResult.MessageType, receiveResult.EndOfMessage, CancellationToken.None);
            }
            //关闭释放与客户端连接
            //await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, String.Empty, CancellationToken.None);  // 正常关闭，不返回具体原因
            await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);  // 返回本次WebSocket关闭的原因
        }
    }

    /*
     * let ws = new WebSocket('ws://api.zhandian.com/ws');//连接的就是api网站的地址
     *       ws.onmessage = function (e) {
     *          //监听消息
     *           console.log(e);
     *           console.log(e.data);
     *       };
     */
}
