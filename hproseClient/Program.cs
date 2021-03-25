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
            Client cli = new Client("http://localhost:10240/");
            IHello hello = cli.UseService<IHello>();

            var ver = hello.GetVersion().ToString();
            //System.Console.WriteLine("Remote Service Version: {0} - v{1}", ver.name, ver.version);
            var hellop = hello.Print("李嘉城");
            Console.WriteLine(hellop);
            var hellos = hello.SayHello("果果");

            foreach (string item in hellos)
            {
                System.Console.WriteLine(item);
            }

            System.Console.ReadKey();
        }
    }
    public class ServiceVersion
    {
        public string name { get; set; }
        public string version { get; set; }
    }
    public interface IHello
    {
        string Print(string name);
        string GetVersion();
        List<string> SayHello(string name);
    }
}
