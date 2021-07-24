using System;
using System.Collections.Generic;
using System.Text;

namespace NsqConsumer
{
   public class ConsumerInfo
    {
        public string EmpName { get; set; }
        public string SexName { get; set; }
        public string Address { get; set; }

        public ConsumerInfo() { }
        public ConsumerInfo(string name, string sex,  string addr)
        {
            this.Address = addr;
            this.SexName = name;
            this.SexName = sex;
        }

        public static ConsumerInfo New(string name, string sex, string addr) => new ConsumerInfo(name, sex, addr);

        public string ToJson() => Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
}
