using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static ElectronicInvoiceTest.inputBillInfo;

namespace ElectronicInvoiceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GetMD5StringForCheck(string data)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] dataByte = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(data));
            StringBuilder sBuilder = new StringBuilder();
            dataByte.ToList().ForEach(_ => sBuilder.Append(_.ToString("X2")));
            return sBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetMD5StringForCheck("28CFF57B7B4A169B45577EF62A92A64FD8F8B9A5E4910687D55EE5E11C65169F132e4ef89ff44816b9200219274480d22020100119203312328CFF57B7B4A169B45577EF62A92A64F"));
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private string GetTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetTimeStamp());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EBillInterface a = new EBillInterface("items", string.Empty, "abcd", GetTimeStamp());
            string x = a.Trade();
            JavaScriptSerializer js = new JavaScriptSerializer();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputBillInfo billInfo = new inputBillInfo();
            billInfo.serialNumber = "0000000001";
            billInfo.theType = "1";
            billInfo.totalAmount = 100;
            billInfo.recName = "信阳市第一人民医院";
            billInfo.recAcct = string.Empty;
            billInfo.recOpBk = string.Empty;
            billInfo.payerPartyType = "1";
            billInfo.payerPartyCode = string.Empty;
            billInfo.payerPartyName = "测试患者1";
            billInfo.gender = "男";
            billInfo.payerAcct = string.Empty;
            billInfo.payerOpBk = string.Empty;
            billInfo.payMode = "1";
            billInfo.businessNumber = "T00002";
            billInfo.handlingPerson = "开票人";
            billInfo.checker = "复核人";
            billInfo.patientNumber = "MZ00002";
            billInfo.medicalDate = "2021-06-07";
            billInfo.orgType = "二级医院";
            billInfo.items = new List<FeesItem>();
            FeesItem fee1 = new FeesItem();
            FeesItem fee2 = new FeesItem();

            fee1.itemCode = "913001003";
            fee1.itemName = "化验费";
            fee1.itemQuantity = 1;
            fee1.itemStd = 0;
            fee1.itemUnit = "元";
            fee1.itemAmount = 50;
            fee1.itemRemark = string.Empty;

            fee2.itemCode = "913001009";
            fee2.itemName = "中成药费";
            fee2.itemQuantity = 1;
            fee2.itemStd = 0;
            fee2.itemUnit = "元";
            fee2.itemAmount = 35;
            fee2.itemRemark = string.Empty;

            billInfo.items.Add(fee1);
            billInfo.items.Add(fee2);
            JavaScriptSerializer js = new JavaScriptSerializer();
            EBillInterface a = new EBillInterface("invoice", js.Serialize(billInfo).Replace(":null", ":\"\""), "abcd1", GetTimeStamp());

            string x = a.Trade();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            EBillInterface a = new EBillInterface("cancellation", "{\"eInvoiceCode\":\"41060121\",\"eInvoiceNumber\":\"5305032105\",\"reason\":\"测试冲红\" }", "abcd", GetTimeStamp());

            string x = a.Trade();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();  // 5305032105 
            EBillInterface a = new EBillInterface("invoiceResult", "{\"eInvoiceCode\":\"41060121\",\"eInvoiceNumber\":\"5305032105\"}", "abcd", GetTimeStamp());

            string x = a.Trade();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            EBillInterface a = new EBillInterface("exchange", "{\"eInvoiceCode\":\"41060121\",\"eInvoiceNumber\":\"0004596305\",\"billBatchCode\":\"141060121\",\"billNo\":\"0000121601\"}", "abcd", GetTimeStamp());

            string x = a.Trade();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            EBillInterface a = new EBillInterface("obsoletePaper", "{\"billBatchCode\":\"141060121\",\"billNo\":\"0000121601\",\"reason\":\"测试作废纸质票据\"}", "abcd", GetTimeStamp());

            string x = a.Trade();
            ResponsesModel di = js.Deserialize<ResponsesModel>(x);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string txt = "";
            StreamReader sr = new StreamReader(@"c:\x.txt");

            string str = sr.ReadLine();
            txt += str + "\n";
            sr.Close();
            Base64StringToFile(txt, "aaa.pdf");

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";

            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Maximized,
                    UseShellExecute = true,
                    FileName = @"c:\aaa.pdf",//文件路径
                    Verb = "WindowsFormsApplication28",
                    Arguments = @"/p /h \" + @"c:\aaa.pdf" + "\"\"" + pd.PrinterSettings.PrinterName + "\""
                }
            };

        }

        /// <summary>
        /// Base64字符串转文件并保存
        /// </summary>
        /// <param name="base64String">base64字符串</param>
        /// <param name="fileName">保存的文件名</param>
        /// <returns>是否转换并保存成功</returns>
        public bool Base64StringToFile(string base64String, string fileName)
        {
            bool opResult = false;
            try
            {
                string strDate = DateTime.Now.ToString("yyyyMMdd");
                string fileFullPath = "C:\\";//文件保存路径
                if (!Directory.Exists(fileFullPath))
                {
                    Directory.CreateDirectory(fileFullPath);
                }

                string strbase64 = base64String.Trim().Substring(base64String.IndexOf(",") + 1);   //将‘，’以前的多余字符串删除
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(strbase64));
                FileStream fs = new FileStream(fileFullPath + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] b = stream.ToArray();
                fs.Write(b, 0, b.Length);
                fs.Close();

                opResult = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return opResult;
        }
    }
}
