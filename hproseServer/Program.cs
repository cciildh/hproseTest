using Hprose.RPC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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
            //Hprose.RPC.InvokeHandler invokeHandler 

            //InvokeHandler myInvokeHandler = (name, arg, context, next) =>
            //{
            //    var result = next(name, arg, context);
            //    ServiceContext context1 = new ServiceContext(service);
            //    context.CopyTo(context1);
            //    EndPoint endpoint = context1.RemoteEndPoint;
            //    Console.WriteLine("调用成功！服务端的InvokeHandler:" + endpoint);
            //    return result;
            //};


            IOHandler ioHandler = (request, context, next) =>
            {
                context = (ServiceContext)context;
                ServiceContext context1 = new ServiceContext(service);
                context.CopyTo(context1);

                if (request.Length > 0)
                    Console.WriteLine("request:" + getRequestBody(request));
                //getRequestBody(request);

                //EndPoint endpoint = context1.RemoteEndPoint;
                //Console.WriteLine("服务端的IOHandler:" + endpoint);
                //string[] strings = endpoint.ToString().Split(new char[1] { ':' });
                var response = next(request, context);

                Console.WriteLine("调用成功！服务端的InvokeHandler:" + response);

                return response;
            };
            service.Use(ioHandler);

            //service.Use(myInvokeHandler);
            //service.AddInstanceMethods(new ServiceInfo1());//添加第二个服务
            System.Console.WriteLine("Server listening at http://localhost:10240/ n Press any key exit ...");
            Console.ReadLine();
            server.Stop();


        }

        /// <summary>
        /// 获得请求报文转换成字符串
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string getRequestBody(Stream request)
        {
            string result = "";
            using (Stream st = request)
            {
                StreamReader sr = new StreamReader(st, Encoding.UTF8);
                result = sr.ReadToEnd();
            }
            return result;
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
