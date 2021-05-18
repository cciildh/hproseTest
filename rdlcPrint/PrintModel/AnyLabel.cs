using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdlcPrint.PrintModel
{
   public class AnyLabel
    {
        public string LabelName { get; set; }
        public string Remark { get; set; }
        public List<AnyItem> Items { get; set; }
    }
}
