using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdlcPrint
{
    public partial class FormLocalResources : Form
    {
        private NotifyIcon notifyIcon = new NotifyIcon { Text = "信阳市第一人民医院集成平台本地服务" };

        private LocalService server;
        private void InitService()
        {
            server = new LocalService();
            server.Start();
        }
        public FormLocalResources()
        {
            InitializeComponent();
        }
        private void FormLocalResources_Load(object sender, EventArgs e)
        {
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            this.WindowState = FormWindowState.Minimized;
            txtPort.Text = Properties.Settings.Default.URL;
            InitService();
        }
  

        private void FormLocalResources_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //托盘显示图标等于托盘图标对象 
                //注意notifyIcon1是控件的名字而不是对象的名字 
                notifyIcon.Icon = this.Icon;
                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区 
                notifyIcon.Visible = true;
            }
        }


        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyIcon.Visible = false;
            }
        }

        private void FormLocalResources_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            server.Stop();
            server.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
