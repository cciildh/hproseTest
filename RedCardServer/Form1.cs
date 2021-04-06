using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedCardServer
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon = new NotifyIcon { Text = "广水市城郊卫生院集成平台本地服务" };
        public Form1()
        {
            InitializeComponent();
        }
        int state;
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            //this.WindowState = FormWindowState.Minimized;
            int x = SystemInformation.PrimaryMonitorSize.Width - this.Width;
            int y = SystemInformation.PrimaryMonitorSize.Height - this.Height;//要让窗体往上走 只需改变 Y的坐标
            this.Location = new Point(0, 0);
            this.TopMost = true;
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


        private void btnRedCard_Click(object sender, EventArgs e)
        {
            var result = RedCardCITIID.ReadCard();

            this.txtAddress.Text = result.Address;
            this.txtBithday.Text = result.Birthday;
            this.txtCitiid.Text = result.CitiID;
            this.txtName.Text = result.CardName;
            this.txtNation.Text = result.Nation;
            this.txtSexName.Text = result.CardSex;
        }

        private void btnCler_Click(object sender, EventArgs e)
        {
            this.txtAddress.Text = "";
            this.txtBithday.Text = "";
            this.txtCitiid.Text = "";
            this.txtName.Text = "";
            this.txtNation.Text = "";
            this.txtSexName.Text = "";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //托盘显示图标等于托盘图标对象 
                //WindowState = FormWindowState.Normal;
                //注意notifyIcon1是控件的名字而不是对象的名字 
                notifyIcon.Icon = this.Icon;
                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区 
                notifyIcon.Visible = true;
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtName.SelectAll();
        }

        private void txtCitiid_MouseClick(object sender, MouseEventArgs e)
        {
            txtCitiid.SelectAll();
        }

        private void txtBithday_MouseClick(object sender, MouseEventArgs e)
        {
            txtBithday.SelectAll();
        }

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            txtAddress.SelectAll();
        }
    }
}
