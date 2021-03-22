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
    public partial class EE : Form
    {
        public EE()
        {
            InitializeComponent();
        }

        private void LoadListBox()
        {
            listBoxID_Turma.Items.Clear();
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);


            connection.Open();
            string ID_EE = textBoxID_EE.Text;
            string queryIDTurma = "select * from Aluno where ID_EE = '" + ID_EE + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                listBoxID_Turma.Items.Add(MyReader2["ID_Turma"].ToString());
            }
            connection.Close();

            
            foreach (var listBoxItem in listBoxID_Turma.Items)
            {
                connection.Open();
                string i = listBoxItem.ToString();

                string query3 = "select * from Turma where ID_Turma = '" + i + "' order by AnoEscolar;";
                MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    comboBox1.Items.Add(MyReader3["Turma"].ToString());
                }
                connection.Close();
            }
        }

        private void EducandoCombo()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);


            connection.Open();
            string ID_EE = textBoxID_EE.Text;
            string query3 = "select * from aluno where ID_EE = '" + ID_EE + "';";
            MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
            MySqlDataReader MyReader3;
            MyReader3 = MyCommand3.ExecuteReader();
            while (MyReader3.Read())
            {
                comboBoxEducando.Items.Add(MyReader3["Nome"].ToString());
            }
            connection.Close();

        }

        private BindingSource LoadTurma()
        {
            string ID_Turma = textBoxID_Turma.Text;
            string query = "select Nome, DataDeNascimento from Aluno where id_turma = '" + ID_Turma + "' and ID_EE = '"+textBoxID_EE.Text+"' order by nome ;";
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();


                cmd = new MySqlCommand(query, connection);

                Adapter.SelectCommand = cmd;
                Adapter.Fill(ds);

                bs.DataSource = ds.Tables[0];
                connection.Close();
                

            return bs;
        }



        private BindingSource LoadAgendaT()
        {
            string ID_Aluno = textBoxID_Educando.Text;
            string query = "select Evento.ID_Evento, Evento.Tipo, Disciplina.Disciplina from Evento, disciplina, aluno_evento where aluno_evento.ID_Aluno = '" + ID_Aluno + "' and aluno_evento.ID_Evento = evento.ID_Evento and Evento.ID_Disciplina = disciplina.ID_Disciplina order by Evento.dt_inicio;";
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            dataGridViewEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEventos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            cmd = new MySqlCommand(query, connection);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            connection.Close();
            return bs;
        }

        private void LoadPerfil()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            string ID_EE = textBoxID_EE.Text;
            string query = "select * from EE where ID_EE = '" + ID_EE + "' ";
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

        private void EE_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);

            connection.Open();

            string queryAlHex = "select * from VAR where ID_Var = '1';";
            MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxID_EE.Text = MyReader["var"].ToString();
            }
            connection.Close();

            LoadListBox();

            dataGridViewTurma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTurma.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewEventos.DataSource = LoadAgendaT();
            EducandoCombo();
            LoadPerfil();
        }

        private Exit form = new Exit();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBoxUtilizador.Text = "EE";
            form.textBox1.Text = textBoxUtilizador.Text;
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            connection.Open();
            string Turma = comboBox1.SelectedItem.ToString();

            string query3 = "select * from Turma where Turma = '" + Turma + "';";
            MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
            MySqlDataReader MyReader3;
            MyReader3 = MyCommand3.ExecuteReader();
            while (MyReader3.Read())
            {
               textBoxID_Turma.Text = MyReader3["ID_Turma"].ToString();
            }
            connection.Close();

            dataGridViewTurma.DataSource = LoadTurma();
        }

        private void comboBoxTurma2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            connection.Open();

            string Educando = comboBoxEducando.Text.ToString();
            string queryAlHex = "select * from Aluno where nome = '" + Educando + "';";
            MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxID_Educando.Text = MyReader["ID_Aluno"].ToString();
            }

            dataGridViewEventos.DataSource = "";
            dataGridViewEventos.DataSource = LoadAgendaT();

            
            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void dataGridViewEventos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEventos.SelectedCells.Count <= 0)
            {
                return;
            }
           
            string select = dataGridViewEventos.SelectedCells[0].Value.ToString();
            this.dataGridViewEventos.Columns["ID_Evento"].Visible = false;

            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();

            string query = "select * from Evento where ID_Evento = '" + select + "' ";
            MySqlCommand MyCommand = new MySqlCommand(query, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxDt_Inicio.Text = MyReader["Dt_Inicio"].ToString();
                textBoxDt_Final.Text = MyReader["Dt_Final"].ToString();
                textBoxID_Disc2.Text = MyReader["ID_Disciplina"].ToString();
                textBoxDesc_Agenda.Text = MyReader["Descricao"].ToString();
            }
            connection.Close();

            connection.Open();

            string ID_Disc = textBoxID_Disc2.Text;
            string query2 = "select Disciplina from Disciplina where ID_Disciplina = '" + ID_Disc + "' ;";
            MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                textBoxDisciplina.Text = MyReader2["Disciplina"].ToString();
            }
            connection.Close();
        }
    }
}
