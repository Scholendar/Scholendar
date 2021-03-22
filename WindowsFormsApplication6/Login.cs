using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

//using System.BitConverter;

namespace WindowsFormsApplication6
{
    public partial class Login : Form
    {
        
        
        public Login()
        {
            InitializeComponent();
            textBoxPass.PasswordChar = '*';
        }

        MW_EasyPOD EasyPOD;

        UInt32 dwResult, Index;

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private MudarPass form = new MudarPass();

        unsafe private void button2_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("Ligue o leitor de cartões");
                }
                else
                {
                    EasyPOD.ReadTimeOut = 200;
                    EasyPOD.WriteTimeOut = 200;

                    dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, 4, &uiWritten);    //Send a request command to reader
                    uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                    textBoxHex.Text = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");  //HEX
                    textBoxDe.Text = BitConverter.ToInt32(ReadBuffer, 4).ToString();  //DEC
                                                                                      //textBox1.PasswordChar = '*';


                    string conexao = "Server=localhost;Database=Scholendar;Uid=root";
                    var connection = new MySqlConnection(conexao);
                    var command = connection.CreateCommand();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    //QUERY'S
                    MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Hex = '" + textBoxHex.Text + "' or De = '" + textBoxDe.Text + "'", connection);
                    MySqlCommand queryAd = new MySqlCommand("select * from Admin where Hex = '" + textBoxHex.Text + "' or De = '" + textBoxDe.Text + "'", connection);
                    MySqlCommand queryProf = new MySqlCommand("select * from Professor where Hex = '" + textBoxHex.Text + "' or De = '" + textBoxDe.Text + "'", connection);

                    connection.Open();

                    //DATATABLES
                    DataTable dataTable1 = new DataTable();
                    DataTable dataTable2 = new DataTable();
                    DataTable dataTable3 = new DataTable();

                    //ADAPATERS
                    MySqlDataAdapter daAl = new MySqlDataAdapter(queryAl);
                    MySqlDataAdapter daAd = new MySqlDataAdapter(queryAd);
                    MySqlDataAdapter daProf = new MySqlDataAdapter(queryProf);

                    daAl.Fill(dataTable1);
                    daAd.Fill(dataTable2);
                    daProf.Fill(dataTable3);

                    connection.Close();


                    foreach (DataRow list in dataTable1.Rows) // Aluno
                    {
                        if (Convert.ToInt32(list.ItemArray[0]) > 0)
                        {
                            textBoxVar.Text = "1";
                        }
                        else
                        {
                            MessageBox.Show("Teste");
                        }
                    }

                    foreach (DataRow list in dataTable2.Rows) // Admin
                    {
                        if (Convert.ToInt32(list.ItemArray[0]) > 0)
                        {
                            textBoxVar.Text = "2";
                        }
                        else
                        {
                            MessageBox.Show("Teste");
                        }

                    }

                    foreach (DataRow list3 in dataTable3.Rows) //Professor
                    {
                        if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                        {
                            textBoxVar.Text = "3";
                        }
                        else
                        {
                            MessageBox.Show("Teste");
                        }
                    }



