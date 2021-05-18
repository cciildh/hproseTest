using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdlcPrint
{
  public  class PrintService
    {
        public dynamic PrintNameValue(PrintModel.AnyLabel input)
        {
            try
            {
                var doc = ReportRDLC.AnyPrint.Create().SetData(input);
                doc.Print();
                doc = null;
                return new { status = true, message = "打印成功" };
            }
            catch (Exception Ex)
            {
                return new { status = false, message = $"打印失败，错误信息：{Ex.Message}" };
            }
        }

        public string GetNmae()
        {
            return "李嘉诚";
        }
    }
}
