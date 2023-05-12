using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 泛型缓存
{
    internal class GenericCacheTest
    {
        public static void Show()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GenericCache<int>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<long>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<DateTime>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<string>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                Thread.Sleep(10);
            }
        }
        /// <summary>
        /// 每个不同的T，都会生成一份不同的脚本
        /// 适合不同的类型，需要缓存一份数据的场景，效率高
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class GenericCache<T>
        {
            static GenericCache()
            {
                Console.WriteLine("this is GenericCache 静态构造函数");
                _TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
            }
            private static string _TypeTime = "";
            public static string GetCache()
            {
                return _TypeTime;
            }
        }
    }
}
