using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebApplicationSignalr
{
    public class serverhub : Hub
    {
        private static readonly char[] Constant =
         {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
        };
        public void SendOne(String Account, String Message)
        {
            Clients.Client(Account).addMessage(Message);
        }
        /// <summary>
        /// 供客戶端調用的伺服器端代碼
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            var name = GenerateRandomName(4);

            // 調用所有客戶端的sendMessage方法
            Clients.All.sendMessage(name, message);
        }
        /// <summary>
        /// 客戶端連接的時候調用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            Trace.WriteLine("客戶端連接成功");
            return base.OnConnected();
        }


        /// <summary>
        /// 產生隨機用戶名函數
        /// </summary>
        /// <param name="length">用戶名長度</param>
        /// <returns></returns>
        public static string GenerateRandomName(int length)
        {
            var newRandom = new System.Text.StringBuilder(62);
            var rd = new Random();
            for (var i = 0; i < length; i++)
            {
                newRandom.Append(Constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
