using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdlcPrint.ReportRDLC
{
    /// <summary>
    /// 打印Name Value
    /// </summary>
    public class AnyPrint : ReportPrint
    {
        private BindingSource BindingSource1 = new BindingSource();

        private ReportDataSource reportDataSource1 = new ReportDataSource();

        public static AnyPrint Create()
        {
            //return new AnyPrint("LocalService.Xinyang.ReportRDLC.AnyLabel.rdlc", Properties.Settings.Default.BillPrinter);
            return new AnyPrint("rdlcPrint.ReportRDLC.AnyLabel.rdlc", "");
        }


        public AnyPrint(string path, string printerName) : base(path, printerName)
        {

        }

        public ReportPrint SetData(PrintModel.AnyLabel request)
        {
            //localReport = new LocalReport();
            BindingSource1 = new BindingSource();

            BindingSource1.DataSource = typeof(PrintModel.AnyItem);

            reportDataSource1 = new ReportDataSource("DataSet1", BindingSource1);

            foreach (var item in request.Items)
            {
                BindingSource1.Add(item);
            }

            this.localReport.ReportEmbeddedResource = ReportPath;// "Dentist.LocalPrint.ChargeTemplate.rdlc";

            this.localReport.DataSources.Add(reportDataSource1);

            ReportParameter para = new ReportParameter("ReportTitle", request.LabelName);
            localReport.SetParameters(para);

            localReport.Refresh();
            return this;
        }


    }
}
