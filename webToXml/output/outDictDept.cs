using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace webToXml.output
{
    //[DataContract(Name = "Row")]
    public class outDictDept
    {
        public string hiscode { get; set; }
        public string deptcode { get; set; }
        public string deptname { get; set; }
        public string parentname { get; set; }
        public string is_clinic { get; set; }
        public string is_inhosp { get; set; }
        public string is_emergency { get; set; }
    }
}
