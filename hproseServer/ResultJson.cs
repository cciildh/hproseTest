using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hproseServer
{
    class ResultJson
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }

        public object RelsultData { get; set; }

        protected ResultJson(string resultCode, string Msg, object data)
        {
            this.ResultCode = resultCode;
            this.ResultMessage = Msg;
            this.RelsultData = data;
        }
        public static string RespsonseOk(object data) => Newtonsoft.Json.JsonConvert.SerializeObject(new ResultJson("0", "ok", data)) ;
    }
}
