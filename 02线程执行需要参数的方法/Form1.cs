using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02线程执行需要参数的方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Test);
            th.IsBackground = true;
            th.Start("123");
        }
        public void Test(object s)
        {
            string ss = (string)s;
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
