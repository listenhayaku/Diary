using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Net.WebSockets;
using System.Diagnostics;

namespace Diary
{
    /// <summary>
    /// WebSocket1 的摘要描述
    /// 這個有成功建立一個websocket server url:wss://localhost:44349/WebSocket1.ashx
    /// </summary>
    public class WebSocket1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(async socketContext =>
                {
                    await Echo(socketContext.WebSocket);
                });
            }
            else
            {
                context.Response.Write("Ready to accept WebSocket request at:" + context.Request.Url.ToString().Replace("https://","wss://").Replace("http://","ws://"));
                context.Response.Flush();
            }
        }

        private async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                //Debug.WriteLine($"(debug)[WebSocket1.Echo]result:{result}");
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}