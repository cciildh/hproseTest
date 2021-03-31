
namespace RedCardServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCitiid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBithday = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSexName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNation = new System.Windows.Forms.TextBox();
            this.btnRedCard = new System.Windows.Forms.Button();
            this.btnCler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(123, 30);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(245, 29);
            this.txtName.TabIndex = 1;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "身份证：";
            // 
            // txtCitiid
            // 
            this.txtCitiid.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCitiid.Location = new System.Drawing.Point(123, 78);
            this.txtCitiid.Name = "txtCitiid";
            this.txtCitiid.ReadOnly = true;
            this.txtCitiid.Size = new System.Drawing.Size(245, 29);
            this.txtCitiid.TabIndex = 1;
            this.txtCitiid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCitiid_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "出生日期：";
            // 
            // txtBithday
            // 
            this.txtBithday.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBithday.Location = new System.Drawing.Point(123, 131);
            this.txtBithday.Name = "txtBithday";
            this.txtBithday.ReadOnly = true;
            this.txtBithday.Size = new System.Drawing.Size(245, 29);
            this.txtBithday.TabIndex = 1;
            this.txtBithday.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBithday_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "住址：";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.Location = new System.Drawing.Point(123, 187);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(245, 29);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAddress_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(22, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "性别：";
            // 
            // txtSexName
            // 
            this.txtSexName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSexName.Location = new System.Drawing.Point(123, 237);
            this.txtSexName.Name = "txtSexName";
            this.txtSexName.Size = new System.Drawing.Size(245, 29);
            this.txtSexName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(22, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "名族：";
            // 
            // txtNation
            // 
            this.txtNation.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNation.Location = new System.Drawing.Point(123, 285);
            this.txtNation.Name = "txtNation";
            this.txtNation.Size = new System.Drawing.Size(245, 29);
            this.txtNation.TabIndex = 1;
            // 
            // btnRedCard
            // 
            this.btnRedCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRedCard.Location = new System.Drawing.Point(76, 367);
            this.btnRedCard.Name = "btnRedCard";
            this.btnRedCard.Size = new System.Drawing.Size(75, 29);
            this.btnRedCard.TabIndex = 2;
            this.btnRedCard.Text = "读卡";
            this.btnRedCard.UseVisualStyleBackColor = true;
            this.btnRedCard.Click += new System.EventHandler(this.btnRedCard_Click);
            // 
            // btnCler
            // 
            this.btnCler.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCler.Location = new System.Drawing.Point(234, 367);
            this.btnCler.Name = "btnCler";
            this.btnCler.Size = new System.Drawing.Size(75, 29);
            this.btnCler.TabIndex = 2;
            this.btnCler.Text = "清屏";
            this.btnCler.UseVisualStyleBackColor = true;
            this.btnCler.Click += new System.EventHandler(this.btnCler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.btnCler);
            this.Controls.Add(this.btnRedCard);
            this.Controls.Add(this.txtNation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSexName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBithday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCitiid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "广水市城郊卫生院读卡服务";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCitiid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBithday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSexName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNation;
        private System.Windows.Forms.Button btnRedCard;
        private System.Windows.Forms.Button btnCler;
    }
}

