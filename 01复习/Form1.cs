using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明一个泛型集合存储图片文件
        List<string> list = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Title = "请选择图片";
            ofd.InitialDirectory = @"C:\Users\钟 杰\Pictures\联想锁屏壁纸";
            ofd.Multiselect = true;
            ofd.Filter = "图片|*.jpg|所有文件|*.*";
            ofd.ShowDialog();
            //获得我们在文件夹中选中的全路径
            string[] path=ofd.FileNames;
            for (int i = 0; i < path.Length; i++)
            {
                //将文件的文件名加载到listbox中
                listBox1.Items.Add(Path.GetFileName(path[i]));
                //将图片的全路径存放到泛型集合中
                list.Add(path[i]);
            }
        }

        /// <summary>
        /// 实现双击显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            pictureBox1.ImageLocation = list[listBox1.SelectedIndex];
        }

        /// <summary>
        /// 点击显示下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //获取当前选中的索引
            int index = listBox1.SelectedIndex;
            index++;
            //判断索引
            if (index == listBox1.Items.Count)
            {
                index = 0;
            }
            //将改变后的索引重新的赋值给我当前选中的索引
             listBox1.SelectedIndex =index;
            pictureBox1.ImageLocation = list[index];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取当前索引
            int index = listBox1.SelectedIndex;
            index--;
            if (index < 0)
            {
                index = listBox1.Items.Count-1;
            }
            listBox1.SelectedIndex = index;
            pictureBox1.ImageLocation = list[index];
        }
    }
}
