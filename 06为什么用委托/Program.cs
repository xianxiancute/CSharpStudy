using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06为什么用委托
{
    public delegate string DelStr(string name);
    internal class Program
    {
        static void Main(string[] args)
        {
            //三个需求
            //1、将一个字符串数组中每个元素转换为小写
            //2、转换为大写
            //3、在元素两边加上双引号
            string[] names = { "abcGSfs", "fafAFER", "fweDFR", "zyx" };
            //ProStrSYH(name);
            Test(names, delegate(string name)
            {
                return name.ToUpper();//"\""+name+"\"";name.ToLower();//这里直接编写需要返回的值
            });
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadLine();
        }
        public static void Test(string[] name,DelStr del)
        {
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = del(name[i]);
            }
        }





        //public static void ProToUpper(string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = name[i].ToUpper();
        //    }
        //}
        //public static void ProToLower(string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = name[i].ToLower();
        //    }
        //}
        //public static void ProStrSYH(string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = "\"" + name[i] + "\"";
        //    }
        //}
    }
}
