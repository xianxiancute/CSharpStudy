﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool b = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                b =true;
                button1.Text = "停止";
            //创建一个新的线程来执行playgram方法
            Thread th = new Thread(PlayGame);
            th.IsBackground = true;
            th.Start();
            }
            else
            {
                b = false;
                button1.Text = "开始";
            }

            if (label1.Text == "1" || label2.Text == "2" || label3.Text == "4")
            {
                MessageBox.Show("恭喜你中奖了！！");
            }
        }
        public void PlayGame()
        {
            //获取三个随机数将数据放到label中
            Random r = new Random();
            while (b)
            {
               
                label1.Text = r.Next(0, 10).ToString();
                label2.Text = r.Next(0, 10).ToString();
                label3.Text = r.Next(0, 10).ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
