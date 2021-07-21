using System;
using System.Collections.Generic;
using System.Text;

namespace oracleTest
{
   public class painfo
    {
        public string patiname { get; set; }
        public string sexname { get; set; }
        public int age { get; set; }
        public string addres { get; set; }
        public List<Item> items { get; set; }

        public class Item
        {
            public string aaa { get; set; }
            public int amount { get; set; }
        }
    }
}
