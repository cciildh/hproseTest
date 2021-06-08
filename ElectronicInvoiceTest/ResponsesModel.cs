using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicInvoiceTest
{
   public class ResponsesModel
    {
        /// <summary>
        /// 返回码200成功
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 同步成功
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据JSON格式
        /// </summary>
        public List<object> data { get; set; }
    }
}
