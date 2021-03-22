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
    public partial class MudarPass : Form
    {
        public MudarPass()
        {
            InitializeComponent();
        }



        private void MudarPass_Load(object sender, EventArgs e)
        {
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);

            connection.Open();
            string query = "select * from var where ID_var = '2' ";
            MySqlCommand MyCommand = new MySqlCommand(query, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxUtilizador.Text = MyReader["var"].ToString();
            }
            connection.Close();

            connection.Open();
            string query2 = "select * from var where ID_var = '1' ";
            MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                textBoxID_Utilizador.Text = MyReader2["var"].ToString();
            }
            connection.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBoxPassVelha.PasswordChar == '*')
            {
                textBoxPassVelha.PasswordChar = '\0';
            }
            else if (textBoxPassVelha.PasswordChar == '\0')
            {
                textBoxPassVelha.PasswordChar = '*';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBoxPassNova1.PasswordChar == '*')
            {
                textBoxPassNova1.PasswordChar = '\0';
            }
            else if (textBoxPassNova1.PasswordChar == '\0')
            {
                textBoxPassNova1.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            if (textBoxPassNova1.Text == "" || textBoxPassNova2.Text == "" || textBoxPassVelha.Text == "")
            {
                MessageBox.Show("Preencha todas as palavra-passe.");
            }
            else
            {
                if (textBoxPassNova1.Text == textBoxPassNova2.Text)
                {
                    pictureBox5.Visible = false;
                    if (textBoxUtilizador.Text == "1") // Aluno
                    {
                        connection.Open();
                        string ID_Aluno = textBoxID_Utilizador.Text;
                        string query2 = "select * from Aluno where ID_Aluno = '" + ID_Aluno + "' ";
                        MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxVerPassVelha.Text = MyReader2["pass"].ToString();
                        }
                        connection.Close();

                        if (textBoxPassVelha.Text == textBoxVerPassVelha.Text)
                        {
                            pictureBox4.Visible = false;

                            try
                            {

                                connection.Open();
                                string sql = "Update Aluno set pass = '" + textBoxPassNova2.Text + "' where ID_Aluno = '" + ID_Aluno + "';";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();


                                connection.Open();
                                string sql1 = "Update Aluno set var = '0' where ID_Aluno = '" + ID_Aluno + "';";
                                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                connection.Close();

                                this.Close();
                                Aluno newform = new Aluno();
                                newform.Show();
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
                        else
                        {
                            pictureBox4.Visible = true;
                        }

                    }

                    else if (textBoxUtilizador.Text == "2") // Admin
                    {
                        connection.Open();
                        string ID_Admin = textBoxID_Utilizador.Text;
                        string query2 = "select * from Admin where ID_Admin = '" + ID_Admin + "' ";
                        MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxVerPassVelha.Text = MyReader2["pass"].ToString();
                        }
                        connection.Close();

                        if (textBoxPassVelha.Text == textBoxVerPassVelha.Text)
                        {
                            pictureBox4.Visible = false;

                            try
                            {

                                connection.Open();
                                string sql = "Update Admin set pass = '" + textBoxPassNova2.Text + "' where ID_Admin = '" + ID_Admin + "';";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();


                                connection.Open();
                                string sql1 = "Update Admin set var = '0' where ID_Admin = '" + ID_Admin + "';";
                                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                connection.Close();

                                this.Close();
                                Admin newform = new Admin();
                                newform.Show();
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
                        else
                        {
                            pictureBox4.Visible = true;
                        }

                    }

                    else if (textBoxUtilizador.Text == "3") // Professor
                    {
                        connection.Open();
                        string ID_Professor = textBoxID_Utilizador.Text;
                        string query2 = "select * from Professor where ID_Professor = '" + ID_Professor + "' ";
                        MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxVerPassVelha.Text = MyReader2["pass"].ToString();
                        }
                        connection.Close();

                        if (textBoxPassVelha.Text == textBoxVerPassVelha.Text)
                        {
                            pictureBox4.Visible = false;

                            try
                            {
                                connection.Open();
                                string sql = "Update Professor set pass = '" + textBoxPassNova2.Text + "' where ID_Professor = '" + ID_Professor + "';";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();


                                connection.Open();
                                string sql1 = "Update Professor set var = '0' where ID_Professor = '" + ID_Professor + "';";
                                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                connection.Close();

                                this.Close();
                                Professor newform = new Professor();
                                newform.Show();
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
                        else
                        {
                            pictureBox4.Visible = true;
                        }
                    }
                    else if (textBoxUtilizador.Text == "4") // EE
                    {
                        connection.Open();
                        string ID_EE = textBoxID_Utilizador.Text;
                        string query2 = "select * from EE where ID_EE = '" + ID_EE + "' ";
                        MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxVerPassVelha.Text = MyReader2["pass"].ToString();
                        }
                        connection.Close();

                        if (textBoxPassVelha.Text == textBoxVerPassVelha.Text)
                        {
                            pictureBox4.Visible = false;

                            try
                            {
                                connection.Open();
                                string sql = "Update EE set pass = '" + textBoxPassNova2.Text + "' where ID_EE = '" + ID_EE + "';";
                                adapter.InsertCommand = new MySqlCommand(sql, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();


                                connection.Open();
                                string sql1 = "Update EE set var = '0' where ID_EE = '" + ID_EE + "';";
                                adapter.InsertCommand = new MySqlCommand(sql1, connection);
                                adapter.InsertCommand.ExecuteNonQuery();

                                connection.Close();

                                this.Close();
                                EE newform = new EE();
                                newform.Show();
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
                        else
                        {
                            pictureBox4.Visible = true;
                        }
                    }
                    else
                    {
                        pictureBox5.Visible = true;
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
