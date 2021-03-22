namespace WindowsFormsApplication6
{
    partial class Registar
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxnome = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUtilizador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.textBoxHex = new System.Windows.Forms.TextBox();
            this.textBoxDec = new System.Windows.Forms.TextBox();
            this.groupBoxCartao = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonRegistar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxDisc = new System.Windows.Forms.ComboBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.comboBoxDisc4 = new System.Windows.Forms.ComboBox();
            this.comboBoxDisc3 = new System.Windows.Forms.ComboBox();
            this.comboBoxDisc2 = new System.Windows.Forms.ComboBox();
            this.comboBoxTurma = new System.Windows.Forms.ComboBox();
            this.labelDisc = new System.Windows.Forms.Label();
            this.comboBoxEE = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxDisc = new System.Windows.Forms.TextBox();
            this.buttonDisc = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxIDTurma = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxAluno = new System.Windows.Forms.TextBox();
            this.textBoxIDDisc = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBoxIDDisc2 = new System.Windows.Forms.TextBox();
            this.textBoxIDDisc3 = new System.Windows.Forms.TextBox();
            this.textBoxIDDisc4 = new System.Windows.Forms.TextBox();
            this.textBoxIDProf = new System.Windows.Forms.TextBox();
            this.groupBoxCartao.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox1.Items.AddRange(new object[] {
            "Admin",
            "Aluno",
            "EE",
            "Professor"});
            this.comboBox1.Location = new System.Drawing.Point(328, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxnome
            // 
            this.textBoxnome.Location = new System.Drawing.Point(97, 18);
            this.textBoxnome.Name = "textBoxnome";
            this.textBoxnome.Size = new System.Drawing.Size(372, 20);
            this.textBoxnome.TabIndex = 1;
            this.textBoxnome.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(489, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Criar Turma";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome :";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data de Nascimento :";
            this.label2.Visible = false;
            // 
            // textBoxDN
            // 
            this.textBoxDN.Location = new System.Drawing.Point(475, 58);
            this.textBoxDN.Name = "textBoxDN";
            this.textBoxDN.Size = new System.Drawing.Size(133, 20);
            this.textBoxDN.TabIndex = 8;
            this.textBoxDN.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "Utilizador : ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 27);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email :";
            this.label4.Visible = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(97, 60);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(133, 20);
            this.textBoxEmail.TabIndex = 11;
            this.textBoxEmail.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(287, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nome de Utilizador :";
            this.label5.Visible = false;
            // 
            // textBoxUtilizador
            // 
            this.textBoxUtilizador.Location = new System.Drawing.Point(475, 101);
            this.textBoxUtilizador.Name = "textBoxUtilizador";
            this.textBoxUtilizador.Size = new System.Drawing.Size(133, 20);
            this.textBoxUtilizador.TabIndex = 13;
            this.textBoxUtilizador.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 27);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tel :";
            this.label6.Visible = false;
            // 
            // textBoxTel
            // 
            this.textBoxTel.Location = new System.Drawing.Point(97, 103);
            this.textBoxTel.MaxLength = 9;
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(133, 20);
            this.textBoxTel.TabIndex = 15;
            this.textBoxTel.Visible = false;
            // 
            // textBoxHex
            // 
            this.textBoxHex.Location = new System.Drawing.Point(24, 16);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.Size = new System.Drawing.Size(200, 20);
            this.textBoxHex.TabIndex = 16;
            this.textBoxHex.TextChanged += new System.EventHandler(this.textBoxHex_TextChanged);
            // 
            // textBoxDec
            // 
            this.textBoxDec.Location = new System.Drawing.Point(24, 53);
            this.textBoxDec.Name = "textBoxDec";
            this.textBoxDec.Size = new System.Drawing.Size(77, 20);
            this.textBoxDec.TabIndex = 17;
            // 
            // groupBoxCartao
            // 
            this.groupBoxCartao.Controls.Add(this.button3);
            this.groupBoxCartao.Controls.Add(this.textBoxDec);
            this.groupBoxCartao.Controls.Add(this.textBoxHex);
            this.groupBoxCartao.Location = new System.Drawing.Point(74, 202);
            this.groupBoxCartao.Name = "groupBoxCartao";
            this.groupBoxCartao.Size = new System.Drawing.Size(275, 93);
            this.groupBoxCartao.TabIndex = 18;
            this.groupBoxCartao.TabStop = false;
            this.groupBoxCartao.Text = "Cartão";
            this.groupBoxCartao.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(135, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 29);
            this.button3.TabIndex = 28;
            this.button3.Text = "Ler Cartão";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonRegistar
            // 
            this.buttonRegistar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistar.Location = new System.Drawing.Point(133, 308);
            this.buttonRegistar.Name = "buttonRegistar";
            this.buttonRegistar.Size = new System.Drawing.Size(121, 28);
            this.buttonRegistar.TabIndex = 25;
            this.buttonRegistar.Text = "Registar";
            this.buttonRegistar.UseVisualStyleBackColor = true;
            this.buttonRegistar.Visible = false;
            this.buttonRegistar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 27);
            this.label9.TabIndex = 26;
            this.label9.Text = "Turma :";
            this.label9.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxDisc);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.comboBoxDisc4);
            this.groupBox2.Controls.Add(this.comboBoxDisc3);
            this.groupBox2.Controls.Add(this.comboBoxDisc2);
            this.groupBox2.Controls.Add(this.comboBoxTurma);
            this.groupBox2.Controls.Add(this.labelDisc);
            this.groupBox2.Controls.Add(this.comboBoxEE);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.buttonRegistar);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.groupBoxCartao);
            this.groupBox2.Controls.Add(this.textBoxTel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxUtilizador);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxEmail);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxDN);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxnome);
            this.groupBox2.Location = new System.Drawing.Point(25, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 344);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxDisc
            // 
            this.comboBoxDisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisc.FormattingEnabled = true;
            this.comboBoxDisc.Location = new System.Drawing.Point(97, 144);
            this.comboBoxDisc.Name = "comboBoxDisc";
            this.comboBoxDisc.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisc.TabIndex = 39;
            this.comboBoxDisc.Visible = false;
            this.comboBoxDisc.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisc_SelectedIndexChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WindowsFormsApplication6.Properties.Resources._8b23fcb6b6c68d0f290b8dc5b5252214_cruz_ou___cone_de_mais_by_vexels;
            this.pictureBox6.Location = new System.Drawing.Point(236, 170);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(29, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 38;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::WindowsFormsApplication6.Properties.Resources._8b23fcb6b6c68d0f290b8dc5b5252214_cruz_ou___cone_de_mais_by_vexels;
            this.pictureBox5.Location = new System.Drawing.Point(98, 170);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 22);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 37;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApplication6.Properties.Resources._8b23fcb6b6c68d0f290b8dc5b5252214_cruz_ou___cone_de_mais_by_vexels;
            this.pictureBox4.Location = new System.Drawing.Point(236, 144);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // comboBoxDisc4
            // 
            this.comboBoxDisc4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisc4.FormattingEnabled = true;
            this.comboBoxDisc4.Location = new System.Drawing.Point(236, 171);
            this.comboBoxDisc4.Name = "comboBoxDisc4";
            this.comboBoxDisc4.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisc4.TabIndex = 35;
            this.comboBoxDisc4.Visible = false;
            this.comboBoxDisc4.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisc4_SelectedIndexChanged);
            // 
            // comboBoxDisc3
            // 
            this.comboBoxDisc3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisc3.FormattingEnabled = true;
            this.comboBoxDisc3.Location = new System.Drawing.Point(97, 171);
            this.comboBoxDisc3.Name = "comboBoxDisc3";
            this.comboBoxDisc3.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisc3.TabIndex = 34;
            this.comboBoxDisc3.Visible = false;
            this.comboBoxDisc3.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisc3_SelectedIndexChanged);
            // 
            // comboBoxDisc2
            // 
            this.comboBoxDisc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisc2.FormattingEnabled = true;
            this.comboBoxDisc2.Location = new System.Drawing.Point(236, 144);
            this.comboBoxDisc2.Name = "comboBoxDisc2";
            this.comboBoxDisc2.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisc2.TabIndex = 33;
            this.comboBoxDisc2.Visible = false;
            this.comboBoxDisc2.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisc2_SelectedIndexChanged);
            // 
            // comboBoxTurma
            // 
            this.comboBoxTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurma.FormattingEnabled = true;
            this.comboBoxTurma.Location = new System.Drawing.Point(97, 144);
            this.comboBoxTurma.Name = "comboBoxTurma";
            this.comboBoxTurma.Size = new System.Drawing.Size(133, 21);
            this.comboBoxTurma.TabIndex = 32;
            this.comboBoxTurma.Visible = false;
            this.comboBoxTurma.DropDown += new System.EventHandler(this.comboBoxTurma_DropDown);
            // 
            // labelDisc
            // 
            this.labelDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisc.Location = new System.Drawing.Point(-4, 142);
            this.labelDisc.Name = "labelDisc";
            this.labelDisc.Size = new System.Drawing.Size(99, 27);
            this.labelDisc.TabIndex = 31;
            this.labelDisc.Text = "Disciplina :";
            this.labelDisc.Visible = false;
            // 
            // comboBoxEE
            // 
            this.comboBoxEE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEE.FormattingEnabled = true;
            this.comboBoxEE.Location = new System.Drawing.Point(475, 144);
            this.comboBoxEE.Name = "comboBoxEE";
            this.comboBoxEE.Size = new System.Drawing.Size(133, 21);
            this.comboBoxEE.TabIndex = 30;
            this.comboBoxEE.Visible = false;
            this.comboBoxEE.SelectedIndexChanged += new System.EventHandler(this.comboBoxEE_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(409, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 27);
            this.label7.TabIndex = 29;
            this.label7.Text = "E E :";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxDisc);
            this.groupBox3.Controls.Add(this.buttonDisc);
            this.groupBox3.Location = new System.Drawing.Point(369, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 50);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Criar Disciplina";
            // 
            // textBoxDisc
            // 
            this.textBoxDisc.Location = new System.Drawing.Point(25, 17);
            this.textBoxDisc.Name = "textBoxDisc";
            this.textBoxDisc.Size = new System.Drawing.Size(150, 20);
            this.textBoxDisc.TabIndex = 4;
            // 
            // buttonDisc
            // 
            this.buttonDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisc.Location = new System.Drawing.Point(187, 13);
            this.buttonDisc.Name = "buttonDisc";
            this.buttonDisc.Size = new System.Drawing.Size(106, 27);
            this.buttonDisc.TabIndex = 2;
            this.buttonDisc.Text = "Criar";
            this.buttonDisc.UseVisualStyleBackColor = true;
            this.buttonDisc.Click += new System.EventHandler(this.buttonDisc_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication6.Properties.Resources.Lixo;
            this.pictureBox2.Location = new System.Drawing.Point(14, 255);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication6.Properties.Resources.info;
            this.pictureBox1.Location = new System.Drawing.Point(14, 217);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBoxIDTurma
            // 
            this.textBoxIDTurma.Location = new System.Drawing.Point(53, 59);
            this.textBoxIDTurma.Name = "textBoxIDTurma";
            this.textBoxIDTurma.Size = new System.Drawing.Size(26, 20);
            this.textBoxIDTurma.TabIndex = 29;
            this.textBoxIDTurma.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(581, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 27);
            this.button2.TabIndex = 30;
            this.button2.Text = "Associamento";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxAluno
            // 
            this.textBoxAluno.Location = new System.Drawing.Point(89, 59);
            this.textBoxAluno.Name = "textBoxAluno";
            this.textBoxAluno.Size = new System.Drawing.Size(27, 20);
            this.textBoxAluno.TabIndex = 31;
            this.textBoxAluno.Visible = false;
            // 
            // textBoxIDDisc
            // 
            this.textBoxIDDisc.Location = new System.Drawing.Point(123, 59);
            this.textBoxIDDisc.Name = "textBoxIDDisc";
            this.textBoxIDDisc.Size = new System.Drawing.Size(28, 20);
            this.textBoxIDDisc.TabIndex = 32;
            this.textBoxIDDisc.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApplication6.Properties.Resources.return_button_png_1_Transparent_Images;
            this.pictureBox3.Location = new System.Drawing.Point(12, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // textBoxIDDisc2
            // 
            this.textBoxIDDisc2.Location = new System.Drawing.Point(122, 32);
            this.textBoxIDDisc2.Name = "textBoxIDDisc2";
            this.textBoxIDDisc2.Size = new System.Drawing.Size(28, 20);
            this.textBoxIDDisc2.TabIndex = 34;
            this.textBoxIDDisc2.Visible = false;
            // 
            // textBoxIDDisc3
            // 
            this.textBoxIDDisc3.Location = new System.Drawing.Point(122, 6);
            this.textBoxIDDisc3.Name = "textBoxIDDisc3";
            this.textBoxIDDisc3.Size = new System.Drawing.Size(28, 20);
            this.textBoxIDDisc3.TabIndex = 35;
            this.textBoxIDDisc3.Visible = false;
            // 
            // textBoxIDDisc4
            // 
            this.textBoxIDDisc4.Location = new System.Drawing.Point(156, 6);
            this.textBoxIDDisc4.Name = "textBoxIDDisc4";
            this.textBoxIDDisc4.Size = new System.Drawing.Size(28, 20);
            this.textBoxIDDisc4.TabIndex = 36;
            this.textBoxIDDisc4.Visible = false;
            // 
            // textBoxIDProf
            // 
            this.textBoxIDProf.Location = new System.Drawing.Point(158, 59);
            this.textBoxIDProf.Name = "textBoxIDProf";
            this.textBoxIDProf.Size = new System.Drawing.Size(28, 20);
            this.textBoxIDProf.TabIndex = 33;
            this.textBoxIDProf.Visible = false;
            // 
            // Registar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.textBoxIDDisc4);
            this.Controls.Add(this.textBoxIDDisc3);
            this.Controls.Add(this.textBoxIDDisc2);
            this.Controls.Add(this.textBoxIDProf);
            this.Controls.Add(this.textBoxIDDisc);
            this.Controls.Add(this.textBoxAluno);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxIDTurma);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Name = "Registar";
            this.Text = "Registar";
            this.Load += new System.EventHandler(this.Registar_Load);
            this.groupBoxCartao.ResumeLayout(false);
            this.groupBoxCartao.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxnome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUtilizador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.TextBox textBoxHex;
        private System.Windows.Forms.TextBox textBoxDec;
        private System.Windows.Forms.GroupBox groupBoxCartao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonRegistar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxIDTurma;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxDisc;
        private System.Windows.Forms.Button buttonDisc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBoxEE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAluno;
        private System.Windows.Forms.Label labelDisc;
        private System.Windows.Forms.ComboBox comboBoxTurma;
        private System.Windows.Forms.TextBox textBoxIDDisc;
        private System.Windows.Forms.ComboBox comboBoxDisc4;
        private System.Windows.Forms.ComboBox comboBoxDisc3;
        private System.Windows.Forms.ComboBox comboBoxDisc2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox comboBoxDisc;
        private System.Windows.Forms.TextBox textBoxIDDisc2;
        private System.Windows.Forms.TextBox textBoxIDDisc3;
        private System.Windows.Forms.TextBox textBoxIDDisc4;
        private System.Windows.Forms.TextBox textBoxIDProf;
    }
}