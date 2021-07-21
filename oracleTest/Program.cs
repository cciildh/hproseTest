using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
            oracle1.RunSQL("select  pa_info.patiname, pa_info.sexname ,null items from pa_info  where pa_info.cliniccardid='0009527' ", out dt);

            painfo info = TableToEntity<painfo>(dt);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            Console.ReadLine();

        }
        public static T TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            DataRow row = dt.Rows[0];
            PropertyInfo[] pArray = type.GetProperties();
            T entity = new T();
            foreach (PropertyInfo p in pArray)
            {
                if (row.Table.Columns.Contains(p.Name))//判断row 是否存在指定列
                {
                    if (p.PropertyType.Name == "Int32")
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    if (p.PropertyType.Name == "Decimal")
                    {
                        p.SetValue(entity, Convert.ToDecimal(row[p.Name]), null);
                        continue;
                    }
                    if (p.PropertyType.Name == "String")
                    {
                        p.SetValue(entity, row[p.Name].ToString(), null);
                    }
                }
                else
                {
                    if (p.PropertyType.Name == "String")
                    {
                        p.SetValue(entity, "", null);
                    }
                }
            }


            return entity;
        }

        public static List<T> TableToListEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (p.PropertyType.Name == "Int32")
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    if (p.PropertyType.Name == "Decimal")
                    {
                        p.SetValue(entity, Convert.ToDecimal(row[p.Name]), null);
                        continue;
                    }
                    //if (string.IsNullOrEmpty(row[p.Name].ToString()))
                    //{
                    //    continue;
                    //}

                    p.SetValue(entity, row[p.Name].ToString(), null);
                }
                list.Add(entity);
            }
            return list;
        }

        public void insert()
        {
            //打开事务
            OracleDataBse oracle = new OracleDataBse(true);
            try
            {
                //执行sql
                oracle.RunSQL("insert into pa_info .....");

                oracle.RunSQL("insert into pa_account .....");

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
