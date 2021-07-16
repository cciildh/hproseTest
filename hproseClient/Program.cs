using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hproseClient
{
    using Hprose.RPC;
    class Program
    {
        static void Main()
        {
            Hprose.IO.TypeManager.Register<Person>("Person");//注册对象

            Client cli = new Client("http://localhost:10240/");
            var result = cli.Invoke<Person>("getInfo", new object[] { });
            System.Console.WriteLine("--------person对象接收---------");
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            result.Addres = "湖北广水11";
            System.Console.WriteLine("--------传递person对象---------");
            cli.Invoke("setInfo", new object[] { result });

            System.Console.ReadKey();


        }
    }


    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string Addres { get; set; }
    }

}
