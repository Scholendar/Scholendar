namespace WindowsFormsApplication6
{
    partial class EsqueceuPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNomeUtilizador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxConfirmar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxTipoUtilizador = new System.Windows.Forms.TextBox();
            this.textBoxID_Utilizador = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxcodigovar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfirmar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNomeUtilizador
            // 
            this.textBoxNomeUtilizador.Location = new System.Drawing.Point(46, 80);
            this.textBoxNomeUtilizador.Name = "textBoxNomeUtilizador";
            this.textBoxNomeUtilizador.Size = new System.Drawing.Size(244, 20);
            this.textBoxNomeUtilizador.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insira o seu nome de utilizador :";
            // 
            // pictureBoxConfirmar
            // 
            this.pictureBoxConfirmar.Image = global::WindowsFormsApplication6.Properties.Resources.Seta_Direita;
            this.pictureBoxConfirmar.Location = new System.Drawing.Point(317, 78);
            this.pictureBoxConfirmar.Name = "pictureBoxConfirmar";
            this.pictureBoxConfirmar.Size = new System.Drawing.Size(27, 22);
            this.pictureBoxConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxConfirmar.TabIndex = 2;
            this.pictureBoxConfirmar.TabStop = false;
            this.pictureBoxConfirmar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(-43, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 30);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication6.Properties.Resources.Exit;
            this.pictureBox2.Location = new System.Drawing.Point(405, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textBoxTipoUtilizador
            // 
            this.textBoxTipoUtilizador.Location = new System.Drawing.Point(280, 36);
            this.textBoxTipoUtilizador.Name = "textBoxTipoUtilizador";
            this.textBoxTipoUtilizador.Size = new System.Drawing.Size(100, 20);
            this.textBoxTipoUtilizador.TabIndex = 4;
            this.textBoxTipoUtilizador.Visible = false;
            // 
            // textBoxID_Utilizador
            // 
            this.textBoxID_Utilizador.Location = new System.Drawing.Point(174, 36);
            this.textBoxID_Utilizador.Name = "textBoxID_Utilizador";
            this.textBoxID_Utilizador.Size = new System.Drawing.Size(100, 20);
            this.textBoxID_Utilizador.TabIndex = 5;
            this.textBoxID_Utilizador.Visible = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(68, 36);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.Visible = false;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(-38, 36);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 20);
            this.textBoxNome.TabIndex = 7;
            this.textBoxNome.Visible = false;
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(12, 106);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodigo.TabIndex = 8;
            this.textBoxCodigo.Visible = false;
            // 
            // textBoxcodigovar
            // 
            this.textBoxcodigovar.Location = new System.Drawing.Point(46, 80);
            this.textBoxcodigovar.Name = "textBoxcodigovar";
            this.textBoxcodigovar.Size = new System.Drawing.Size(244, 20);
            this.textBoxcodigovar.TabIndex = 9;
            this.textBoxcodigovar.Visible = false;
            // 
            // EsqueceuPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 130);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxcodigovar);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxID_Utilizador);
            this.Controls.Add(this.textBoxTipoUtilizador);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNomeUtilizador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EsqueceuPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EsqueceuPass";
            this.Load += new System.EventHandler(this.EsqueceuPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfirmar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeUtilizador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxConfirmar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxTipoUtilizador;
        private System.Windows.Forms.TextBox textBoxID_Utilizador;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxcodigovar;
    }
}