using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace webAPItest.input
{
    [DataContract(Name = "inDictDept", Namespace = "webAPItest")]
    [XmlRoot("inDictDept")]
    public class inDictDept
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int age { get; set; }

        public class Request: inDictDept
        {

        }

    }
}
