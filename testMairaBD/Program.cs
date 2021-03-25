using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMairaBD
{
    class Program
    {

        static void Main(string[] args)
        {
            getQuery();

            //Console.WriteLine("-----------更新sql---------");

            //Console.WriteLine(insertTest());

            //Console.WriteLine("-----------end ---------");

            getQuery();

            Console.ReadLine();
        }

        public static MySqlConnection open()
        {
            var constr = "server=192.168.200.11;port=3306;database=tj;user=root;password=Sxadmin1;SslMode = none;";
            //var constr = "server=192.168.2.4;port=3306;database=firstDB;user=ldh;password=ldh;SslMode = none;";
            var conn = new MySqlConnection(constr);
            try
            {
                conn.Open();
                Console.WriteLine("连接成功!!!");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
           
            return conn;
        }

        public static void Close(MySqlConnection conn)
        {
            conn.Close();
            Console.WriteLine("正常关闭!!!");
        }

        public static string  insertTest()
        {
            MySqlConnection conn = open();
            var sql = " update std_emp set name='李加成' where id='10000' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var result = cmd.ExecuteNonQuery();
            Close(conn);

            return result.ToString();
        }

        public static void getQuery()
        {
            MySqlConnection conn = open();
            string sql = "SELECT * FROM base_item where item_id='1803120001'";
            //string sql = "SELECT * FROM std_emp";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
            Console.WriteLine("-----------查询结果---------");
            Console.WriteLine(result);
            Console.WriteLine("-----------end ---------");
            Close(conn);
        }
    }


}
