using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace rdlcPrint.ReportRDLC
{
    public class ReportPrint
    {
        /// <summary>
        /// 报表文件路径名
        /// </summary>
        public string ReportPath { get; set; }

        /// <summary>
        /// 使用的打印机名称，没有的时候使用默认
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 报表对象
        /// </summary>
        public LocalReport localReport { get; set; }

        public ReportPrint Create(string path, string printerName)
        {
            return new ReportPrint(path, printerName);
        }

        public ReportPrint(string path, string printerName)
        {
            ReportPath = path;
            PrinterName = printerName;
            localReport = new LocalReport();
        }



        //private BindingSource invoicePBillOutpatientRequestBindingSource;
        //private BindingSource chargeDetailBindingSource;

        //private ReportDataSource reportDataSource1 = new ReportDataSource();
        //private ReportDataSource reportDataSource2 = new ReportDataSource();

        //ReportDataSource[] reportDataSources;//= new ReportDataSource[]();
        //BindingSource[] bindingSources;


        public void Init()
        {
            //localReport = new LocalReport();
            //reportDataSource1.Name = "DataSet1";
            //reportDataSource1.Value = this.invoicePBillOutpatientRequestBindingSource;
            //reportDataSource2.Name = "DataSet2";
            //reportDataSource2.Value = this.chargeDetailBindingSource;



            //this.invoicePBillOutpatientRequestBindingSource.DataSource = typeof(Dentist.BSModel.invoicePBillOutpatientRequest);

            //this.chargeDetailBindingSource.DataSource = typeof(Dentist.BSModel.chargeDetail);
            //this.localReport.ReportEmbeddedResource = "Dentist.LocalPrint.RecipeTemplate.rdlc";
            //this.localReport.DataSources.Add(reportDataSource1);
            //this.localReport.DataSources.Add(reportDataSource2);
            //localReport.Refresh();

        }

        public void Print()
        {
            AutoPrintCls autoPrintCls = new AutoPrintCls(this.localReport);
            if (this.PrinterName != string.Empty)
            {
                autoPrintCls.PrinterSettings.PrinterName = this.PrinterName;
            }


            //autoPrintCls.DefaultPageSettings.Landscape = false;
            autoPrintCls.Print();

            autoPrintCls.Dispose();
        }


        /// <summary>
        /// 生成一维条形码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public Bitmap Generate2(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            EncodingOptions options = new EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        public byte[] BitMapToByte(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            byte[] img = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(img, 0, Convert.ToInt32(ms.Length));
            ms.Close();
            return img;
        }
    }
}
