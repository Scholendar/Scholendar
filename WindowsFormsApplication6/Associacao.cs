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
    public partial class Associacao : Form
    {

        
        public Associacao()
        {
            InitializeComponent();
            Fillcombobox();
        }

        void ID_Prof_Dentro ()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "Select * from Professor where nome = '" + dataGridViewProfDentro.SelectedCells[0].Value.ToString() + "'; ";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlCommand cmdconnection = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_Prof.Text = MyReader3["ID_Professor"].ToString(); //String com o valor ID_Turma
                }
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

        private void LoadListBox()
        {
            listBoxID_Disciplina.Items.Clear();
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            connection.Open();
            string ID_Prof = textBoxID_Prof.Text;
            string queryIDTurma = "select distinct * from Prof_Disc where ID_professor = '" + ID_Prof + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                listBoxID_Disciplina.Items.Add(MyReader2["ID_Disciplina"].ToString());
            }
            connection.Close();

            foreach (var listBoxItem in listBoxID_Disciplina.Items)
            {
                connection.Open();
                string i = listBoxItem.ToString();

                string query3 = "select * from Disciplina where ID_Disciplina = '" + i + "' ;";
                MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    listBoxDisciplina.Items.Add(MyReader3["Disciplina"].ToString());
                }
                connection.Close();
            }

        }

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
                    comboBox2.Items.Add(sTurma);
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

        private BindingSource LoadDGV2() // Carregar a segunda DGV (Fora)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            string sql = "select Nome from Professor";
            cmd = new MySqlCommand(sql, con);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            
            return bs;
        }

        private BindingSource LoadDGV() // Carregar a primeira DGV (Dentro)
        {
            string ID_Turma = textBox1.Text;
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
        private void pictureBox3_Click(object sender, EventArgs e) // VOLTAR FORM ATRÁS
        {
            this.Hide();
            Admin newform = new Admin();
            newform.Show();
        }

        private void Associacao_Load(object sender, EventArgs e)
        {
            dataGridViewProfFora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProfFora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewProfDentro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProfDentro.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "Server=localhost;Database=Scholendar;Uid=root";
            cnn = new MySqlConnection(connetionString);
            string turma = comboBox2.SelectedItem.ToString();
            string Query = "select * from Turma where Turma ='" + turma + "'"; // QUERY VERIFICAÇÃO TURMA COMBOBOX
            if (comboBox2.SelectedItem != null)
            {
                
                try
                {
                    dataGridViewProfDentro.DataSource = LoadDGV();
                    dataGridViewProfFora.DataSource = LoadDGV2();
                    
                    cnn.Open();
                    MySqlCommand MyCommand3 = new MySqlCommand(Query, cnn);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        textBox1.Text = MyReader3["ID_Turma"].ToString(); //String com o valor ID_Turma
                    }
                    dataGridViewProfDentro.DataSource = LoadDGV();
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

        private void pictureBox1_Click(object sender, EventArgs e) // Adicionar professor à turma
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Escolha em que turma deseja inserir o professor.");
            }
            else
            {
                comboBox2.Enabled = false;
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                string i = dataGridViewProfFora.SelectedCells[0].Value.ToString();
                string query = "Select * from Professor where nome = '" + i + "'; ";
                MySqlConnection connection = new MySqlConnection(Conexao);

                try
                {
                    connection.Open();
                    MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        textBoxID_Prof.Text = MyReader3["ID_Professor"].ToString(); //String com o valor ID_Turma
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

               

                listBoxID_Disciplina.Items.Clear();
                listBoxDisciplina.Items.Clear();
                panelDisciplina.Visible = true;
                LoadListBox();
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Remover Professor da Turma
        {
                ID_Prof_Dentro();

                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string ID_Professor = textBoxID_Prof.Text;
                string ID_Turma = textBox1.Text;
                string query = "delete from Prof_Turma where ID_Professor = ('" + ID_Professor + "') and ID_Turma = ('" + ID_Turma + "');";

                try
                {
                    connection.Open();
                    adapter.InsertCommand = new MySqlCommand(query, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Professor Removido");
                    dataGridViewProfDentro.DataSource = LoadDGV();
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

        private void textBoxID_Prof_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewProfFora_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxConfirmDisc_Click(object sender, EventArgs e)
        {
            if (listBoxDisciplina.SelectedItem == null)
            {
                MessageBox.Show("Insira a disciplina que o professor vai lecionar");
            }
            else
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string ID_Professor = textBoxID_Prof.Text;
                string ID_Turma = textBox1.Text;
                string ID_Disc = textBoxID_Disc.Text;
                string query = "insert into Prof_Turma values('" + ID_Professor + "', '" + ID_Turma + "', '" + ID_Disc + "')";

                try
                {
                    connection.Open();
                    adapter.InsertCommand = new MySqlCommand(query, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Professor Inserido!");
                    dataGridViewProfDentro.DataSource = LoadDGV();
                    panelDisciplina.Visible = false;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    comboBox2.Enabled = true;
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

        private void listBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "Select * from Disciplina where Disciplina = '" + listBoxDisciplina.SelectedItem.ToString() + "'; ";
            MySqlConnection connection = new MySqlConnection(Conexao);

            try
            {
                connection.Open();
                MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_Disc.Text = MyReader3["ID_Disciplina"].ToString(); 
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            panelDisciplina.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            comboBox2.Enabled = true;
        }
    }
}
