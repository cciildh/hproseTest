using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using webAPItest.output;

namespace webAPItest
{
    [DataContract(Name = "MESSAGE", Namespace= "webAPItest")]
    //[Serializable]
    public class Respsone<T>
    {
        [DataMember]
        public int ReturnCode { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public data Data { get; set; }
        public class data
        {
            [DataMember]
            public T Rows { get; set; }
        }
        //public Respsone()
        //{
        //}
        //public Respsone(int returnCode, string errorMessage, T data)
        //{
        //    this.ReturnCode = returnCode;
        //    this.ErrorMessage = errorMessage;
        //    data data1 = new data();
        //    data1.Rows = data;
        //    this.Data = data1;
        //}

        //public Respsone<T> ResponseOk(int returnCode, T data) => new Respsone<T>(returnCode, "ok", data);

        //public Respsone<T> ResponseOk(int returnCode, string errorMessage, T data) => new Respsone<T>(returnCode, errorMessage, data);
        public void ResponseOk(int returnCode, string errorMessage, T data)
        {
            this.ReturnCode = returnCode;
            this.ErrorMessage = errorMessage;
            data data1 = new data();
            data1.Rows = data;
            this.Data = data1;
        }

    }


}
