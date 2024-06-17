using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatDemo
{
    public partial class MainFrm : Form
    {
        List<Socket> ClientProxSocketList = new List<Socket>();
        Dictionary<Socket,string> ClientDic = new Dictionary<Socket,string>();
        JSONObject jsonObj = new JSONObject();
        public MainFrm()
        {
            InitializeComponent();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            string IP = txtIP.Text;
            int port = Convert.ToInt32(txtPort.Text);
            //1新建一个socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2綁定端口ip 
            socket.Bind(new IPEndPoint(IPAddress.Parse(IP), port));
            //3开启帧听
            socket.Listen(10);//監聽：同时来了100連結請求，只能處理一个連接，隊列里面放10个等待連接的客户端，其他的返回錯誤訊息
            //4開始接受客户端連接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);//new WaitCalback是个委托將方法当作参数傳遞
        }
        //接受客户端的連接
        public void AcceptClientConnect(object socket)
        {
            var serverSocket = socket as Socket;//强轉成socket
            this.AppendTextToTxtLog("伺服器開始接受連接。");
            while (true)//接受客户端的連接
            {
                var proxSocket = serverSocket.Accept();//接受連接
                this.AppendTextToTxtLog(string.Format("客户端：{0}連接上了", proxSocket.RemoteEndPoint.ToString()));
                ClientProxSocketList.Add(proxSocket);
                //不停的接受當前連結的客户端發送来的消息
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), proxSocket);
            }
        }
        public void ReceiveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                     len= proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    //異常退出
                    AppendTextToTxtLog(string.Format("客户端：{0}非正常退出",
                    proxSocket.RemoteEndPoint.ToString()));
                    ClientProxSocketList.Remove(proxSocket);//移除客户端
                    ClientDic.Remove(proxSocket);
                    StopConnect(proxSocket);
                    return;//讓方法结束，終結當前結束客户端數據
                }
                if (len <= 0)
                {
                    //客户端正常退出
                    AppendTextToTxtLog(string.Format("客户端：{0}正常退出",
                    proxSocket.RemoteEndPoint.ToString()));
                    ClientProxSocketList.Remove(proxSocket);//移除客户端
                    ClientDic.Remove(proxSocket);
                    StopConnect(proxSocket);
                    return;//讓方法結束，终结当前结束客户端數據
                }
                //把接受到的數據放到文字框上
                string str = Encoding.UTF8.GetString(data, 0, len);//用UTF-8
                jsonObj = JSONConvert.DeserializeObject(str);
                string uname = (string)jsonObj["uname"];
                string protocol = (string)jsonObj["protocol"];
                if (protocol == "login")
                {
                    ClientDic.Add(proxSocket,uname);
                }
            }
        }
        private void StopConnect(Socket proxSocket)
        {
            try
            {
                if (proxSocket.Connected)
                {
                    proxSocket.Shutdown(SocketShutdown.Both);
                    proxSocket.Close(100);//100秒后没有正常關閉強制關閉
                }
            }
            catch (Exception ex)
            {

            }
        }
        //往文本上添加數據
        public void AppendTextToTxtLog(string txt)
        {
            if (txtLog.InvokeRequired)//考慮多線程
            {
                //执行
                txtLog.BeginInvoke(new Action<string>(s =>
                {
                    this.txtLog.Text = string.Format("{0}\r\n{1}", s, txtLog.Text);
                }), txt);
            }
            else
            {
                this.txtLog.Text = string.Format("{0}\r\n{1}", txt, txtLog.Text);//不考慮多線程
            }

        }
        /// <summary>
        /// 發送訊息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            SendMsg(txtKing.Text+"&"+txtQueen.Text+"&"+txtJack.Text);
        }
        private void SendMsg(string msg)
        {
            foreach (var proxSocket in ClientProxSocketList)
            {
                if (proxSocket.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(msg);//數據轉換為字節數組
                    proxSocket.Send(data, 0, data.Length, SocketFlags.None);
                }
            }
        }
    }
}
