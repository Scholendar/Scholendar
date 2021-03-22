using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication6
{
    public partial class Registar : Form
    {
        public Registar()
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
                    comboBoxTurma.Items.Add(sTurma);
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
                    comboBoxEE.Items.Add(sEE);
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
            string query = "select * from Disciplina order by Disciplina";
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
            textBoxDec.Text = "";
            textBoxDisc.Text = "";
            textBoxDN.Text = "";
            textBoxEmail.Text = "";
            textBoxHex.Text = "";
            textBoxnome.Text = "";
            textBoxTel.Text = "";
            textBoxUtilizador.Text = "";
            //comboBoxDisc.Items.Clear();
            //comboBoxEE.Items.Clear();
            //comboBoxTurma.Items.Clear();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Passe o cartão");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBoxHex.Text = ("");
            textBoxDec.Text = ("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = null;
            string nome = textBoxnome.Text;
            string email = textBoxEmail.Text;
            string telemovel = textBoxTel.Text;
            string dn = textBoxDN.Text;
            string utilizador = textBoxUtilizador.Text;
            string hex = textBoxHex.Text;
            string dec = textBoxDec.Text;

            string connetionString = null;
            connetionString = "Server=localhost;Database=Scholendar;Uid=root";
            MySqlConnection cnn;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            cnn = new MySqlConnection(connetionString);

            if (comboBox1.SelectedItem.ToString() == "EE")
            {
                //ClearTxt();
                if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxnome.Text) || string.IsNullOrEmpty(textBoxTel.Text) || string.IsNullOrEmpty(textBoxUtilizador.Text))
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {
                    sql = "insert into EE (Nome, Email, Telemovel, Utilizador, Pass) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "' , 'EE123A' )";
                    try
                    {
                        cnn.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Encarregado de Educação Inserido!");
                        ClearTxt();
                        comboBoxEE.Items.Clear();
                        FillcomboboxEE();
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
            else if (comboBox1.SelectedItem.ToString() == "Aluno")
            {
                //ClearTxt();
                if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxnome.Text) || string.IsNullOrEmpty(textBoxTel.Text) || string.IsNullOrEmpty(textBoxUtilizador.Text) || string.IsNullOrEmpty(textBoxDN.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text) || comboBoxTurma.SelectedItem == null || comboBoxEE.SelectedItem == null )
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {                    
                    try
                    {
                        cnn.Open();
                        string turma = comboBoxTurma.SelectedItem.ToString();
                        string Query3 = "select * from Turma where Turma ='" + turma + "'";
                        MySqlCommand MyCommand3 = new MySqlCommand(Query3, cnn);
                        MySqlDataReader MyReader3;
                        MyReader3 = MyCommand3.ExecuteReader();
                        while (MyReader3.Read())
                        {
                            textBoxIDTurma.Text = MyReader3["ID_Turma"].ToString();
                        }
                        cnn.Close();

                        cnn.Open();
                        string aluno = comboBoxEE.SelectedItem.ToString();
                        string QueryA = "select * from EE where Nome ='" + aluno + "'";
                        MySqlCommand MyCommand4 = new MySqlCommand(QueryA, cnn);
                        MySqlDataReader MyReader4;
                        MyReader4 = MyCommand4.ExecuteReader();
                        while (MyReader4.Read())
                        {
                            textBoxAluno.Text = MyReader4["ID_EE"].ToString();
                        }
                        cnn.Close();

                        cnn.Open();
                        string IDTurma = textBoxIDTurma.Text;
                        string ID_EE = textBoxAluno.Text;
                        sql = "insert into Aluno (Nome, Email, Telemovel, Utilizador,DataDeNascimento,Hex,De,Pass,ID_Turma, ID_EE) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', '" + dn + "', '" + hex + "', '" + dec + "' , 'Aluno123A', '" + IDTurma + "' , '" + ID_EE + "' )";
                        adapter.InsertCommand = new MySqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Aluno Inserido!");
                        ClearTxt();
                        comboBoxEE.SelectedItem = null;
                        comboBoxTurma.SelectedItem = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnn.Clone();
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Professor")
            {
                if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxnome.Text) || string.IsNullOrEmpty(textBoxTel.Text) || string.IsNullOrEmpty(textBoxUtilizador.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text) || comboBoxDisc.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {

                    try
                    {
                        cnn.Open();
                        sql = "insert into Professor (Nome, Email, Telemovel, Utilizador, Pass, Hex, De) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', 'Prof123A' , '" + hex + "', '" + dec + "')";
                        adapter.InsertCommand = new MySqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Professor Inserido!");

                        cnn.Close();

                        cnn.Open();
                        string professor = textBoxnome.Text;
                        string query = "select * from Professor where nome = '" + professor + "' ";
                        MySqlCommand MyCommand = new MySqlCommand(query, cnn);
                        MySqlDataReader MyReader;
                        MyReader = MyCommand.ExecuteReader();
                        while (MyReader.Read())
                        {
                            textBoxIDProf.Text = MyReader["ID_Professor"].ToString();
                        }
                        cnn.Close();

                        string Disc1 = textBoxIDDisc.Text ;
                        string Disc2 = textBoxIDDisc2.Text;
                        string Disc3 = textBoxIDDisc3.Text;
                        string Disc4 = textBoxIDDisc4.Text;
                        string Professor = textBoxIDProf.Text;

                        cnn.Open();
                        string query2 = "insert into Prof_Disc values ('" + Disc1 + "', '" + Professor + "')";
                        adapter.InsertCommand = new MySqlCommand(query2, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        cnn.Close();

                        if (comboBoxDisc2.SelectedItem != null)
                        {
                            cnn.Open();
                            string query3 = "insert into Prof_Disc values('" + Disc2 + "', '" + Professor + "')";
                            adapter.InsertCommand = new MySqlCommand(query3, cnn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            cnn.Close();
                            if (comboBoxDisc3.SelectedItem != null)
                            {
                                cnn.Open();
                                string query4 = "insert into Prof_Disc values('" + Disc3 + "', '" + Professor + "')";
                                adapter.InsertCommand = new MySqlCommand(query4, cnn);
                                adapter.InsertCommand.ExecuteNonQuery();
                                cnn.Close();
                                if (comboBoxDisc4.SelectedItem != null)
                                {
                                    cnn.Open();
                                    string query5 = "insert into Prof_Disc values('" + Disc4 + "', '" + Professor + "')";
                                    adapter.InsertCommand = new MySqlCommand(query5, cnn);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    cnn.Close();
                                }
                            }
                        }
                        

                        ClearTxt();
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
            else if (comboBox1.SelectedItem.ToString() == "Admin")
            {
                if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxnome.Text) || string.IsNullOrEmpty(textBoxTel.Text) || string.IsNullOrEmpty(textBoxUtilizador.Text) || string.IsNullOrEmpty(textBoxDec.Text) || string.IsNullOrEmpty(textBoxHex.Text))
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {

                    try
                    {
                        cnn.Close();
                        cnn.Open();
                        sql = "insert into Admin (Nome, Email, Telemovel, Utilizador, Pass, Hex, De) values('" + nome + "', '" + email + "', '" + telemovel + "', '" + utilizador + "', 'adm123' , '" + hex + "', '" + dec + "')";
                        adapter.InsertCommand = new MySqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Admin Inserido!");
                        ClearTxt();
                        cnn.Close();
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
            
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "EE")
            {
                label1.Visible = true;
                label2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = false;
                textBoxDec.Visible = true;
                textBoxDN.Visible = false;
                textBoxEmail.Visible = true;
                textBoxHex.Visible = true;
                textBoxnome.Visible = true;
                textBoxTel.Visible = true;
                textBoxUtilizador.Visible = true;
                groupBoxCartao.Visible = true;
                groupBoxCartao.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                buttonRegistar.Visible = true;
                comboBoxTurma.Visible = false;
                label7.Visible = false;
                comboBoxEE.Visible = false;
                labelDisc.Visible = false;
                comboBoxDisc.Visible = false;
                pictureBox4.Visible = false;
                comboBoxDisc2.Visible = false;
                comboBoxDisc3.Visible = false;
                comboBoxDisc4.Visible = false;
                ClearTxt();
            }
            else if (comboBox1.SelectedItem.ToString() == "Aluno")
            {
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                textBoxDec.Visible = true;
                textBoxDN.Visible = true;
                textBoxEmail.Visible = true;
                textBoxHex.Visible = true;
                textBoxnome.Visible = true;
                textBoxTel.Visible = true;
                textBoxUtilizador.Visible = true;
                groupBoxCartao.Visible = true;
                groupBoxCartao.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                buttonRegistar.Visible = true;
                comboBoxTurma.Visible = true;
                button3.Visible = true;
                label7.Visible = true;
                comboBoxEE.Visible = true;
                labelDisc.Visible = false;
                comboBoxDisc.Visible = false;
                pictureBox4.Visible = false;
                comboBoxDisc2.Visible = false;
                comboBoxDisc3.Visible = false;
                comboBoxDisc4.Visible = false;
                ClearTxt();

            }
            else if (comboBox1.SelectedItem.ToString() == "Professor")
            {
                label1.Visible = true;
                label2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = false;
                textBoxDec.Visible = true;
                textBoxDN.Visible = false;
                textBoxEmail.Visible = true;
                textBoxHex.Visible = true;
                textBoxnome.Visible = true;
                textBoxTel.Visible = true;
                textBoxUtilizador.Visible = true;
                groupBoxCartao.Visible = true;
                groupBoxCartao.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                buttonRegistar.Visible = true;
                comboBoxTurma.Visible = false;
                button3.Visible = true;
                label7.Visible = false;
                comboBoxEE.Visible = false;
                labelDisc.Visible = true;
                comboBoxDisc.Visible = true;
                ClearTxt();
                if (comboBoxDisc2.Visible == false)
                {
                    pictureBox4.Visible = true;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Admin")
            {
                label1.Visible = true;
                label2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = false;
                textBoxDec.Visible = true;
                textBoxDN.Visible = false;
                textBoxEmail.Visible = true;
                textBoxHex.Visible = true;
                textBoxnome.Visible = true;
                textBoxTel.Visible = true;
                textBoxUtilizador.Visible = true;
                groupBoxCartao.Visible = true;
                groupBoxCartao.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                buttonRegistar.Visible = true;
                comboBoxTurma.Visible = false;
                button3.Visible = true;
                label7.Visible = false;
                comboBoxEE.Visible = false;
                labelDisc.Visible = false;
                comboBoxDisc.Visible = false;
                pictureBox4.Visible = false;
                comboBoxDisc2.Visible = false;
                comboBoxDisc3.Visible = false;
                comboBoxDisc4.Visible = false;
                ClearTxt();
                
            }
    }


        private void button1_Click(object sender, EventArgs e)
        {
            CriarTurma newform = new CriarTurma();
            newform.Show();
        }


        private void textBoxAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxAno_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void buttonDisc_Click(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Associacao newform = new Associacao();
            newform.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin newform = new Admin();
            newform.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Registar_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            comboBoxDisc2.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            comboBoxDisc3.Visible = true;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {
            comboBoxDisc4.Visible = true;
            pictureBox6.Visible = false;
        }

        private void comboBoxDisc_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxDisc2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxDisc3_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxDisc4_SelectedIndexChanged(object sender, EventArgs e)
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

        private void textBoxHex_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTurma_DropDown(object sender, EventArgs e)
        {
            comboBoxTurma.Items.Clear();
            Fillcombobox();
        }

        unsafe private void button3_Click(object sender, EventArgs e)
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
