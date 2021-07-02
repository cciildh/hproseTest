using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string DataBuffer;
        /// <summary>
        /// 定点医疗机构名称
        /// </summary>
        public const string HospitalName = "信阳市第一人民医院";
        /// <summary>
        /// 定点医疗机构编码 (调用测试接口得使用测试999999)
        /// </summary>
        //public string Const HospitalNo  = "999999"

        public const string HospitalNo = "10100030";
        /// <summary>
        /// 定点医疗机构等级
        /// </summary>
        public const string HospitalGrade = "02";
        /// <summary>
        /// 中心编码
        /// </summary>
        public const string CenterNo = "0000";


        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BusinessCycleNo = "";
        /// <summary>
        /// 医院交易流水号(发送方交易流水号最大30位)
        /// </summary>
        public string HisTranSerialNo = "";

        /// <summary>
        /// 操作员
        /// </summary>
        public string EmpId = "8004";

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            HisTranSerialNo = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000) + 1).ToString();
            try
            {
                if (C_Init() == true)
                {
                    MessageBox.Show("  初始化 成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("  初始化失败！" + ex.Message);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            HisTranSerialNo = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000) + 1).ToString();
            try
            {
                if (!C_Init())
                {
                    throw new Exception("初始化失败！");
                }
                if (!C_SignIn("1", "信息中心"))
                    throw new Exception("医保签到失败！");

                BusinessCycleNo = DataBuffer.ToString().Split('|').GetValue(0).ToString();
                MessageBox.Show(" 医保签到成功！医保业务周期号：" + BusinessCycleNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 医保签到失败！" + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            HisTranSerialNo = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000) + 1).ToString();
            try
            {
                if (!C_Init())
                {
                    throw new Exception("初始化失败！");
                }
                //BusinessCycleNo = "001010003000008004202106191725307810";
                if (!C_SignOut(BusinessCycleNo))
                    throw new Exception("医保签退失败！");

                BusinessCycleNo = DataBuffer.ToString().Split('|').GetValue(0).ToString();
                MessageBox.Show(" 医保签退成功！医保业务周期号：" + BusinessCycleNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 医保签退失败！" + ex.Message);
            }
        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            HisTranSerialNo = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000) + 1).ToString();
            StringBuilder outResult = new StringBuilder(2048);
            var strIn = string.Empty;
            var strReSult = $@"931000^{ HospitalNo}^{EmpId}^{BusinessCycleNo}^{HisTranSerialNo}^{CenterNo}^{strIn}^";
            var intRet = CInsureShare_XYS.Business_Handle(strReSult, outResult);
            if (intRet == 0)
            {
                var PersonAccountInfoBuild = outResult.ToString().Split('^').GetValue(2).ToString();
                var DataBuffer = outResult.ToString().Split('^').GetValue(2).ToString();
                var PersonAccountInfo = outResult.ToString().Split('^').GetValue(1).ToString();
                if (DataBuffer.Length == 0)
                {
                    throw new Exception("读卡返回个人和帐户信息为空");
                }
            }
            else
            {
                throw new Exception($@"读卡失败:请检查通信是否有问题,({ DataBuffer })");
            }
        }
        /// <summary>
        /// 动态链接库初始化
        /// </summary>
        /// <returns></returns>
        public bool C_Init()
        {
            var InterfaceErr = "";
            try
            {
                var intRet = CInsureShare_XYS.Init(out InterfaceErr);
                if (intRet != 0)
                {
                    throw new Exception(InterfaceErr);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"动态连接库函数初始化调用异常报错{InterfaceErr}{ex.Message}");
            }
        }


        /// <summary>
        /// 签到(031100)
        /// </summary>
        /// <param name="SignType">类别 1 门诊 2 住院</param>
        /// <param name="OperName">经办人姓名</param>
        /// <returns></returns>
        public bool C_SignIn(string SignType, string OperName)
        {
            try
            {
                StringBuilder outResult = new StringBuilder();

                var strIn = $@"{SignType}|{OperName}|";
                var strReSult = $@"031100^{HospitalNo}^{EmpId}^{BusinessCycleNo}^{HisTranSerialNo}^{CenterNo}^{strIn}^";

                var intRet = CInsureShare_XYS.Business_Handle(strReSult, outResult);
                if (intRet != 0)
                {
                    return false;
                }
                DataBuffer = outResult.ToString().Trim().Split('^').GetValue(1).ToString();

                SaveLog("医保签到C_SignIn（）", strReSult, outResult.ToString(), "XYS_YB");
                //Marshal.FinalReleaseComObject();
                return true;
            }
            catch (Exception ex)
            {
                //签到请求方法调用异常报错
                throw ex;
            }
        }
        /// <summary>
        /// 签退(031110)
        /// </summary>
        /// <param name="PeriodNo">业务周期号</param>
        /// <returns></returns>
        public bool C_SignOut(string PeriodNo)
        {
            try
            {
                StringBuilder outResult = new StringBuilder();

                var strIn = $@"{PeriodNo}|";
                var strReSult = $@"031110^{HospitalNo}^{EmpId}^{BusinessCycleNo}^{HisTranSerialNo}^{CenterNo}^{strIn}^";
                var intRet = CInsureShare_XYS.Business_Handle(strReSult, outResult);
                if (intRet != 0)
                {
                    return false;
                }

                DataBuffer = outResult.ToString().Trim().Split('^').GetValue(1).ToString();
                SaveLog("医保签退C_SignOut（）", strReSult, outResult.ToString(), "XYS_YB");
                return true;
            }
            catch (Exception ex)
            {
                //签退请求方法调用异常报错
                throw ex;
            }
        }
        /// <summary>
        /// 读卡(931000)
        /// </summary>
        /// <param name="LineMakeer"></param>
        /// <returns></returns>
        /// <remarks>读卡(2100)</remarks>
        public bool C_ReadCard(string LineMakeer)
        {
            try
            {
                //var mDataBuffer = ReturnValueString(8048);
                StringBuilder outResult = new StringBuilder();
                var strIn = string.Empty;
                var strReSult = $@"931000^{ HospitalNo}^{EmpId}^{BusinessCycleNo}^{HisTranSerialNo}^{CenterNo}^{strIn}^";
                var intRet = CInsureShare_XYS.Business_Handle(strReSult, outResult);
                if (intRet == 0)
                {
                    var PersonAccountInfoBuild = outResult.ToString().Split('^').GetValue(2).ToString();
                    DataBuffer = outResult.ToString().Split('^').GetValue(2).ToString();
                    var PersonAccountInfo = outResult.ToString().Split('^').GetValue(1).ToString();
                    //DataBuffer = outResult.ToString();
                    if (DataBuffer.Length == 0)
                    {
                        throw new Exception("读卡返回个人和帐户信息为空");
                    }
                }
                else
                {
                    throw new Exception($@"读卡失败:请检查通信是否有问题,({ DataBuffer })");
                }
                SaveLog("读卡C_ReadCard（）", strReSult, outResult.ToString(), "XYS_YB");
                return true;
            }
            catch (Exception ex)
            {
                //SaveLogFile("读卡请求方法调用异常报错", "", ex.Message)
                throw new Exception($@"读卡请求方法调用异常报错{ex.Message}");
            }
        }
        #region "自定义方法"
        protected StringBuilder ReturnValueString()
        {
            return new StringBuilder();
        }

        public static void SaveLog(string MethodID, string data, string result, string type)
        {
            string[] strLog = { "", "", "", "", "" };
            strLog[0] = "MethodID：" + MethodID;
            strLog[1] = "data：" + data;
            strLog[2] = "result：" + result;
            string path = @"D:\YuanTULog";
            if (Directory.Exists(path) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(path);
            }
            if (!System.IO.File.Exists(path + "/" + DateTime.Today.ToString("yyyyMMdd") + type + ".txt"))
            {
                FileStream fs1 = new FileStream(path + "/" + DateTime.Today.ToString("yyyyMMdd") + type + ".txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                foreach (var item in strLog)
                {
                    sw.WriteLine(item);//开始写入值
                }
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(path + "/" + DateTime.Today.ToString("yyyyMMdd") + type + ".txt" + "", FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                foreach (var item in strLog)
                {
                    sr.WriteLine(item);//开始写入值
                }
                sr.Close();
                fs.Close();
            }
        }
        #endregion

        private static IntPtr ToIntptr(String strData)
        {
            byte[] btData = System.Text.Encoding.Default.GetBytes(strData);
            IntPtr m_ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(btData.Length);
            byte[] btZero = new byte[btData.Length + 1];
            System.Runtime.InteropServices.Marshal.Copy(btZero, 0, m_ptr, btZero.Length);
            System.Runtime.InteropServices.Marshal.Copy(btData, 0, m_ptr, btData.Length);
            return m_ptr;
        }


    }
}
