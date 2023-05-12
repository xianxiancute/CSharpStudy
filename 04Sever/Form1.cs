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

namespace _04Sever
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            //点击开始监听的时候  在服务器创建一个负责监听ip地址和端口号的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            //创建端口号对象
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(textBox2.Text));
            //监听
            socketWatch.Bind(point);
            ShowMsg("监听成功");
            //设置监听容量监听队列
            socketWatch.Listen(10);

            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketWatch);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 等待客户端的连接 并且创建与之通信用的socket
        /// </summary>
        Socket socketSend;
        void Listen(object o)
        {
            Socket socketWatch = o as Socket;
            //等待用户端连接 并创建一个负责通信的socket
            while (true)
            {
                try { 
                    //负责跟客户端通信的socket
                    socketSend=socketWatch.Accept();
                    //将远程连接的客户端的IP地址和socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    //将远程连接的客户端IP地址和端口号存储到下拉框
                    comboBox1.Items.Add(socketSend.RemoteEndPoint.ToString());
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //开启一个新线程 不停的接收客户端发送的消息
                    Thread th = new Thread(Reserve);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch
                {

                }
            }
           
        }
        //将远程连接的客户端的IP地址和socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        /// <summary>
        /// 服务器端不停的接收客户端发送的消息
        /// </summary>
        /// <param name="o"></param>
        void Reserve(object o)
        {
            Socket socketSend = o as Socket;
            while (true) 
            {
                try { 
                //客户端连接成功后，服务器应该接收客户端发来的消息
                byte[] buffer = new byte[1024 * 1024 * 2];
                //实际接收的有效字节数
                int r = socketSend.Receive(buffer);
                if (r == 0)
                {
                    break;
                }
                string str = Encoding.UTF8.GetString(buffer, 0, r);
                ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                }
                catch
                {

                }
            }
        }
        void ShowMsg(string str)
        {
            textBox3.AppendText(str + "\r\n");
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = "172.20.124.182";
            textBox2.Text = "50000";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 服务器给服务端发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try {
            string str = textBox4.Text;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            //将泛型集合转化为数组
            byte[] newBuffer = list.ToArray();
            //socketSend.Send(buffer);
            //获得用户在下拉框选中的IP地址
            string ip = comboBox1.SelectedItem.ToString();
            dicSocket[ip].Send(newBuffer);
                textBox3.AppendText(str);
                textBox4.Clear();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 选择要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\钟 杰\Pictures\联想锁屏壁纸";
            ofd.Title = "请选择你要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            textBox5.Text = ofd.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //获取文件路径
            string path = textBox5.Text;
            using (FileStream fsRead=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                byte[] newBuffer = list.ToArray();
                dicSocket[comboBox1.SelectedItem.ToString()].Send(newBuffer,0,r+1,SocketFlags.None);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            dicSocket[comboBox1.SelectedItem.ToString()].Send(buffer);
        }
    }
}
