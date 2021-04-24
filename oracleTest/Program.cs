using System;
using System.Data;

namespace oracleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

           

            //查询不需要开事务
            OracleDataBse oracle1 = new OracleDataBse();
            DataTable dt = new DataTable();
            oracle1.RunSQL("select * from pa_info where pa_info.cliniccardid='0009527' ", out dt);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dt));

            Console.ReadLine();

        }

        public void  insert()
        {
            //打开事务
            OracleDataBse oracle = new OracleDataBse(true);
            try
            {
                //执行sql
                oracle.RunSQL("insert into pa_info .....");
                //提交事务
                oracle.Close(true);
            }
            catch (Exception)
            {
                //回滚事务
                oracle.Close(false);
                throw;
            }
           
        }
    }
}
