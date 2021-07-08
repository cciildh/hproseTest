using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace webToXml.comm
{
    public class DataTableUtils
    {
        /// <summary>
        /// datatable转对象
        /// </summary>
        /// <typeparam name="T">对象名称</typeparam>
        /// <param name="dt">dt数据</param>
        /// <returns></returns>
        public static List<T> TableToListEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            var errmsg = string.Empty;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    PropertyInfo[] pArray = type.GetProperties();
                    T entity = new T();
                    foreach (PropertyInfo p in pArray)
                    {
                        errmsg = p.Name + "：";
                        if (!dt.Columns.Contains(p.Name))
                        {
                            continue;
                        }
                        //if (p.PropertyType.Name is decimal )
                        //{
                        //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        //}
                        //if (row[p.Name] is long)
                        //{
                        //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        //    continue;
                        //}
                        //if (row[p.Name] is decimal)
                        //{
                        //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        //    continue;
                        //}
                        //if (string.IsNullOrEmpty(row[p.Name].ToString()))
                        //{
                        //    continue;
                        //}

                        p.SetValue(entity, row[p.Name].ToString(), null);
                    }
                    list.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(errmsg + ex.Message);
            }
            return list;
        }
        public static T TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            DataRow row = dt.Rows[0];
            PropertyInfo[] pArray = type.GetProperties();
            T entity = new T();
            var errmsg = string.Empty;
            try
            {
                foreach (PropertyInfo p in pArray)
                {
                    errmsg = p.Name + "："; ;
                    //判断table中是否有该列
                    if (!dt.Columns.Contains(p.Name))
                    {
                        continue;
                    }
                    //if (row[p.Name] is long)
                    //{
                    //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                    //    continue;
                    //}
                    //if (row[p.Name] is decimal)
                    //{
                    //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                    //    continue;
                    //}

                    p.SetValue(entity, row[p.Name].ToString(), null);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(errmsg + ex.Message);
            }


            return entity;
        }

    }
}
