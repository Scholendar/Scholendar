namespace WindowsFormsApplication6
{
    partial class cartao
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetUID = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txbGetUIDd = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txbGetUIDh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetUID
            // 
            this.btnGetUID.Location = new System.Drawing.Point(12, 12);
            this.btnGetUID.Name = "btnGetUID";
            this.btnGetUID.Size = new System.Drawing.Size(75, 25);
            this.btnGetUID.TabIndex = 8;
            this.btnGetUID.Text = "Get UID";
            this.btnGetUID.UseVisualStyleBackColor = true;
            this.btnGetUID.Click += new System.EventHandler(this.btnGetUID_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(103, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txbGetUIDd
            // 
            this.txbGetUIDd.Location = new System.Drawing.Point(103, 43);
            this.txbGetUIDd.Name = "txbGetUIDd";
            this.txbGetUIDd.ReadOnly = true;
            this.txbGetUIDd.Size = new System.Drawing.Size(172, 20);
            this.txbGetUIDd.TabIndex = 10;
            this.txbGetUIDd.TextChanged += new System.EventHandler(this.txbGetUIDd_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(281, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(35, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "(DEC)";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(281, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "(HEX)";
            // 
            // txbGetUIDh
            // 
            this.txbGetUIDh.Location = new System.Drawing.Point(103, 13);
            this.txbGetUIDh.Name = "txbGetUIDh";
            this.txbGetUIDh.ReadOnly = true;
            this.txbGetUIDh.Size = new System.Drawing.Size(172, 20);
            this.txbGetUIDh.TabIndex = 9;
            this.txbGetUIDh.TextChanged += new System.EventHandler(this.txbGetUIDh_TextChanged);
            // 
            // cartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 148);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txbGetUIDd);
            this.Controls.Add(this.txbGetUIDh);
            this.Controls.Add(this.btnGetUID);
            this.Name = "cartao";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.cartao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnGetUID;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox txbGetUIDd;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txbGetUIDh;
    }
}

