using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedCardCor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRedCard_Click(object sender, EventArgs e)
        {
           var result=  RedCardCITIID.ReadCard();

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


    }
}
