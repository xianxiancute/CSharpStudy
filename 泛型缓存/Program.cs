using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 泛型缓存
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(List<>));
            int value = 123;
            string svalue = "456";
            DateTime dValue = DateTime.Now;
            object oValue = "678";
            //GenericCacheTest.Show(value);
            GenericCacheTest.Show();
            Console.ReadLine();
        }
       
    }
   
}
