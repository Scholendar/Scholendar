using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace WindowsFormsApplication6
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Fillcombobox();
            FillcomboboxEE();
            FillcomboboxDisc();
        }

        MW_EasyPOD EasyPOD;

        UInt32 dwResult, Index;

        void Fillcombobox()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select Turma from turma order by turma";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlCommand cmdconnection = new MySqlCommand(query, connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = cmdconnection.ExecuteReader();

                while (myReader.Read())
                {
                    string sTurma = myReader.GetString("Turma");
                    comboBoxAlunoTurma.Items.Add(sTurma);
                    comboBoxTurma2.Items.Add(sTurma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        void FillcomboboxEE()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select Nome from EE order by Nome";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlCommand cmdconnection = new MySqlCommand(query, connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = cmdconnection.ExecuteReader();

                while (myReader.Read())
                {
                    string sEE = myReader.GetString("Nome");
                    comboBoxAlunoEE.Items.Add(sEE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        void FillcomboboxDisc()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select distinct * from Disciplina order by Disciplina";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlCommand cmdconnection = new MySqlCommand(query, connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = cmdconnection.ExecuteReader();

                while (myReader.Read())
                {
                    string sDisc = myReader.GetString("Disciplina");

                    comboBoxDisc2.Items.Add(sDisc);
                    comboBoxDisc3.Items.Add(sDisc);
                    comboBoxDisc4.Items.Add(sDisc);
                    comboBoxDisc.Items.Add(sDisc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        void ClearTxt()
        {
            textBoxAdminEmail.Text = "";
            textBoxAdminNome.Text = "";
            textBoxAdminNomeUtiliz.Text = "";
            textBoxAdminTelemovel.Text = "";
            comboBoxAdminSexo.SelectedItem = null;

            textBoxAlunoDN.Text = "";
            textBoxAlunoEmail.Text = "";
            textBoxAlunoNome.Text = "";
            textBoxAlunoNomeUtiliz.Text = "";
            textBoxAlunoTelemovel.Text = "";
            comboBoxAlunoEE.SelectedItem = null;
            comboBoxAlunoSexo.SelectedItem = null;
            comboBoxAlunoTurma.SelectedItem = null;

            textBoxProfessorEmail.Text = "";
            textBoxProfessorNome.Text = "";
            textBoxProfessorNomeUtiliz.Text = "";
            textBoxProfessorTelemovel.Text = "";
            comboBoxProfessorSexo.SelectedItem = null;

            textBoxEEEmail.Text = "";
            textBoxEENome.Text = "";
            textBoxEENomeUtilizador.Text = "";
            textBoxEETelemovel.Text = "";
            comboBoxEESexo.SelectedItem = null;

            textBoxHex.Text = "";
            textBoxDec.Text = "";

        }

        private void LoadPerfil()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            string ID_Admin = textBoxID_Admin.Text;

            string query = "select * from Admin where ID_Admin = '" + ID_Admin + "' ";
            MySqlCommand MyCommand = new MySqlCommand(query, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxPerfilNome.Text = MyReader["Nome"].ToString();
                textBoxPerfilNomeUtilizador.Text = MyReader["Utilizador"].ToString();
                textBoxPerfilEmail.Text = MyReader["Email"].ToString();
                textBoxPerfilTelemovel.Text = MyReader["Telemovel"].ToString();
            }
            connection.Close();
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            connection.Open();

            string query = "select * from VAR where ID_Var = '1';";
            MySqlCommand MyCommand = new MySqlCommand(query, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxID_Admin.Text = MyReader["var"].ToString();
            }
            connection.Close();


            dataGridViewProfs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProfs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewEditarAluno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEditarAluno.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            LoadPerfil();
        }

        

        private Exit form = new Exit();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBoxUtilizador.Text = "Administrador";
            form.textBox1.Text = textBoxUtilizador.Text;
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Passe o cartão");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            textBoxHex.Text = ("");
            textBoxDec.Text = ("");
        }

        private void buttonRegistar_Click(object sender, EventArgs e)
        {
            if (buttonRegistar.Text == "Registar") {
                string sql = null;
                string hex = textBoxHex.Text;
                string dec = textBoxDec.Text;

                string conexao = "Server=localhost;Database=Scholendar;Uid=root";
                var connection = new MySqlConnection(conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                if (comboBoxUtilizador.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o utilizador primeiro e depois insira os dados do mesmo.");
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "EE")
                {
                    //ClearTxt();
                    if (string.IsNullOrEmpty(textBoxEEEmail.Text) || string.IsNullOrEmpty(textBoxEENome.Text) || string.IsNullOrEmpty(textBoxEETelemovel.Text) || string.IsNullOrEmpty(textBoxEENomeUtilizador.Text) || comboBoxEESexo.SelectedItem.ToString() == null)
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
                    else
                    {
                        //QUERY'S
                        MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxEENomeUtilizador.Text + "'", connection);
                        MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxEENomeUtilizador.Text + "'", connection);
                        MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxEENomeUtilizador.Text + "'", connection);
                        MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxEENomeUtilizador.Text + "'", connection);

                        connection.Open();

                        //DATATABLES
                        DataTable dataTable1 = new DataTable();
                        DataTable dataTable2 = new DataTable();
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = new DataTable();


                        //ADAPATERS
                        MySqlDataAdapter daAl = new MySqlDataAdapter(queryAl);
                        MySqlDataAdapter daAd = new MySqlDataAdapter(queryAd);
                        MySqlDataAdapter daProf = new MySqlDataAdapter(queryProf);
                        MySqlDataAdapter daEE = new MySqlDataAdapter(queryEE);


                        daAl.Fill(dataTable1);
                        daAd.Fill(dataTable2);
                        daProf.Fill(dataTable3);
                        daEE.Fill(dataTable4);


                        connection.Close();


                        foreach (DataRow list in dataTable1.Rows) // Aluno
                        {
                            if (Convert.ToInt32(list.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        foreach (DataRow list2 in dataTable2.Rows) // Admin
                        {
                            if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }

                        }

                        foreach (DataRow list3 in dataTable3.Rows) //Professor
                        {
                            if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }


                        foreach (DataRow list4 in dataTable4.Rows) //EE
                        {
                            if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        if (textBoxVerif_Util.Text == "1")
                        {
                            MessageBox.Show("Esse utilizador já existe");
                            textBoxVerif_Util.Text = "";
                            return;
                        }
                        else if (textBoxVerif_Util.Text == "")
                        {
                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            var stringChars = new char[8];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            textBoxPass.Text = new String(stringChars);

                            string nome = textBoxEENome.Text;
                            string email = textBoxEEEmail.Text;
                            string telemovel = textBoxEETelemovel.Text;
                            string utilizador = textBoxEENomeUtilizador.Text;
                            string pass = textBoxPass.Text;
                            string sexo = comboBoxEESexo.SelectedItem.ToString();

                            sql = "insert into EE (Nome, Email, Telemovel, Utilizador, Pass, Sexo,Var) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "' , '" + pass + "' , '" + sexo + "', '1' )";
                            try
                            {
                                connection.Open();
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress("scholendar@gmail.com");
                                mail.To.Add(textBoxEEEmail.Text);
                                mail.Subject = "Conta Scholendar Criada";
                                mail.Body = "Caro/a " + comboBoxUtilizador.Text + " " + textBoxEENome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi criada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxEENomeUtilizador.Text + Environment.NewLine + "Password - " + textBoxPass.Text + Environment.NewLine + "Obrigado!";

                                smtp.Port = 587;
                                smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                                //MessageBox.Show("Email Enviado");

                                MessageBox.Show("Encarregado de Educação Inserido!");
                                ClearTxt();
                                comboBoxAlunoEE.Items.Clear();
                                FillcomboboxEE();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        
                    }
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Aluno")
                {
                    //ClearTxt();
                    if (string.IsNullOrEmpty(textBoxAlunoEmail.Text) || string.IsNullOrEmpty(textBoxAlunoNome.Text) || string.IsNullOrEmpty(textBoxAlunoTelemovel.Text) || string.IsNullOrEmpty(textBoxAlunoNomeUtiliz.Text) || string.IsNullOrEmpty(textBoxAlunoDN.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text) || comboBoxAlunoTurma.SelectedItem == null || comboBoxAlunoEE.SelectedItem == null || comboBoxAlunoSexo.SelectedItem.ToString() == null)
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
                    else
                    {
                        //QUERY'S
                        MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxAlunoNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxAlunoNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxAlunoNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxAlunoNomeUtiliz.Text + "'", connection);

                        connection.Open();

                        //DATATABLES
                        DataTable dataTable1 = new DataTable();
                        DataTable dataTable2 = new DataTable();
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = new DataTable();


                        //ADAPATERS
                        MySqlDataAdapter daAl = new MySqlDataAdapter(queryAl);
                        MySqlDataAdapter daAd = new MySqlDataAdapter(queryAd);
                        MySqlDataAdapter daProf = new MySqlDataAdapter(queryProf);
                        MySqlDataAdapter daEE = new MySqlDataAdapter(queryEE);


                        daAl.Fill(dataTable1);
                        daAd.Fill(dataTable2);
                        daProf.Fill(dataTable3);
                        daEE.Fill(dataTable4);


                        connection.Close();


                        foreach (DataRow list in dataTable1.Rows) // Aluno
                        {
                            if (Convert.ToInt32(list.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        foreach (DataRow list2 in dataTable2.Rows) // Admin
                        {
                            if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }

                        }

                        foreach (DataRow list3 in dataTable3.Rows) //Professor
                        {
                            if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }


                        foreach (DataRow list4 in dataTable4.Rows) //EE
                        {
                            if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        if (textBoxVerif_Util.Text == "1")
                        {
                            MessageBox.Show("Esse utilizador já existe");
                            textBoxVerif_Util.Text = "";
                            return;
                        }

                        else if (textBoxVerif_Util.Text == "")
                        {
                            string sexo = comboBoxAlunoSexo.SelectedItem.ToString();

                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            var stringChars = new char[8];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            textBoxPass.Text = new String(stringChars);

                            string pass = textBoxPass.Text;
                            try
                            {
                                connection.Open();
                                string turma = comboBoxAlunoTurma.SelectedItem.ToString();
                                string Query3 = "select * from Turma where Turma ='" + turma + "'";
                                MySqlCommand MyCommand3 = new MySqlCommand(Query3, connection);
                                MySqlDataReader MyReader3;
                                MyReader3 = MyCommand3.ExecuteReader();
                                while (MyReader3.Read())
                                {
                                    textBoxIDTurma.Text = MyReader3["ID_Turma"].ToString();
                                }
                                connection.Close();

                                connection.Open();
                                string aluno = comboBoxAlunoEE.SelectedItem.ToString();
                                string QueryA = "select * from EE where Nome ='" + aluno + "'";
                                MySqlCommand MyCommand4 = new MySqlCommand(QueryA, connection);
                                MySqlDataReader MyReader4;
                                MyReader4 = MyCommand4.ExecuteReader();
                                while (MyReader4.Read())
                                {
                                    textBoxAluno.Text = MyReader4["ID_EE"].ToString();
                                }
                                connection.Close();

                                connection.Open();

                                string IDTurma = textBoxIDTurma.Text;
                                string ID_EE = textBoxAluno.Text;
                                string nome = textBoxAlunoNome.Text;
                                string email = textBoxAlunoEmail.Text;
                                string telemovel = textBoxAlunoTelemovel.Text;
                                string utilizador = textBoxAlunoNomeUtiliz.Text;
                                string dn = textBoxAlunoDN.Text;

                                sql = "insert into Aluno (Nome, Email, Telemovel, Utilizador,DataDeNascimento,Hex,De,Pass,ID_Turma, ID_EE, Sexo,Var) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', '" + dn + "', '" + hex + "', '" + dec + "' , '" + pass + "', '" + IDTurma + "' , '" + ID_EE + "' , '" + sexo + "' , '1' )";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress("scholendar@gmail.com");
                                mail.To.Add(textBoxAlunoEmail.Text);
                                mail.Subject = "Conta Scholendar Criada";
                                mail.Body = "Caro/a " + comboBoxUtilizador.Text + " " + textBoxAlunoNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi criada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxAlunoNomeUtiliz.Text + Environment.NewLine + "Password - " + textBoxPass.Text + Environment.NewLine + "Obrigado!";
                                smtp.Port = 587;
                                smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);

                                MessageBox.Show("Aluno Inserido!");
                                ClearTxt();
                                comboBoxAlunoEE.SelectedItem = null;
                                comboBoxAlunoTurma.SelectedItem = null;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        
                    }
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Professor")
                {
                    if (string.IsNullOrEmpty(textBoxProfessorEmail.Text) || string.IsNullOrEmpty(textBoxProfessorNome.Text) || string.IsNullOrEmpty(textBoxProfessorTelemovel.Text) || string.IsNullOrEmpty(textBoxProfessorNomeUtiliz.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text) || comboBoxDisc.SelectedItem == null || comboBoxProfessorSexo.SelectedItem.ToString() == null)
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
                    else
                    {
                        //QUERY'S
                        MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxProfessorNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxProfessorNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxProfessorNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxProfessorNomeUtiliz.Text + "'", connection);

                        connection.Open();

                        //DATATABLES
                        DataTable dataTable1 = new DataTable();
                        DataTable dataTable2 = new DataTable();
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = new DataTable();


                        //ADAPATERS
                        MySqlDataAdapter daAl = new MySqlDataAdapter(queryAl);
                        MySqlDataAdapter daAd = new MySqlDataAdapter(queryAd);
                        MySqlDataAdapter daProf = new MySqlDataAdapter(queryProf);
                        MySqlDataAdapter daEE = new MySqlDataAdapter(queryEE);


                        daAl.Fill(dataTable1);
                        daAd.Fill(dataTable2);
                        daProf.Fill(dataTable3);
                        daEE.Fill(dataTable4);


                        connection.Close();


                        foreach (DataRow list in dataTable1.Rows) // Aluno
                        {
                            if (Convert.ToInt32(list.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        foreach (DataRow list2 in dataTable2.Rows) // Admin
                        {
                            if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }

                        }

                        foreach (DataRow list3 in dataTable3.Rows) //Professor
                        {
                            if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }


                        foreach (DataRow list4 in dataTable4.Rows) //EE
                        {
                            if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        if (textBoxVerif_Util.Text == "1")
                        {
                            MessageBox.Show("Esse utilizador já existe");
                            textBoxVerif_Util.Text = "";
                            return;
                        }

                        else if (textBoxVerif_Util.Text == "")
                        {
                            string sexo = comboBoxProfessorSexo.SelectedItem.ToString();

                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            var stringChars = new char[8];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            textBoxPass.Text = new String(stringChars);

                            string pass = textBoxPass.Text;

                            string nome = textBoxProfessorNome.Text;
                            string email = textBoxProfessorEmail.Text;
                            string telemovel = textBoxProfessorTelemovel.Text;
                            string utilizador = textBoxProfessorNomeUtiliz.Text;

                            try
                            {
                                connection.Open();
                                sql = "insert into Professor (Nome, Email, Telemovel, Utilizador, Pass, Hex, De, Sexo, Var) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', '" + pass + "' , '" + hex + "', '" + dec + "', '" + sexo + "' , '1' )";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress("scholendar@gmail.com");
                                mail.To.Add(textBoxProfessorEmail.Text);
                                mail.Subject = "Conta Scholendar Criada";
                                mail.Body = "Caro/a " + comboBoxUtilizador.Text + " " + textBoxProfessorNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi criada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxProfessorNomeUtiliz.Text + Environment.NewLine + "Password - " + textBoxPass.Text + Environment.NewLine + "Obrigado!";
                                smtp.Port = 587;
                                smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);

                                MessageBox.Show("Professor Inserido!");

                                connection.Close();

                                connection.Open();
                                string professor = textBoxProfessorNome.Text;
                                string query = "select * from Professor where nome = '" + professor + "' ";
                                MySqlCommand MyCommand = new MySqlCommand(query, connection);
                                MySqlDataReader MyReader;
                                MyReader = MyCommand.ExecuteReader();
                                while (MyReader.Read())
                                {
                                    textBoxIDProf.Text = MyReader["ID_Professor"].ToString();
                                }
                                connection.Close();

                                string Disc1 = textBoxIDDisc.Text;
                                string Disc2 = textBoxIDDisc2.Text;
                                string Disc3 = textBoxIDDisc3.Text;
                                string Disc4 = textBoxIDDisc4.Text;
                                string Professor = textBoxIDProf.Text;

                                connection.Open();
                                string query2 = "insert into Prof_Disc values ('" + Disc1 + "', '" + Professor + "')";
                                adapter.InsertCommand = new MySqlCommand(query2, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();

                                if (comboBoxDisc2.SelectedItem != null)
                                {
                                    connection.Open();
                                    string query3 = "insert into Prof_Disc values('" + Disc2 + "', '" + Professor + "')";
                                    adapter.InsertCommand = new MySqlCommand(query3, connection);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    connection.Close();
                                    if (comboBoxDisc3.SelectedItem != null)
                                    {
                                        connection.Open();
                                        string query4 = "insert into Prof_Disc values('" + Disc3 + "', '" + Professor + "')";
                                        adapter.InsertCommand = new MySqlCommand(query4, connection);
                                        adapter.InsertCommand.ExecuteNonQuery();
                                        connection.Close();
                                        if (comboBoxDisc4.SelectedItem != null)
                                        {
                                            connection.Open();
                                            string query5 = "insert into Prof_Disc values('" + Disc4 + "', '" + Professor + "')";
                                            adapter.InsertCommand = new MySqlCommand(query5, connection);
                                            adapter.InsertCommand.ExecuteNonQuery();
                                            connection.Close();
                                        }
                                    }
                                }

                                comboBoxDisc.SelectedItem = null;
                                comboBoxDisc2.SelectedItem = null;
                                comboBoxDisc3.SelectedItem = null;
                                comboBoxDisc4.SelectedItem = null;
                                comboBoxDisc2.Visible = false;
                                comboBoxDisc3.Visible = false;
                                comboBoxDisc4.Visible = false;
                                pictureBox8.Visible = true;
                                pictureBox7.Visible = false;
                                pictureBox6.Visible = false;

                                ClearTxt();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }

                    }
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Administrador")
                {
                    if (string.IsNullOrEmpty(textBoxAdminEmail.Text) || string.IsNullOrEmpty(textBoxAdminNome.Text) || string.IsNullOrEmpty(textBoxAdminTelemovel.Text) || string.IsNullOrEmpty(textBoxAdminNomeUtiliz.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text) || comboBoxAdminSexo.SelectedItem.ToString() == null)
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
                    else
                    {
                        //QUERY'S
                        MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxAdminNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxAdminNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxAdminNomeUtiliz.Text + "'", connection);
                        MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxAdminNomeUtiliz.Text + "'", connection);

                        connection.Open();

                        //DATATABLES
                        DataTable dataTable1 = new DataTable();
                        DataTable dataTable2 = new DataTable();
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = new DataTable();


                        //ADAPATERS
                        MySqlDataAdapter daAl = new MySqlDataAdapter(queryAl);
                        MySqlDataAdapter daAd = new MySqlDataAdapter(queryAd);
                        MySqlDataAdapter daProf = new MySqlDataAdapter(queryProf);
                        MySqlDataAdapter daEE = new MySqlDataAdapter(queryEE);


                        daAl.Fill(dataTable1);
                        daAd.Fill(dataTable2);
                        daProf.Fill(dataTable3);
                        daEE.Fill(dataTable4);


                        connection.Close();


                        foreach (DataRow list in dataTable1.Rows) // Aluno
                        {
                            if (Convert.ToInt32(list.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        foreach (DataRow list2 in dataTable2.Rows) // Admin
                        {
                            if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }

                        }

                        foreach (DataRow list3 in dataTable3.Rows) //Professor
                        {
                            if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }


                        foreach (DataRow list4 in dataTable4.Rows) //EE
                        {
                            if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                            {
                                textBoxVerif_Util.Text = "1";
                            }
                            else
                            {

                            }
                        }

                        if (textBoxVerif_Util.Text == "1")
                        {
                            MessageBox.Show("Esse utilizador já existe");
                            textBoxVerif_Util.Text = "";
                            return;
                        }

                        else if (textBoxVerif_Util.Text == "")
                        {
                            string sexo = comboBoxAdminSexo.SelectedItem.ToString();

                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            var stringChars = new char[8];
                            var random = new Random();

                            for (int i = 0; i < stringChars.Length; i++)
                            {
                                stringChars[i] = chars[random.Next(chars.Length)];
                            }

                            textBoxPass.Text = new String(stringChars);

                            string pass = textBoxPass.Text;

                            string nome = textBoxAdminNome.Text;
                            string email = textBoxAdminEmail.Text;
                            string telemovel = textBoxAdminTelemovel.Text;
                            string utilizador = textBoxAdminNomeUtiliz.Text;

                            try
                            {
                                connection.Close();
                                connection.Open();
                                sql = "insert into Admin (Nome, Email, Telemovel, Utilizador, Pass, Hex, De, Sexo , Var) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', '" + pass + "' , '" + hex + "', '" + dec + "' , '" + sexo + "' , '1' )";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress("scholendar@gmail.com");
                                mail.To.Add(textBoxAdminEmail.Text);
                                mail.Subject = "Conta Scholendar Criada";
                                mail.Body = "Caro/a " + comboBoxUtilizador.Text + " " + textBoxAdminNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi criada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxAdminNomeUtiliz.Text + Environment.NewLine + "Password - " + textBoxPass.Text + Environment.NewLine + "Obrigado!";
                                smtp.Port = 587;
                                smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);

                                MessageBox.Show("Administrador Inserido!");
                                ClearTxt();
                                connection.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                        
                    }
                }
            }
            else if (buttonRegistar.Text == "Confirmar")
            {
                string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();
                string Nome = textBoxEditarNome.Text;
                string Email = textBoxEditarEmail.Text;
                string Tel = textBoxEditarTel.Text;
                string DN = textBoxEditarDN.Text;
                if (comboBoxUtilizador.SelectedItem.ToString() == "EE")
                {
                    if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmailVar.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text)
                    {
                        DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer alterar? " ,"", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string connetionString = null;
                            connetionString = "Server=localhost;Database=Scholendar;Uid=root";
                            MySqlConnection cnn;
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            cnn = new MySqlConnection(connetionString);


                            string sql = "update EE set Nome = '" + Nome + "', Email = '" + Email + "', Telemovel = '" + Tel + "'  where ID_EE = '2';";

                            try
                            {
                                cnn.Open();
                                adapter.InsertCommand = new MySqlCommand(sql, cnn);
                                adapter.InsertCommand.ExecuteNonQuery();
                                dataGridViewEditarAluno.DataSource = LoadDGVEditarEE();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                cnn.Close();
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                        
                    }
                }

                else if (comboBoxUtilizador.SelectedItem.ToString() == "Professor")
                {
                    if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmailVar.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text)
                    {
                        DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer alterar? ", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string connetionString = null;
                            connetionString = "Server=localhost;Database=Scholendar;Uid=root";
                            MySqlConnection cnn;
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            cnn = new MySqlConnection(connetionString);


                            string sql = "update Professor set Nome = '" + Nome + "', Email = '" + Email + "', Telemovel = '" + Tel + "'  where ID_Professor = '" + select + "'";

                            try
                            {
                                cnn.Open();
                                adapter.InsertCommand = new MySqlCommand(sql, cnn);
                                adapter.InsertCommand.ExecuteNonQuery();
                                dataGridViewEditarAluno.DataSource = LoadDGVEditarProf();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                cnn.Close();
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                        
                    }
                }

                else if (comboBoxUtilizador.SelectedItem.ToString() == "Aluno")
                {
                    if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmailVar.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text || textBoxEditarDN.Text != textBoxEditarDNVar.Text)
                    {
                        if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmailVar.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text || textBoxEditarDN.Text != textBoxEditarDNVar.Text)
                        {
                            DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer alterar? ", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string connetionString = null;
                                connetionString = "Server=localhost;Database=Scholendar;Uid=root";
                                MySqlConnection cnn;
                                MySqlDataAdapter adapter = new MySqlDataAdapter();
                                cnn = new MySqlConnection(connetionString);


                                string sql = "update Aluno set Nome = '" + Nome + "', Email = '" + Email + "', Telemovel = '" + Tel + "', DataDeNascimento =  '" + DN + "' where ID_Aluno = '" + select + "'";

                                try
                                {
                                    cnn.Open();
                                    adapter.InsertCommand = new MySqlCommand(sql, cnn);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    dataGridViewEditarAluno.DataSource = LoadDGVEditarAluno();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    cnn.Close();
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {

                            }
                            
                        }
                    }
                }

                else if (comboBoxUtilizador.SelectedItem.ToString() == "Administrador")
                {
                    if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmailVar.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text)
                    {
                        if (textBoxEditarNome.Text != textBoxEditarNomeVar.Text || textBoxEditarEmail.Text != textBoxEditarEmail.Text || textBoxEditarTel.Text != textBoxEditarTelVar.Text)
                        {
                            DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer alterar? ", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string connetionString = null;
                                connetionString = "Server=localhost;Database=Scholendar;Uid=root";
                                MySqlConnection cnn;
                                MySqlDataAdapter adapter = new MySqlDataAdapter();
                                cnn = new MySqlConnection(connetionString);


                                string sql = "update admin set Nome = '" + Nome + "', Email = '" + Email + "', Telemovel = '" + Tel + "'  where ID_Admin = '" + select + "'";

                                try
                                {
                                    cnn.Open();
                                    adapter.InsertCommand = new MySqlCommand(sql, cnn);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    dataGridViewEditarAluno.DataSource = LoadDGVEditarAdmin();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    cnn.Close();
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {

                            }
                            
                        }
                    }
                }
            }
        }
        private BindingSource LoadDGVEditarAluno() // Aluno
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select Aluno.ID_Aluno, Aluno.nome, Turma.Turma from Aluno, Turma where Aluno.ID_Turma = Turma.ID_Turma;";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;

        }

        private BindingSource LoadDGVEditarProf() // Prof
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select ID_Professor, Nome from Professor;";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;

        }

        private BindingSource LoadDGVEditarEE() // EE
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select ID_EE, Nome from EE;";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;

        }

        private BindingSource LoadDGVEditarAdmin() // Admin
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select ID_Admin, Nome from Admin;";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buttonRegistar.Text == "Registar") //Registar 
            {
                if (comboBoxUtilizador.SelectedItem == null)
                {

                }

                else if (comboBoxUtilizador.SelectedItem.ToString() == "EE")
                {
                    panelAdministrador.Visible = false;
                    panelAluno.Visible = false;
                    panelEE.Visible = true;
                    panelProfessor.Visible = false;
                    groupBoxCartao.Visible = false;

                    ClearTxt();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Aluno")
                {
                    panelAdministrador.Visible = false;
                    panelAluno.Visible = true;
                    panelEE.Visible = false;
                    panelProfessor.Visible = false;
                    groupBoxCartao.Visible = true;

                    ClearTxt();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Professor")
                {
                    panelAdministrador.Visible = false;
                    panelAluno.Visible = false;
                    panelEE.Visible = false;
                    panelProfessor.Visible = true;
                    groupBoxCartao.Visible = true;

                    comboBoxDisc.SelectedItem = null;
                    comboBoxDisc2.SelectedItem = null;
                    comboBoxDisc3.SelectedItem = null;
                    comboBoxDisc4.SelectedItem = null;
                    comboBoxDisc2.Visible = false;
                    comboBoxDisc3.Visible = false;
                    comboBoxDisc4.Visible = false;
                    pictureBox8.Visible = true;
                    pictureBox7.Visible = false;
                    pictureBox6.Visible = false;

                    ClearTxt();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Administrador")
                {
                    panelAdministrador.Visible = true;
                    panelAluno.Visible = false;
                    panelEE.Visible = false;
                    panelProfessor.Visible = false;
                    groupBoxCartao.Visible = true;

                    ClearTxt();

                }


            }

            else if (buttonRegistar.Text == "Confirmar") // Editar
            {
                if (comboBoxUtilizador.SelectedItem == null)
                {

                }

                else if (comboBoxUtilizador.SelectedItem.ToString() == "EE")
                {
                    pictureBox13.Visible = true;
                    dataGridViewEditarAluno.DataSource = LoadDGVEditarEE();
                    this.dataGridViewEditarAluno.Columns["ID_EE"].Visible = false;

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from EE where ID_EE = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxTrocar.Visible = false;
                        pictureBox13.Visible = false;
                        pictureBoxEliminar.Visible = false;
                        pictureBoxConfirmar.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }
                    connection.Close();

                    textBoxVarEditar.Text = "1";
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Aluno")
                {
                    pictureBox13.Visible = false;
                    dataGridViewEditarAluno.DataSource = LoadDGVEditarAluno();
                    this.dataGridViewEditarAluno.Columns["ID_Aluno"].Visible = false;

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Aluno where ID_Aluno = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarDN.Text = MyReader["DataDeNascimento"].ToString();

                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = true;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxEliminar.Visible = false;
                        pictureBox13.Visible = false;
                        pictureBoxTrocar.Visible = true;
                        pictureBoxEliminar.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = true;
                        label4.Visible = true;
                        panel22.Visible = true;
                    }
                    connection.Close();

                    textBoxVarEditar.Text = "1";
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Professor")
                {
                    pictureBox13.Visible = true;
                    dataGridViewEditarAluno.DataSource = LoadDGVEditarProf();
                    this.dataGridViewEditarAluno.Columns["ID_Professor"].Visible = false;


                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Professor where ID_Professor = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = true;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxTrocar.Visible = false;
                        pictureBoxEliminar.Visible = true;
                        pictureBoxConfirmar.Visible = false;
                        pictureBox13.Visible = true;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }

                    connection.Close();                    

                    textBoxVarEditar.Text = "1";
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Administrador")
                {

                    pictureBox13.Visible = false;
                    dataGridViewEditarAluno.DataSource = LoadDGVEditarAdmin();
                    this.dataGridViewEditarAluno.Columns["ID_Admin"].Visible = false;

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Admin where ID_Admin = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxTrocar.Visible = false;
                        pictureBoxConfirmar.Visible = false;
                        pictureBoxEliminar.Visible = false;
                        pictureBox13.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }
                    connection.Close();

                    textBoxVarEditar.Text = "1";
                }
            }
        }

        private void buttonCriarDisc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDisc.Text))
            {
                MessageBox.Show("Escreva o nome da disciplina que deseja criar!");
            }
            else
            {
                string connetionString = null;
                MySqlConnection cnn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql = null;

                connetionString = "Server=localhost;Database=Scholendar;Uid=root";

                string Disciplina = textBoxDisc.Text;
                string Ver = "select * from Disciplina where Disciplina = '" + textBoxDisc.Text + "' ";



                cnn = new MySqlConnection(connetionString);

                cnn.Open();
                MySqlCommand query = new MySqlCommand(Ver, cnn);
                MySqlDataReader da = query.ExecuteReader();
                while (da.Read())
                {
                    MessageBox.Show("Já existe essa disciplina!");
                    textBoxDisc.Text = "";
                    return;
                }

                cnn.Close();
                sql = "insert into Disciplina (Disciplina) values('" + Disciplina + "')";

                try
                {
                    cnn.Open();
                    adapter.InsertCommand = new MySqlCommand(sql, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Disciplina Criada");
                    comboBoxDisc.Items.Clear();
                    FillcomboboxDisc();
                    textBoxDisc.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnn.Close();
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            comboBoxDisc2.Visible = true;
            pictureBox8.Visible = false;
            pictureBox7.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            comboBoxDisc3.Visible = true;
            pictureBox7.Visible = false;
            pictureBox6.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            comboBoxDisc4.Visible = true;
            pictureBox6.Visible = false;
        }

        private void comboBoxDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisc.SelectedItem == null)
            {
            }
            else
            {
                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();
                    string disciplina = comboBoxDisc.SelectedItem.ToString();

                    string query = "select * from Disciplina where Disciplina = '" + disciplina + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxIDDisc.Text = MyReader["ID_Disciplina"].ToString();
                    }
                    connection.Close();
            }
        }

        private void comboBoxDisc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisc2.SelectedItem == null)
            {
                
            }
            else
            {
                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();
                    string disciplina2 = comboBoxDisc2.SelectedItem.ToString();
                    string query2 = "select * from Disciplina where Disciplina = '" + disciplina2 + "' ";
                    MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                        textBoxIDDisc2.Text = MyReader2["ID_Disciplina"].ToString();
                    }
                    connection.Close();
            }
            
        }

        private void comboBoxDisc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisc3.SelectedItem == null)
                if (comboBoxDisc3.SelectedItem.ToString() == comboBoxDisc.SelectedItem.ToString() || comboBoxDisc3.SelectedItem.ToString() == comboBoxDisc2.SelectedItem.ToString() || comboBoxDisc3.SelectedItem.ToString() == comboBoxDisc4.SelectedItem.ToString())
                {
                    MessageBox.Show("Nao pode ter duas disciplinas iguais");
                }
                else
                {
                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();
                    string disciplina3 = comboBoxDisc3.SelectedItem.ToString();
                    string query3 = "select * from Disciplina where Disciplina = '" + disciplina3 + "' ";
                    MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        textBoxIDDisc3.Text = MyReader3["ID_Disciplina"].ToString();
                    }
                    connection.Close();
                }
            
        }

        private void comboBoxDisc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisc4.SelectedItem == null)
            {
                
            }
            else
            {
                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();
                    string disciplina4 = comboBoxDisc4.SelectedItem.ToString();
                    string query4 = "select * from Disciplina where Disciplina = '" + disciplina4 + "' ";
                    MySqlCommand MyCommand4 = new MySqlCommand(query4, connection);
                    MySqlDataReader MyReader4;
                    MyReader4 = MyCommand4.ExecuteReader();
                    while (MyReader4.Read())
                    {
                        textBoxIDDisc4.Text = MyReader4["ID_Disciplina"].ToString();
                    }
                    connection.Close();
            }
            
        }

        private void comboBoxTurma_DropDown(object sender, EventArgs e)
        {
            comboBoxAlunoTurma.Items.Clear();
            Fillcombobox();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Associacao newform = new Associacao();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarTurma newform = new CriarTurma();
            newform.Show();

        }

        private void comboBoxTurma2_DropDown(object sender, EventArgs e)
        {
            comboBoxTurma2.Items.Clear();
            Fillcombobox();
        }

        private BindingSource LoadDGVAlunos() // Carregar a segunda DGV (Fora)
        {
            string ID_Turma = textBoxTurma2.Text;
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select Aluno.nome, EE.nome from aluno, EE where aluno.ID_Turma = '" + ID_Turma + "' and aluno.ID_EE = EE.ID_EE;";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];

            return bs;

        }

        private BindingSource LoadDGV() // Carregar a primeira DGV (Dentro)
        {
            string ID_Turma = textBoxTurma2.Text;
            string Query2 = "SELECT  Professor.Nome,  disciplina.Disciplina from professor, prof_turma, disciplina where Prof_Turma.ID_Professor = professor.ID_Professor and prof_turma.ID_Disciplina = disciplina.ID_Disciplina and Prof_Turma.ID_Turma = '" + ID_Turma + "'; ";
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "Server=localhost;Database=Scholendar;Uid=root";
            cnn = new MySqlConnection(connetionString);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();


            cmd = new MySqlCommand(Query2, cnn);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;

        }

        private void comboBoxTurma2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            try
            {
                connection.Open();
                string turma = comboBoxTurma2.SelectedItem.ToString();
                string Query3 = "select * from Turma where Turma ='" + turma + "'";
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxTurma2.Text = MyReader3["ID_Turma"].ToString();
                }
                connection.Close();
                dataGridViewProfs.DataSource = LoadDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            dataGridViewAlunos.DataSource = LoadDGVAlunos();
            dataGridViewAlunos.Columns[0].HeaderText = "Aluno";
            dataGridViewProfs.Columns[0].HeaderText = "Professor";
            dataGridViewAlunos.Columns[1].HeaderText = "Encarregado de Educação";
            dataGridViewAlunos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAlunos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MailTeste newform = new MailTeste();
            this.Close();
            newform.Show();


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panelAdministrador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAluno_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonEditarRegistar_Click(object sender, EventArgs e)
        {
            if (buttonEditarRegistar.Text == "Editar")
            {
                comboBoxUtilizador.SelectedItem = null;
                buttonRegistar.Text = "Confirmar";
                panelEditar.Visible = true;
                panelAdministrador.Visible = false;
                panelAluno.Visible = false;
                panelEE.Visible = false;
                panelProfessor.Visible = false;
                groupBoxCartao.Visible = false;
                ClearTxt();



                buttonEditarRegistar.Text = "Registar";
            }

            else if (buttonEditarRegistar.Text == "Registar")
            {

                comboBoxUtilizador.SelectedItem = null;
                buttonRegistar.Text = "Registar";

                panelEditar.Visible = false;
                panelAdministrador.Visible = false;
                panelAluno.Visible = false;
                panelEE.Visible = false;
                panelProfessor.Visible = false;
                groupBoxCartao.Visible = false;

                buttonEditarRegistar.Text = "Editar";
            }
        }

        private void dataGridViewEditar_SelectionChanged(object sender, EventArgs e)
        {
            if (textBoxVarEditar.Text == "1")
            {
                listBoxEditarDisc.Items.Clear();
                listBoxEditarEducando.Items.Clear();
                if (comboBoxUtilizador.SelectedItem.ToString() == "Aluno")
                {

                    if (dataGridViewEditarAluno.SelectedCells.Count <= 0)
                    {
                        return;
                    }
                    
                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Aluno where ID_Aluno = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarDN.Text = MyReader["DataDeNascimento"].ToString();
                        textBoxEditarDNVar.Text = MyReader["DataDeNascimento"].ToString();
                        
                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = true;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxEliminar.Visible = false;
                        pictureBox13.Visible = false;
                        pictureBoxConfirmar.Visible = false;
                        buttonCancelar.Visible = false;
                        pictureBoxTrocar.Visible = true;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = true;
                        label4.Visible = true;
                        panel22.Visible = true;
                    }
                    connection.Close();

                    connection.Open();

                    string query1 = "select EE.Nome from Aluno, EE where Aluno.ID_Aluno = '"+ select +"' and Aluno.ID_EE = EE.ID_EE;";

                    MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                    MySqlDataReader MyReader1;
                    MyReader1 = MyCommand1.ExecuteReader();
                    while (MyReader1.Read())
                    {
                        listBoxEditarEducando.Items.Add(MyReader1["Nome"].ToString());
                    }


                    connection.Close();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "Professor")
                {
                    if (dataGridViewEditarAluno.SelectedCells.Count <= 0)
                    {
                        return;
                    }

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    listBoxEditarDisc.Items.Clear();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Professor where ID_Professor = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = true;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxEliminar.Visible = true;
                        pictureBoxTrocar.Visible = false;
                        pictureBox13.Visible = true;
                        pictureBoxConfirmar.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }

                    connection.Close();

                    connection.Open();

                    string query1 = "select disciplina.Disciplina from disciplina, Prof_Disc where prof_disc.ID_Professor = '" + select + "' and disciplina.ID_Disciplina = prof_disc.ID_Disciplina;";

                    MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                    MySqlDataReader MyReader1;
                    MyReader1 = MyCommand1.ExecuteReader();
                    while (MyReader1.Read())
                    {
                        listBoxEditarDisc.Items.Add(MyReader1["Disciplina"].ToString());
                    }
                    

                    connection.Close();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString() == "EE")
                {
                    if (dataGridViewEditarAluno.SelectedCells.Count <= 0)
                    {
                        return;
                    }

                    listBoxEditarEducando.Items.Clear();

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from EE where ID_EE = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxEliminar.Visible = false;
                        pictureBoxTrocar.Visible = false;
                        pictureBox13.Visible = false;
                        pictureBoxConfirmar.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }
                    connection.Close();
                }
                else if (comboBoxUtilizador.SelectedItem.ToString () == "Administrador")
                {
                    if (dataGridViewEditarAluno.SelectedCells.Count <= 0)
                    {
                        return;
                    }

                    string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();

                    string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                    MySqlConnection connection = new MySqlConnection(Conexao);
                    connection.Open();

                    string query = "select * from Admin where ID_Admin = '" + select + "' ";
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxEditarNome.Text = MyReader["Nome"].ToString();
                        textBoxEditarNomeVar.Text = MyReader["Nome"].ToString();
                        textBoxEditarEmail.Text = MyReader["Email"].ToString();
                        textBoxEditarEmailVar.Text = MyReader["Email"].ToString();
                        textBoxEditarTel.Text = MyReader["Telemovel"].ToString();
                        textBoxEditarTelVar.Text = MyReader["Telemovel"].ToString();

                        listBoxEditarDisc.Visible = false;
                        listBoxEditarDisciplinaVar.Visible = false;
                        listBoxEditarEducando.Visible = false;
                        listBoxEditarEducandoVar.Visible = false;

                        pictureBoxEliminar.Visible = false;
                        pictureBoxTrocar.Visible = false;
                        pictureBox13.Visible = false;
                        pictureBoxConfirmar.Visible = false;
                        buttonCancelar.Visible = false;

                        textBoxEditarNome.Visible = true;
                        label1.Visible = true;
                        panel11.Visible = true;
                        textBoxEditarEmail.Visible = true;
                        label2.Visible = true;
                        panel16.Visible = true;
                        textBoxEditarTel.Visible = true;
                        label5.Visible = true;
                        panel17.Visible = true;
                        textBoxEditarDN.Visible = false;
                        label4.Visible = false;
                        panel22.Visible = false;
                    }
                    connection.Close();
                }
            }
            
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            buttonCancelar.Visible = true;
            pictureBox13.Visible = false;
            pictureBoxConfirmar.Visible = true;
            pictureBoxEliminar.Visible = false;
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            if (listBoxEditarDisc.Visible == true)
            {
                connection.Open();

                listBoxEditarDisciplinaVar.Items.Clear();

                string query1 = "select Disciplina from Disciplina;";

                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    listBoxEditarDisciplinaVar.Items.Add(MyReader1["Disciplina"].ToString());
                }


                connection.Close();
                listBoxEditarDisc.Visible = false;
                listBoxEditarDisciplinaVar.Visible = true;
            }
            else if (listBoxEditarEducando.Visible == true)
            {
                connection.Open();

                listBoxEditarEducandoVar.Items.Clear();

                string query1 = "select Nome from EE;";

                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    listBoxEditarEducandoVar.Items.Add(MyReader1["Nome"].ToString());
                }

                listBoxEditarEducando.Visible = false;
                listBoxEditarEducandoVar.Visible = true;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (listBoxEditarDisciplinaVar.Visible == true)
            {
                listBoxEditarDisc.Visible = true;
                listBoxEditarDisciplinaVar.Visible = false;
                pictureBox13.Visible = true;
                pictureBoxConfirmar.Visible = false;
                buttonCancelar.Visible = false;
                pictureBoxEliminar.Visible = true;
            }
            else if (listBoxEditarEducandoVar.Visible == true)
            {
                listBoxEditarEducando.Visible = true;
                listBoxEditarEducandoVar.Visible = false;
                pictureBox13.Visible = true;
                pictureBoxConfirmar.Visible = false;
                buttonCancelar.Visible = false;
                pictureBoxEliminar.Visible = true;
            }
        }

        private void pictureBoxConfirmar_Click(object sender, EventArgs e)
        {
            if (listBoxEditarDisciplinaVar.Visible == true)
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);

                string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();
                string Disciplina = textBoxEditarID_DiscVar.Text ;
                string Ver = "select * from prof_disc where ID_Disciplina = '" + textBoxEditarID_DiscVar.Text + "' and ID_Professor = '"+ select +"' ";

                connection.Open();
                MySqlCommand query = new MySqlCommand(Ver, connection);
                MySqlDataReader da = query.ExecuteReader();
                while (da.Read())
                {
                    MessageBox.Show("O professor já tem essa disciplina!");
                    return;
                }

                connection.Close();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string Update = "insert into prof_disc values ('"+Disciplina+"','"+select+"')";

                connection.Open();
                adapter.InsertCommand = new MySqlCommand(Update, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();

                listBoxEditarDisc.Items.Clear();

                connection.Open();

                string query1 = "select Disciplina.Disciplina from Disciplina, prof_disc where prof_disc.ID_professor = '"+select+"' and prof_disc.ID_disciplina = disciplina.ID_disciplina;";

                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    listBoxEditarDisc.Items.Add(MyReader1["Disciplina"].ToString());
                }

                connection.Close();

                listBoxEditarDisc.Visible = true;
                listBoxEditarDisciplinaVar.Visible = false;
                buttonCancelar.Visible = false;
                pictureBoxConfirmar.Visible = false;
                pictureBoxTrocar.Visible = false;
                pictureBox13.Visible = true;
                pictureBoxEliminar.Visible = true;

            } 

            else if (listBoxEditarEducandoVar.Visible == true)
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);

                string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();
                string EE = textBoxEditarID_Educando.Text;
                string Ver = "select * from Aluno where ID_Aluno = '" + select + "' and ID_EE = '" + EE + "' ";

                connection.Open();
                MySqlCommand query = new MySqlCommand(Ver, connection);
                MySqlDataReader da = query.ExecuteReader();
                while (da.Read())
                {
                    MessageBox.Show("Já é EE desse aluno!");
                    return;
                }
                connection.Close();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string ID_EE = textBoxEditarID_Educando.Text;
                string Update = " update Aluno set ID_EE = '" + ID_EE + "' where ID_Aluno = '" + select + "' ";

                connection.Open();
                adapter.InsertCommand = new MySqlCommand(Update, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();

                listBoxEditarEducando.Items.Clear();

                connection.Open();

                string query1 = "select EE.Nome from  EE, Aluno where Aluno.ID_EE = EE.ID_EE and Aluno.ID_Aluno = '" + select + "' ";

                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    listBoxEditarEducando.Items.Add(MyReader1["Nome"].ToString());
                }

                connection.Close();

                listBoxEditarEducando.Visible = true;
                listBoxEditarEducandoVar.Visible = false;
                buttonCancelar.Visible = false;
                pictureBoxConfirmar.Visible = false;
                pictureBoxTrocar.Visible = true;
                pictureBoxEliminar.Visible = true;
            }
        }

        private void listBoxEditarDisciplinaVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            string Disciplina = listBoxEditarDisciplinaVar.SelectedItem.ToString();
            string query1 = "select * from Disciplina where disciplina = '" + Disciplina + "';";

            connection.Open();

            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
            MySqlDataReader MyReader1;
            MyReader1 = MyCommand1.ExecuteReader();
            while (MyReader1.Read())
            {
                textBoxEditarID_DiscVar.Text = MyReader1["ID_Disciplina"].ToString();
            }

            connection.Close();
        }

        private void listBoxEditarEducandoVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            string Nome = listBoxEditarEducandoVar.SelectedItem.ToString();
            string query1 = "select * from EE where Nome = '" + Nome + "';";

            connection.Open();

            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
            MySqlDataReader MyReader1;
            MyReader1 = MyCommand1.ExecuteReader();
            while (MyReader1.Read())
            {
                textBoxEditarID_Educando.Text = MyReader1["ID_EE"].ToString();
            }

            connection.Close();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (listBoxEditarDisc.Visible == true)
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string select = dataGridViewEditarAluno.SelectedCells[0].Value.ToString();
                string Disciplina = textBoxEditarID_Disc.Text;
                string Ver = "delete from Prof_Disc where ID_Disciplina = '" + textBoxEditarID_Disc.Text + "' and ID_Professor = '" + select + "' ; ";

                connection.Open();
                adapter.InsertCommand = new MySqlCommand(Ver, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();

                listBoxEditarDisc.Items.Clear();

                connection.Open();

                string query1 = "select disciplina.Disciplina from disciplina, Prof_Disc where prof_disc.ID_Professor = '" + select + "' and disciplina.ID_Disciplina = prof_disc.ID_Disciplina;";

                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    listBoxEditarDisc.Items.Add(MyReader1["Disciplina"].ToString());
                }

                connection.Close();

                listBoxEditarDisc.Visible = true;
                listBoxEditarDisciplinaVar.Visible = false;
            }
        }

        private void listBoxEditarDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            string Disciplina = listBoxEditarDisc.SelectedItem.ToString();
            string query1 = "select * from Disciplina where disciplina = '" + Disciplina + "';";

            connection.Open();

            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
            MySqlDataReader MyReader1;
            MyReader1 = MyCommand1.ExecuteReader();
            while (MyReader1.Read())
            {
                textBoxEditarID_Disc.Text = MyReader1["ID_Disciplina"].ToString();
            }

            connection.Close();
        }

        private void listBoxEditarEducando_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxTrocar_Click(object sender, EventArgs e)
        {
            

            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            
            connection.Open();

            listBoxEditarEducandoVar.Items.Clear();

            string query1 = "select Nome from EE;";

            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
            MySqlDataReader MyReader1;
            MyReader1 = MyCommand1.ExecuteReader();
            while (MyReader1.Read())
            {
                listBoxEditarEducandoVar.Items.Add(MyReader1["Nome"].ToString());
            }


            listBoxEditarEducando.Visible = false;
            listBoxEditarEducandoVar.Visible = true;
            pictureBoxConfirmar.Visible = true;
            buttonCancelar.Visible = true;
            pictureBoxTrocar.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEditarNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEditarEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEditarTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelEditar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        unsafe private void button6_Click(object sender, EventArgs e)
        {
            UInt32 uiLength, uiRead, uiResult, uiWritten;
            byte[] ReadBuffer = new byte[0x40];
            byte[] WriteBuffer = new byte[] { 0x2, 0x2, 0x1, 0x1 }; //Command {STX, LEN, CMD, DATA1, DATA2.....}

            byte[] sResponse = null;
            sResponse = new byte[21];

            EasyPOD.VID = 0xe6a;
            EasyPOD.PID = 0x317;
            Index = 1;
            uiLength = 64;

            fixed (MW_EasyPOD* pPOD = &EasyPOD)
            {

                dwResult = PODfuncs.ConnectPOD(pPOD, Index);

                if ((dwResult != 0))
                {
                    MessageBox.Show("Not connected yet");
                }
                else
                {
                    EasyPOD.ReadTimeOut = 200;
                    EasyPOD.WriteTimeOut = 200;

                    dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, 4, &uiWritten);    //Send a request command to reader
                    uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                    textBoxHex.Text = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");  //HEX
                    textBoxDec.Text = BitConverter.ToInt32(ReadBuffer, 4).ToString();  //DEC
                }
                dwResult = PODfuncs.ClearPODBuffer(pPOD);
                dwResult = PODfuncs.DisconnectPOD(pPOD);
            }
        }

    }
}
