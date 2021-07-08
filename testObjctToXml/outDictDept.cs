using System;
using System.Collections.Generic;
using System.Text;

namespace testObjctToXml
{
    public class outDictDept
    {
        public string hiscode { get; set; }
        public string deptcode { get; set; }
        public string deptname { get; set; }
        public string parentname { get; set; }
        public string is_clinic { get; set; }
        public string is_inhosp { get; set; }
        public string is_emergency { get; set; }

        //public outDictDept() { }

        //public outDictDept(string deptCode, string deptNmae ) {
        //    this.hiscode = "0";
        //    this.deptcode = deptCode;
        //    this.deptname = deptNmae;
        //    this.parentname = "";
        //    this.is_clinic = "0";
        //    this.is_inhosp = "0";
        //    this.is_emergency = "0";
        //}


        //public static outDictDept New(string deptCode, string deptNmae) => new outDictDept(deptCode, deptNmae);

        public class Row:outDictDept
        {
            public Row() { }

            public Row(string deptCode, string deptNmae)
            {
                this.hiscode = "0";
                this.deptcode = deptCode;
                this.deptname = deptNmae;
                this.parentname = "";
                this.is_clinic = "0";
                this.is_inhosp = "0";
                this.is_emergency = "0";
            }


            public static Row New(string deptCode, string deptNmae) => new Row(deptCode, deptNmae);
        }
    }

  
}
