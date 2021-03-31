
namespace RedCardCor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRedCard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCitiid = new System.Windows.Forms.TextBox();
            this.txtBithday = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSexName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNation = new System.Windows.Forms.TextBox();
            this.btnCler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRedCard
            // 
            this.btnRedCard.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRedCard.Location = new System.Drawing.Point(75, 318);
            this.btnRedCard.Name = "btnRedCard";
            this.btnRedCard.Size = new System.Drawing.Size(93, 36);
            this.btnRedCard.TabIndex = 0;
            this.btnRedCard.Text = "读卡";
            this.btnRedCard.UseVisualStyleBackColor = true;
            this.btnRedCard.Click += new System.EventHandler(this.btnRedCard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名：";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(171, 23);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(250, 32);
            this.txtName.TabIndex = 2;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "身份证号码：";
            // 
            // txtCitiid
            // 
            this.txtCitiid.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCitiid.Location = new System.Drawing.Point(171, 65);
            this.txtCitiid.Name = "txtCitiid";
            this.txtCitiid.ReadOnly = true;
            this.txtCitiid.Size = new System.Drawing.Size(250, 32);
            this.txtCitiid.TabIndex = 2;
            this.txtCitiid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCitiid_MouseClick);
            // 
            // txtBithday
            // 
            this.txtBithday.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBithday.Location = new System.Drawing.Point(171, 110);
            this.txtBithday.Name = "txtBithday";
            this.txtBithday.ReadOnly = true;
            this.txtBithday.Size = new System.Drawing.Size(250, 32);
            this.txtBithday.TabIndex = 2;
            this.txtBithday.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBithday_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "出身时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(32, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "住址：";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.Location = new System.Drawing.Point(171, 157);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(250, 32);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAddress_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(32, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "性别：";
            // 
            // txtSexName
            // 
            this.txtSexName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSexName.Location = new System.Drawing.Point(171, 200);
            this.txtSexName.Name = "txtSexName";
            this.txtSexName.Size = new System.Drawing.Size(250, 32);
            this.txtSexName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(30, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "名族：";
            // 
            // txtNation
            // 
            this.txtNation.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNation.Location = new System.Drawing.Point(171, 252);
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(250, 32);
            this.txtNation.TabIndex = 2;
            // 
            // btnCler
            // 
            this.btnCler.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCler.Location = new System.Drawing.Point(266, 318);
            this.btnCler.Name = "btnCler";
            this.btnCler.Size = new System.Drawing.Size(93, 36);
            this.btnCler.TabIndex = 0;
            this.btnCler.Text = "清屏";
            this.btnCler.UseVisualStyleBackColor = true;
            this.btnCler.Click += new System.EventHandler(this.btnCler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 366);
            this.Controls.Add(this.txtNation);
            this.Controls.Add(this.txtSexName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBithday);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCler);
            this.Controls.Add(this.btnRedCard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCitiid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "身份证读卡功能";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCitiid;
        private System.Windows.Forms.TextBox txtBithday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSexName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNation;
        private System.Windows.Forms.Button btnCler;
    }
}

