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
    public partial class CriarTurma : Form
    {
        public CriarTurma()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCiclo.SelectedItem.ToString() == "1º Ciclo")
            {
                radioButtonProfissional.Visible = false;
                radioButtonRegular.Visible = false;
                comboBoxAno.Items.Clear();
                comboBoxAno.Items.Add("1");
                comboBoxAno.Items.Add("2");
                comboBoxAno.Items.Add("3");
                comboBoxAno.Items.Add("4");
                comboBoxAno.SelectedItem = null;
            }
            else if (comboBoxCiclo.SelectedItem.ToString() == "2º Ciclo ")
            {
                radioButtonProfissional.Visible = false;
                radioButtonRegular.Visible = false;
                comboBoxAno.Items.Clear();
                comboBoxAno.Items.Add("5");
                comboBoxAno.Items.Add("6");
                comboBoxAno.SelectedItem = null;
            }
            else if (comboBoxCiclo.SelectedItem.ToString() == "3º Ciclo")
            {
                radioButtonProfissional.Text = "Profissionalizante";
                radioButtonProfissional.Visible = true;
                radioButtonRegular.Visible = true;
                comboBoxAno.Items.Clear();
                comboBoxAno.Items.Add("7");
                comboBoxAno.Items.Add("8");
                comboBoxAno.Items.Add("9");
                comboBoxAno.SelectedItem = null;
            }
            else if (comboBoxCiclo.SelectedItem.ToString() == "Secundário")
            {
                radioButtonProfissional.Text = "Profissional";
                radioButtonProfissional.Visible = true;
                radioButtonRegular.Visible = true;
                comboBoxAno.Items.Clear();
                comboBoxAno.Items.Add("10");
                comboBoxAno.Items.Add("11");
                comboBoxAno.Items.Add("12");
                comboBoxAno.SelectedItem = null;
            }
        }

        private void buttonCriar_Click(object sender, EventArgs e)
        {
            if (comboBoxAno.SelectedItem == null || textBoxLetra.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                string connetionString = null;
                MySqlConnection cnn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql = null;

                connetionString = "Server=localhost;Database=Scholendar;Uid=root";

                string AnoEscolar = comboBoxAno.SelectedItem.ToString();
                string Letra = textBoxLetra.Text;
                string Ver = "select * from Turma where AnoEscolar = '" + comboBoxAno.SelectedItem.ToString() + "' and Letra = '" + textBoxLetra.Text + "'";
                string Turma = comboBoxAno.SelectedItem.ToString() + " " + textBoxLetra.Text;



                cnn = new MySqlConnection(connetionString);

                cnn.Open();
                MySqlCommand query = new MySqlCommand(Ver, cnn);
                MySqlDataReader da = query.ExecuteReader();
                while (da.Read())
                {
                    MessageBox.Show("Já existe essa turma!");
                    textBoxLetra.Text = "";
                    return;
                }

                cnn.Close();

                if (radioButtonProfissional.Visible == true)
                {
                    if (radioButtonProfissional.Checked && comboBoxCiclo.SelectedItem.ToString() == "3º Ciclo")
                    {
                        sql = "insert into Turma (AnoEscolar, Letra, Turma, Tipo) values('" + AnoEscolar + "', '" + Letra + "', '" + Turma + "' , 'Profissionalizante'  )";

                        try
                        {
                            
                            cnn.Open();
                            adapter.InsertCommand = new MySqlCommand(sql, cnn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            MessageBox.Show("Turma Criada");
                            textBoxLetra.Text = "";
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

                    else if (radioButtonProfissional.Checked && comboBoxCiclo.SelectedItem.ToString() == "Secundário")
                    {
                        sql = "insert into Turma (AnoEscolar, Letra, Turma, Tipo) values('" + AnoEscolar + "', '" + Letra + "', '" + Turma + "' , 'Profissional'  )";

                        try
                        {
                            cnn.Open();
                            adapter.InsertCommand = new MySqlCommand(sql, cnn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            MessageBox.Show("Turma Criada");
                            textBoxLetra.Text = "";
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
                    else if (radioButtonRegular.Checked)
                    {
                        sql = "insert into Turma (AnoEscolar, Letra, Turma, tipo) values('" + AnoEscolar + "', '" + Letra + "', '" + Turma + "' , 'Regular'  )";

                        try
                        {
                            cnn.Open();
                            adapter.InsertCommand = new MySqlCommand(sql, cnn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            MessageBox.Show("Turma Criada");
                            textBoxLetra.Text = "";
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
                else
                {
                    sql = "insert into Turma (AnoEscolar, Letra, Turma, Tipo) values('" + AnoEscolar + "', '" + Letra + "', '" + Turma + "', 'Regular'  )";

                    try
                    {
                        cnn.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Turma Criada");
                        textBoxLetra.Text = "";
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Admin newform = new Admin();
            this.Hide();
            newform.Show();
        }
    }
}
