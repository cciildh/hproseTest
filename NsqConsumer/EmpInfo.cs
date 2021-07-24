using System;
using System.Collections.Generic;
using System.Text;

namespace NsqConsumer
{
    public class EmpInfo
    {
        public string Name { get; set; }
        public string SexName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public EmpInfo(string name, string sex, int age, string addr)
        {
            this.Address = addr;
            this.Age = age;
            this.Name = name;
            this.SexName = sex;
        }

        public static EmpInfo New(string name, string sex, int age, string addr) => new EmpInfo(name, sex, age, addr);

        public string ToJson() => Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
}
