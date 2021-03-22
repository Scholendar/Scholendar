namespace WindowsFormsApplication6
{
    partial class CriarTurma
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCiclo = new System.Windows.Forms.ComboBox();
            this.comboBoxAno = new System.Windows.Forms.ComboBox();
            this.textBoxLetra = new System.Windows.Forms.TextBox();
            this.radioButtonRegular = new System.Windows.Forms.RadioButton();
            this.radioButtonProfissional = new System.Windows.Forms.RadioButton();
            this.buttonCriar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ano :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Letra :";
            // 
            // comboBoxCiclo
            // 
            this.comboBoxCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCiclo.FormattingEnabled = true;
            this.comboBoxCiclo.Items.AddRange(new object[] {
            "1º Ciclo",
            "2º Ciclo ",
            "3º Ciclo",
            "Secundário"});
            this.comboBoxCiclo.Location = new System.Drawing.Point(84, 37);
            this.comboBoxCiclo.Name = "comboBoxCiclo";
            this.comboBoxCiclo.Size = new System.Drawing.Size(136, 21);
            this.comboBoxCiclo.TabIndex = 2;
            this.comboBoxCiclo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxAno
            // 
            this.comboBoxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAno.FormattingEnabled = true;
            this.comboBoxAno.Location = new System.Drawing.Point(113, 183);
            this.comboBoxAno.Name = "comboBoxAno";
            this.comboBoxAno.Size = new System.Drawing.Size(136, 21);
            this.comboBoxAno.TabIndex = 3;
            // 
            // textBoxLetra
            // 
            this.textBoxLetra.Location = new System.Drawing.Point(113, 223);
            this.textBoxLetra.Name = "textBoxLetra";
            this.textBoxLetra.Size = new System.Drawing.Size(136, 20);
            this.textBoxLetra.TabIndex = 4;
            // 
            // radioButtonRegular
            // 
            this.radioButtonRegular.AutoSize = true;
            this.radioButtonRegular.Checked = true;
            this.radioButtonRegular.Location = new System.Drawing.Point(48, 89);
            this.radioButtonRegular.Name = "radioButtonRegular";
            this.radioButtonRegular.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRegular.TabIndex = 5;
            this.radioButtonRegular.TabStop = true;
            this.radioButtonRegular.Text = "Regular";
            this.radioButtonRegular.UseVisualStyleBackColor = true;
            this.radioButtonRegular.Visible = false;
            // 
            // radioButtonProfissional
            // 
            this.radioButtonProfissional.AutoSize = true;
            this.radioButtonProfissional.Location = new System.Drawing.Point(170, 89);
            this.radioButtonProfissional.Name = "radioButtonProfissional";
            this.radioButtonProfissional.Size = new System.Drawing.Size(78, 17);
            this.radioButtonProfissional.TabIndex = 6;
            this.radioButtonProfissional.TabStop = true;
            this.radioButtonProfissional.Text = "Profissional";
            this.radioButtonProfissional.UseVisualStyleBackColor = true;
            this.radioButtonProfissional.Visible = false;
            // 
            // buttonCriar
            // 
            this.buttonCriar.Location = new System.Drawing.Point(59, 339);
            this.buttonCriar.Name = "buttonCriar";
            this.buttonCriar.Size = new System.Drawing.Size(89, 30);
            this.buttonCriar.TabIndex = 7;
            this.buttonCriar.Text = "Criar";
            this.buttonCriar.UseVisualStyleBackColor = true;
            this.buttonCriar.Click += new System.EventHandler(this.buttonCriar_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(162, 339);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(89, 30);
            this.buttonLimpar.TabIndex = 8;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApplication6.Properties.Resources.return_button_png_1_Transparent_Images;
            this.pictureBox3.Location = new System.Drawing.Point(12, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // CriarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.buttonCriar);
            this.Controls.Add(this.radioButtonProfissional);
            this.Controls.Add(this.radioButtonRegular);
            this.Controls.Add(this.textBoxLetra);
            this.Controls.Add(this.comboBoxAno);
            this.Controls.Add(this.comboBoxCiclo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CriarTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriarTurma";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCiclo;
        private System.Windows.Forms.ComboBox comboBoxAno;
        private System.Windows.Forms.TextBox textBoxLetra;
        private System.Windows.Forms.RadioButton radioButtonRegular;
        private System.Windows.Forms.RadioButton radioButtonProfissional;
        private System.Windows.Forms.Button buttonCriar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}