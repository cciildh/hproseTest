using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webToXml.Controllers
{
    [Route("Pass")]
    [ApiController]
    public class DtCodeController : ControllerBase
    {
        [HttpPost]
        [Route("DictDept")]
        //[Consumes("application/xml")]
        //[Produces("application/xml")]
        public MESSAGE DictDept()
        {
            var result = service.QueryDtCode.QueryDictDept();

            var msg = MESSAGE.ResponseOk(result.Count, result);

            return msg;
        }
    }
}
