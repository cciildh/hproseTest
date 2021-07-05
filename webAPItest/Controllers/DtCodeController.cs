using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPItest.output;

namespace webAPItest.Controllers
{
    [Route("Pass")]
    [ApiController]
    public class DtCodeController : ControllerBase
    {
        [HttpPost]
        [Route("DictDept")]
        public List<outDictDept> DictDept()
        {
            var result = service.QueryDtCode.QueryDictDept();
            return result;
        }
    }
}
