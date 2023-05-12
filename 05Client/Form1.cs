using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket socketSend;
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            //创建负责连接的socket
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            IPEndPoint point =new IPEndPoint(ip, Convert.ToInt32(textBox2.Text));
            //获得要连接的远程服务器的IP地址和端口号
            socketSend.Connect(point);
            ShowMsg("连接成功");
            //开启一个新线程不停的接收服务端发来的消息
            Thread th = new Thread(Reserve);
            th.IsBackground = true;
            th.Start();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 不停的接收服务端发来的消息
        /// </summary>
        void Reserve()
        {
            while (true)
            {
                try { 
                byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接收到的字节数
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    //表示发送的文字消息
                    if (buffer[0] == 0)
                    {
                string s = Encoding.UTF8.GetString(buffer, 1, r-1);
                ShowMsg(socketSend.RemoteEndPoint + ":" + s);
                }
                    else if (buffer[0]==1)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = @"C:\Users\钟 杰\Pictures\联想锁屏壁纸";
                        sfd.Title = "请选择要保存的文件";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);
                        string path= sfd.FileName;
                        using (FileStream fsWrite=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
                        {
                            fsWrite.Write(buffer, 1, r - 1);
                        }
                        MessageBox.Show("保存成功");
                    }
                    else if (buffer[0] == 2)
                    {
                        ZD();
                    }
                }
               
                catch
                {

                }
            }
        }
        /// <summary>
        /// 震动
        /// </summary>
        void ZD()
        {
            for (int i = 0; i < 500; i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(280, 280);
            }
        }
        void ShowMsg(string str)
        {
            textBox3.AppendText(str + "\r\n");
        }
        /// <summary>
        /// 客户机给服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text.Trim();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            socketSend.Send(buffer);
            textBox3.AppendText(str);
            textBox4.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
