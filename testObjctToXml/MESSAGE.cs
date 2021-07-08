using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testObjctToXml
{
    [XmlRoot("MESSAGE")]
    //DataContract
    public class MESSAGE<T>
    {
        [XmlElement("name")]
        public int ReturnCode { get; set; }

        public string ErrorMessage { get; set; }

        public Data<T> Data { get; set; }

        public MESSAGE()
        {
        }
        public MESSAGE(int returnCode, string errorMessage, T data)
        {
            this.ReturnCode = returnCode;
            this.ErrorMessage = errorMessage;
            Data<T> data1 = new Data<T>();
            data1.Rows = data;
            this.Data = data1;
        }

        public static MESSAGE<T> ResponseOk(int returnCode, T data) => new MESSAGE<T>(returnCode, "ok", data);
  
    }

    public class Data<T>
    {
        public T Rows { get; set; }
    }

    //public class Data: Data<T> {
    //    public override T Rows { get; set; }
    //}

}
