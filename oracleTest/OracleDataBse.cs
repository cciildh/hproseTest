using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace oracleTest
{
    public class OracleDataBse
    {
        //联接串，实例化时指定，否则从ConnectionString类的属性中取得 
        private const string strConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=114.116.11.82)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=dbhis;Password=dbhis;";

        // 连接数据源 
        private OracleConnection con;
        //数据更新器 
        private OracleDataAdapter sda;

        //是否使用事务 
        private bool isTransaction = false;
        //事务 
        private OracleTransaction transaction;
 
        public OracleDataBse()
        {
            isTransaction = false;
        }
        ///  
        /// 使用事务 
        ///  
        /// true则使用事务 
        public OracleDataBse (bool beginTransaction)
        {
            isTransaction = beginTransaction;
        }

        ///  
        /// 打开数据库连接. 
        ///  
        public void Open()
        {
            // 打开数据库连接 
            if (con == null)
            {
                con = new OracleConnection(strConnectionString);
            }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
                if (isTransaction == true)
                {
                    transaction = con.BeginTransaction();//定义事务 
                }
            }
        }

        ///  
        /// 执行SQL语句,慎用,尽可能使用存储过程 
        ///  
        ///  
        ///  
        public int RunSQL(string SQLString)
        {
            int i = 0;

            // 确认打开连接 
            Open();
            try
            {
                OracleCommand cmd = new OracleCommand(SQLString, con);
                cmd.CommandType = CommandType.Text;
                if (transaction != null && isTransaction == true)
                    cmd.Transaction = transaction;
                object obj = cmd.ExecuteScalar();

                if (isTransaction == false)
                    this.Close();
                if (obj != null)
                {
                    i = Convert.ToInt32(obj);
                    return i;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
            
                throw e;
            }
            finally
            {
                Close();
            }
            //return i;
        }
        ///  
        /// 执行SQL语句,慎用,尽可能使用存储过程.以参数dt返回结果集 
        ///  
        /// SQL语句 
        /// 结果集 
        ///  
        public void RunSQL(string SQLString, out DataTable dt)
        {
            // 确认打开连接 
            Open();
            try
            {
                OracleCommand cmd = new OracleCommand(SQLString, con);
                cmd.CommandType = CommandType.Text;
                if (transaction != null && isTransaction == true)
                    cmd.Transaction = transaction;
                sda = new OracleDataAdapter(cmd);

                dt = new DataTable();
                sda.Fill(dt);
                if (isTransaction == false) this.Close();
            }
            catch (Exception e)
            {
                dt = null;
                throw e;
            }
            finally
            {
                Close();
            }
        }


        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (!isTransaction)
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        ///  
        /// 提交或撤消更改并关闭数据库连接 
        ///  
        /// True则提交,否则撤消 
        public void Close(bool commit)
        {
            if (transaction != null)
            {
                if (commit == true)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
            Close();
        }


    }
}
