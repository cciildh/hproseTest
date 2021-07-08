using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using webAPItest.output;

namespace webAPItest.Controllers
{
    [Route("Pass")]
    [ApiController]
    public class DtCodeController : ControllerBase
    {
        [HttpPost]
        [Route("DictDept")]
        //[Consumes("application/xml")]
        //[Produces("application/xml")]
        public outDictDept.MESSAGE DictDept(input.inDictDept.Request dictDept)
        {
            //outDictDept.MESSAGE
            var result = service.QueryDtCode.QueryDictDept();
            //return MESSAGE<outDictDept>.ResponseOk(result.Count, result);
            //var msg = MESSAGE.ResponseOk(result.Count, result);

            //MESSAGE msg = new MESSAGE();
            //msg.ReturnCode = result.Count;
            //msg.ErrorMessage = "ok";
            //data data = new data();
            //List<row<outDictDept>> list = new List<row<outDictDept>>();

            //data.Rows = list;
            //msg.Data = data;

            var msg = outDictDept.MESSAGE.RespsoneOK(result.Count,"ok", result);
            //var b= B.New("123");
            return msg;
        }


        public class A<T>
        {
            public T name { get; set; }
        }

        public class B: A<string>
        {
            public B() { }
            public B(string na) {
                this.name = na;
            }

            public static B New(string name) => new B(name);
        }
    }
}
