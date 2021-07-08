using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace webAPItest.output
{
    [DataContract(Name = "Row", Namespace = "webAPItest")]
    public class outDictDept
    {
        [DataMember]
        public string hiscode { get; set; }
        [DataMember]
        public string deptcode { get; set; }
        [DataMember]
        public string deptname { get; set; }
        [DataMember]
        public string parentname { get; set; }
        [DataMember]
        public string is_clinic { get; set; }
        [DataMember]
        public string is_inhosp { get; set; }
        [DataMember]
        public string is_emergency { get; set; }
        public class Row : outDictDept
        {

        }

        public class MESSAGE : Respsone<List<Row>>
        {
            public MESSAGE() { }
            public MESSAGE(int returnCode, string errorMessage, List<Row> data)
            {
                this.ResponseOk(returnCode, errorMessage, data);
            }

            public static MESSAGE RespsoneOK(int returnCode, string errorMessage, List<Row> data) => new MESSAGE(returnCode, errorMessage, data);

         
        }


    }
}
