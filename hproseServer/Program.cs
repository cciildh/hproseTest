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
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:10240/");
            server.Start();
            var service = new Service().Bind(server).AddInstanceMethods(new Hello()).AddInstanceMethods(new Hello1());

            System.Console.WriteLine("Server listening at http://localhost:10240/ n Press any key exit ...");
            Console.ReadLine();
            server.Stop();
        }


    }
    public class Hello1
    {
        public string GetNmae()
        {
            return "李嘉诚";
        }

        
    } 

    public class Hello : IHello
    {
        public string GetVersion()
        {
            var result = new ServiceVersion("果果", "v0.2.2.2");

            Console.WriteLine("server Version: {0} - v{1}", result.Name, result.Version);
            return Newtonsoft.Json.JsonConvert.SerializeObject( result); 
        }

        public string Print(string name)
        {
            return $"果果跟小棒子搞基在Hello { name} !";
        }

        public List<string> SayHello(string name)
        {
            return new List<string>()
            {
                $"欢迎{name}到此一游！",
                $"小胖子约{name}搞基"
            };
        }

        public string SetVersion(ServiceVersion version)
        {
            return ResultJson.RespsonseOk(version);
        }
    }

    public class ServiceVersion
    {
        public object Name { get; set; }
        public object Version { get; set; }

        public ServiceVersion() { }

        public ServiceVersion(object name, object ver)
        {
            Name = name;
            Version = ver;
        }
    }

    // 服务接口
    public interface IHello
    {
        string Print(string name);
        string GetVersion();

        string SetVersion(ServiceVersion version);
        List<string> SayHello(string name);
    }


}