                    if (textBoxVar.Text == "1")//ALUNO
                    {
                        connection.Open();
                        string Hex = textBoxHex.Text;
                        string query = "select * from Aluno where Hex = '" + Hex + "' ";
                        MySqlCommand MyCommand = new MySqlCommand(query, connection);
                        MySqlDataReader MyReader;
                        MyReader = MyCommand.ExecuteReader();
                        while (MyReader.Read())
                        {
                            textBoxID_Aluno.Text = MyReader["ID_Aluno"].ToString();
                        }
                        connection.Close();

                        try
                        {
                            string ID_Aluno = textBoxID_Aluno.Text;
                            connection.Open();

                            string sql = "Update VAR set var = ('" + ID_Aluno + "') where ID_Var = 1;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            connection.Close();

                            connection.Open();
                            string query1 = "select * from Aluno where ID_Aluno = '" + ID_Aluno + "' ;";
                            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                            MySqlDataReader MyReader1;
                            MyReader1 = MyCommand1.ExecuteReader();
                            while (MyReader1.Read())
                            {
                                textBoxVarPass.Text = MyReader1["var"].ToString();
                            }
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

                        try
                        {

                            connection.Open();

                            string sql = "Update VAR set var = '1' where ID_Var = 2;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }

                        if (textBoxVarPass.Text == "1")
                        {
                            this.Hide();
                            MudarPass newform1 = new MudarPass();
                            newform1.Show();
                            form.textBoxUtilizador.Text = "Aluno";
                        }
                        else
                        {
                            this.Hide();
                            Aluno newform = new Aluno();
                            newform.Show();
                        }

                        
                    }
                    else if (textBoxVar.Text == "2")//ADMIN
                    {
                        
                        connection.Open();
                        string Hex = textBoxHex.Text;
                        string query = "select * from Admin where Hex = '" + Hex + "' ";
                        MySqlCommand MyCommand = new MySqlCommand(query, connection);
                        MySqlDataReader MyReader;
                        MyReader = MyCommand.ExecuteReader();
                        while (MyReader.Read())
                        {
                            textBoxID_Admin.Text = MyReader["ID_Admin"].ToString();
                        }
                        connection.Close();

                        try
                        {
                            string ID_Admin = textBoxID_Admin.Text;
                            connection.Open();

                            string sql = "Update VAR set var = ('" + ID_Admin + "') where ID_Var = 1;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();

                            connection.Close();

                            connection.Open();
                            string query1 = "select * from Admin where ID_Admin = '" + ID_Admin + "' ;";
                            MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                            MySqlDataReader MyReader1;
                            MyReader1 = MyCommand1.ExecuteReader();
                            while (MyReader1.Read())
                            {
                                textBoxVarPass.Text = MyReader1["var"].ToString();
                            }
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

                        try
                        {
                            
                            connection.Open();

                            string sql = "Update VAR set var = '2' where ID_Var = 2;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }

                        if (textBoxVarPass.Text == "1")
                        {
                           
                            this.Hide();
                            MudarPass newform = new MudarPass();
                            newform.Show();
                            form.textBoxUtilizador.Text = "Administrador";
                        }
                        else if (textBoxVarPass.Text == "0")
                        {
                            this.Hide();
                            Admin Form = new Admin();
                            Form.Show();

                        }

                    }
                    else if (textBoxVar.Text == "3")//PROFESSOR
                    {
                        connection.Open();
                        string Hex = textBoxHex.Text;
                        string query = "select * from Professor where Hex = '" + Hex + "' ";
                        MySqlCommand MyCommand = new MySqlCommand(query, connection);
                        MySqlDataReader MyReader;
                        MyReader = MyCommand.ExecuteReader();
                        while (MyReader.Read())
                        {
                            textBoxIDProf.Text = MyReader["ID_Professor"].ToString();
                        }
                        connection.Close();
                        string ID_Prof = textBoxIDProf.Text;
                        try
                        {
                            
                            connection.Open();

                            string sql = "Update VAR set var = ('" + ID_Prof + "') where ID_Var = 1;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }

                        connection.Open();
                        string query1 = "select * from Professor where ID_Professor = '" + ID_Prof + "' ;";
                        MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                        MySqlDataReader MyReader1;
                        MyReader1 = MyCommand1.ExecuteReader();
                        while (MyReader1.Read())
                        {
                            textBoxVarPass.Text = MyReader1["var"].ToString();
                        }
                        connection.Close();

                        try
                        {

                            connection.Open();

                            string sql = "Update VAR set var = '3' where ID_Var = 2;";
                            adapter.InsertCommand = new MySqlCommand(sql, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }

                        if (textBoxVarPass.Text == "1")
                        {

                            this.Hide();
                            MudarPass newform = new MudarPass();
                            newform.Show();
                            form.textBoxUtilizador.Text = "Professor";
                        }
                        else if (textBoxVarPass.Text == "0")
                        {
                            this.Hide();
                            Professor Form = new Professor();
                            Form.Show();

                        }
                    }
                    else if (textBoxDe.Text == "0")
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Cartão não registado");
                    }

                }
                dwResult = PODfuncs.ClearPODBuffer(pPOD);
                dwResult = PODfuncs.DisconnectPOD(pPOD);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            EsqueceuPass newform = new EsqueceuPass();
            this.Hide();
            newform.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);
            //var command = connection.CreateCommand();
            MySqlCommand query = new MySqlCommand("select count(*) from Admin where Utilizador = '" + textBoxUtilizador.Text + "' and Pass = '" + textBoxPass.Text + "'", connection);
            connection.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(query);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            da.Fill(dataTable);

            connection.Close();


            //QUERY'S
            MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxUtilizador.Text + "' and Pass = '" + textBoxPass.Text + "'", connection);
            MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxUtilizador.Text + "' and Pass = '" + textBoxPass.Text + "'", connection);
            MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxUtilizador.Text + "' and Pass = '" + textBoxPass.Text + "'", connection);
            MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxUtilizador.Text + "' and Pass = '" + textBoxPass.Text + "'", connection);

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
                    textBoxVar.Text = "1";
                }
                else
                {
                    
                }
            }

            foreach (DataRow list2 in dataTable2.Rows) // Admin
            {
                if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                {
                    textBoxVar.Text = "2";
                }
                else
                {
                    
                }

            }

            foreach (DataRow list3 in dataTable3.Rows) //Professor
            {
                if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                {
                    textBoxVar.Text = "3";
                }
                else
                {
                   
                }
            }


            foreach (DataRow list4 in dataTable4.Rows) //EE
            {
                if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                {
                    textBoxVar.Text = "4";
                }
                else
                {
                   
                }
            }

            string Utilizador = textBoxUtilizador.Text;

            if (textBoxVar.Text == "1") // Aluno
            {
                connection.Open();

                string queryAlHex = "select * from Aluno where Utilizador = '" + Utilizador + "' ";
                MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    textBoxID_Aluno.Text = MyReader["ID_Aluno"].ToString();
                }
                connection.Close();

                connection.Open();
                string query1 = "select * from Aluno where ID_aluno = '" + textBoxID_Aluno.Text + "' ;";
                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    textBoxVarPass.Text = MyReader1["var"].ToString();
                }
                connection.Close();

                try
                {
                    string ID_Aluno = textBoxID_Aluno.Text;
                    connection.Open();

                    string sql = "Update VAR set var = ('" + ID_Aluno + "') where ID_Var = 1;";
                    adapter.InsertCommand = new MySqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

                connection.Open();
                string sql1 = "Update VAR set var = '1' where ID_Var = 2;";
                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                if (textBoxVarPass.Text == "1")
                {

                    this.Hide();
                    MudarPass newform = new MudarPass();
                    newform.Show();
                }
                else if (textBoxVarPass.Text == "0")
                {
                    this.Hide();
                    Aluno Form = new Aluno();
                    Form.Show();

                }
            }
            else if (textBoxVar.Text == "2") // Admin
            {
                connection.Open();

                string queryAlHex = "select * from Admin where Utilizador = '" + Utilizador + "' ";
                MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    textBoxID_Admin.Text = MyReader["ID_Admin"].ToString();
                }
                connection.Close();

                connection.Open();
                string query1 = "select * from Admin where ID_Admin = '" + textBoxID_Admin.Text + "' ;";
                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    textBoxVarPass.Text = MyReader1["var"].ToString();
                }
                connection.Close();

                try
                {
                    string ID_Admin = textBoxID_Admin.Text;
                    connection.Open();

                    string sql = "Update VAR set var = ('" + ID_Admin + "') where ID_Var = 1;";
                    adapter.InsertCommand = new MySqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                connection.Open();
                string sql1 = "Update VAR set var = '2' where ID_Var = 2;";
                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                if (textBoxVarPass.Text == "1")
                {

                    this.Hide();
                    MudarPass newform = new MudarPass();
                    newform.Show();
                }
                else if (textBoxVarPass.Text == "0")
                {
                    this.Hide();
                    Admin Form = new Admin();
                    Form.Show();

                }
            }
            else if (textBoxVar.Text == "3") // Professor
            {
                connection.Open();

                string queryAlHex = "select * from Professor where Utilizador = '" + Utilizador + "' ";
                MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    textBoxIDProf.Text = MyReader["ID_Professor"].ToString();
                }
                connection.Close();

                connection.Open();
                string query1 = "select * from Professor where ID_Professor = '" + textBoxIDProf.Text + "' ;";
                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    textBoxVarPass.Text = MyReader1["var"].ToString();
                }
                connection.Close();

                try
                {
                    string ID_Prof = textBoxIDProf.Text;
                    connection.Open();

                    string sql = "Update VAR set var = ('" + ID_Prof + "') where ID_Var = 1;";
                    adapter.InsertCommand = new MySqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
                connection.Open();
                string sql1 = "Update VAR set var = '3' where ID_Var = 2;";
                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                if (textBoxVarPass.Text == "1")
                {

                    this.Hide();
                    MudarPass newform = new MudarPass();
                    newform.Show();
                }
                else if (textBoxVarPass.Text == "0")
                {
                    this.Hide();
                    Professor Form = new Professor();
                    Form.Show();

                }
            }

            if (textBoxVar.Text == "4") // EE
            {
                connection.Open();

                string ID_EE = textBoxID_EE.Text;
                string queryAlHex = "select * from EE where Utilizador = '" + Utilizador + "' ";
                MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    textBoxID_EE.Text = MyReader["ID_EE"].ToString();
                }
                connection.Close();

                connection.Open();
                string query1 = "select * from EE where ID_EE = '" + ID_EE + "' ;";
                MySqlCommand MyCommand1 = new MySqlCommand(query1, connection);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    textBoxVarPass.Text = MyReader1["var"].ToString();
                }
                connection.Close();

                try
                {
                    
                    connection.Open();

                    string sql = "Update VAR set var = ('" + ID_EE + "') where ID_Var = 1;";
                    adapter.InsertCommand = new MySqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();

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
                connection.Open();

                string sql1 = "Update VAR set var = '4' where ID_Var = 2;";
                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();

                if (textBoxVarPass.Text == "1")
                {

                    this.Hide();
                    MudarPass newform = new MudarPass();
                    newform.Show();
                }
                else if (textBoxVarPass.Text == "0")
                {
                    this.Hide();
                    EE Form = new EE();
                    Form.Show();

                }
            }
            else if (textBoxPass.Text == "" || textBoxUtilizador.Text == "")
            {
                MessageBox.Show("Insira o utilizador e a Password");
            }
            else if (textBoxVar.Text == "")
            {
                MessageBox.Show("Utilizador Incorreto");
            }

        } 
    }
}

