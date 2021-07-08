using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace testObjctToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var infos = new List<outDictDept.Row>();
            infos.Add(outDictDept.Row.New("0001", "门诊小儿科"));
            infos.Add(outDictDept.Row.New("0002", "门诊保健科"));

            var mesg = MESSAGE<List<outDictDept.Row>>.ResponseOk(infos.Count, infos);
            var result = XmlConvert.SerializeObject(mesg);

            Console.WriteLine(result);
            Console.ReadLine();
        }

     
    }
}
