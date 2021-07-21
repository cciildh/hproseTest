using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            ApplicationDeployment.CurrentDeployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(UpdateProgress);
        }

        private void UpdateProgress(object sender, DeploymentProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = (e.BytesCompleted / 1024).ToString() + " of " +(e.BytesTotal / 1024).ToString() + " kb downloaded";
        }
    }
}
