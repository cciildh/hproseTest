using System;
using System.Collections.Generic;
using System.Text;

namespace testObjctToXml
{
    public class testT
    {

        //public static testT New<T>(T dt)
        //{
        //    testT test1 = new testT();
        //    testT<T> test = new testT<T>();
        //    test.Rows = dt;
        //}
    }
    public class testT<T>
    {
        public T Rows { get; set; }
    }
        //public class testT
        //{
        //    public dynamic Rows { get; set; }

        //    public testT() { }
        //    public testT(dynamic row) { this.Rows = row; }

        //    public static testT New(dynamic row) => new testT(row);
        //}
    }
