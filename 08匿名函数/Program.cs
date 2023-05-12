using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08匿名函数
{
    //声明一个委托
    public delegate void DelSayHi(string name);
    internal class Program
    {
        static void Main(string[] args)
        {
            DelSayHi del = delegate (string name)
            {
                Console.WriteLine("你好" + name);
            };
            del("张三");
            Console.ReadKey();
        }
        public static void Test(string name,DelSayHi del)
        {
            del(name);
        }
        //public static void SayHiChinese(string name)
        //{
        //    Console.WriteLine("你好"+name);
        //}
        //public static void SayHiEnglish(string name)
        //{
        //    Console.WriteLine("Nice too meet you"+name);
        //}
    }
}
