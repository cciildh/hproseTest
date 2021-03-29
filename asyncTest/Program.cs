using System;
using System.Text;
using System.Threading;

namespace asyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Console.WriteLine("开始办正事！");
            //var sum = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread.Sleep(200);
            //    sum++;
            //}
            //Console.WriteLine("开始写日志！");
            //logUtils.SaveLog(sum.ToString());

            //Console.WriteLine("正事办理完成！");

            string str = "上善若水";

            // 现将字符串能转换成字节数组，UTF8格式的
            byte[] buffer = Encoding.UTF8.GetBytes(str);

            string newStr = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(newStr);

            Console.ReadLine();
        }
    }
}
