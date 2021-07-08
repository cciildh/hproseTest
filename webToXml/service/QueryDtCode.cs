using oracleTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using webToXml.comm;
using webToXml.output;

namespace webToXml.service
{
    public class QueryDtCode
    {
        /// <summary>
        /// 2.1.1	科室字典信息
        /// </summary>
        /// <returns></returns>
        public static List<outDictDept> QueryDictDept()
        {
            try
            {
                var sql = "select '0' hiscode, ORGID deptcode, ORGNAME deptname, ''parentname ,1  is_clinic, 0 is_inhosp , 0 is_emergency from dt_org where orgid='01020C' ";
                var dt = CommRunSQL(sql);

                var dictDepts = DataTableUtils.TableToListEntity<outDictDept>(dt);

                return dictDepts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private static DataTable CommRunSQL(string SQL)
        {
            DataTable dt = new DataTable();
            //DataAccess.IDataAccess DataObj = DataAccess.DataFactory.GetInstance(DataAccess.InsureServer.STD_SERVER, false);
            //查询不需要开事务
            OracleDataBse DataObj = new OracleDataBse();
            try
            {
                DataObj.RunSQL(SQL, out dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DataObj.Close();
            }

            return dt;
        }
    }
}
