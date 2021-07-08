using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace webToXml
{
    //[DataContract(Name = "MESSAGE")]
    public class MESSAGE
    {
        public int ReturnCode { get; set; }

        public string ErrorMessage { get; set; }

        public data Data { get; set; }
        //[DataContract(Name = "Data", Namespace = "webToXml")]
        public class data
        {
            public object Rows { get; set; }
        }

        public MESSAGE() { }

        public MESSAGE(int code, string msage, object rows)
        {
            this.ReturnCode = code;
            this.ErrorMessage = msage;
            data data1 = new data();
            data1.Rows = rows;
            this.Data = data1;
        }

        public static MESSAGE ResponseOk(int code, object rows) => new MESSAGE(code, "ok", rows);

    }
}

