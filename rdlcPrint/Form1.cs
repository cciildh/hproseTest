
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace rdlcPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LocalReport
            List<PaInfo> paInfos = new List<PaInfo>();
            paInfos.Add(new PaInfo("李嘉诚", "22"));
            paInfos.Add(new PaInfo("李嘉诚1", "23"));
            paInfos.Add(new PaInfo("李嘉诚2", "24"));

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "rdlcPrint.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", paInfos));

            ReportParameter parameter = new ReportParameter("telte1", "刀塔精英");
            this.reportViewer1.LocalReport.SetParameters(parameter);

            this.reportViewer1.RefreshReport();
        }
    }
}
