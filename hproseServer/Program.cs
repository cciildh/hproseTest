using Hprose.RPC;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace hproseServer
{
    class Program
    {

        static void Main(string[] args)
        {



            Console.WriteLine("--------欢迎来到hprose玩耍--------");
            Hprose.IO.TypeManager.Register<Person>("Person");//注册对象

            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:10240/");
            server.Start();
            var service = new Service().Bind(server);
            service.AddInstanceMethods(new ServiceInfo());
            //service.AddInstanceMethods(new ServiceInfo1());//添加第二个服务
            System.Console.WriteLine("Server listening at http://localhost:10240/ n Press any key exit ...");
            Console.ReadLine();
            server.Stop();
        }



        public string Print(string name)
        {
            return $"果果跟小棒子搞基在Hello { name} !";
        }
    }

    public class ServiceInfo
    {
        public Person getInfo()
        {
            var result = new Person();
            result.id = "9527";
            result.name = "李嘉诚";
            result.age = 16;
            result.Addres = "未成年";
            return result;
        }

        public void setInfo(Person person)
        {
            System.Console.WriteLine("......setinfo........");
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(person));
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
