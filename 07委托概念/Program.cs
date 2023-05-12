using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07委托概念
{
    internal class Program
    {
        //声明一个委托指向一个函数
        public delegate void DelSayHi(string name);
        public delegate void DelWork(string name);
        static void Main(string[] args)
        {
            //DelSayHi del = SayHichinese;//new DelSayHi(SayHichinese);
            //del("张三");
            //Console.ReadLine();
            Test("张三", SayHiEnglish);
            Test("李四", SayHichinese);
            Test1("王五", Sleep);
            Test1("赵六", EatApple);
            Console.ReadLine();

        }
        public static void Test(string name,DelSayHi del)
        {
            //调用
            del(name);
        }
        public static void Test1(string name,DelWork del)
        {
            del(name);
        }
        public static void SayHichinese(string name)
        {
            Console.WriteLine("吃了吗"+name);
        }
        public static void SayHiEnglish(string name)
        {
            Console.WriteLine("Nice to meet you"+name);
        }
        public static void EatApple(string name)
        {
            Console.WriteLine(name+"吃苹果");
        }
        public static void Sleep(string name)
        {
            Console.WriteLine(name+"睡觉");
        }
    }
}
