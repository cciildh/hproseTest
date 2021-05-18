using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rdlcPrint
{
   public class PaInfo
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public PaInfo(string name,string age)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
