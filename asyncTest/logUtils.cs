using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncTest
{
    public class logUtils
    {
        public  static async  void SaveLog( string result )
        {
           await Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("日志写完了"+result);
            });

        }

    }
}
