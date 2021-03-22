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
using Tulpep.NotificationWindow;

namespace WindowsFormsApplication6
{

    public partial class Aluno : Form
    {

        private void Notificacao()
        {
            listBoxNotificacao.Items.Clear();
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            connection.Open();
            string ID_Aluno = textBoxID_Aluno.Text;
            string queryIDTurma = "select * from Aluno_Evento where ID_Aluno = '" + ID_Aluno + "' and Notificacao = '1';";
            MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                listBoxNotificacao.Items.Add(MyReader2["ID_Evento"].ToString());
            }
            connection.Close();

            if (listBoxNotificacao.Items.Count >= 1)
            {
                pictureBoxNotificacao.Visible = true;
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Notificação";
                popup.ContentText = "Foram Adicionados Eventos Novos";
                popup.Popup();
            }
            else
            {
                pictureBoxNotificacao.Visible = false;
            }

        }

        private void LoadLabelTurma()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            string ID_Turma = textBoxID_Turma.Text;
            string query = "select * from Turma where ID_Turma = '" + ID_Turma + "' ";
            MySqlCommand MyCommand = new MySqlCommand(query, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                labelTurma.Text = MyReader["Turma"].ToString();
            }
        }

        private void LoadPerfil()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            string ID_Aluno = textBoxID_Aluno.Text;
            string query = "select * from Aluno where ID_Aluno = '" + ID_Aluno + "' ";
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
        private void LoadComboBoxDisc()
        {
            string ID_Turma = textBoxID_Turma.Text;
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select Disciplina.Disciplina from Disciplina, prof_turma where prof_turma.ID_turma = '" + ID_Turma + "' and prof_turma.ID_Disciplina = disciplina.ID_Disciplina order by Disciplina;";
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

        public void CriarEvento()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            string ID_Turma = textBoxID_Turma.Text;
            string ID_Disciplina = textBoxID_Disc.Text;
            string Tipo = comboBoxTipo.SelectedItem.ToString();
            string dt_inicio = textBoxInicio.Text;
            string dt_final = textBoxFim.Text;
            string descricao = textBoxDesc.Text;

            string query = "insert into Evento (ID_Turma, ID_Disciplina, Tipo, Dt_Inicio, Dt_Final, Descricao) values('" + ID_Turma + "', '" + ID_Disciplina + "', '" + Tipo + "' ,  '" + dt_inicio + "' ,  '" + dt_final + "' ,  '" + descricao + "');";
            try
            {
                connection.Open();
                adapter.InsertCommand = new MySqlCommand(query, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show((comboBoxTipo.SelectedItem.ToString()) + " Criado");
                


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
            listBoxTdAlunos.Items.Clear();
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            connection.Open();
            string ID_Aluno = textBoxID_Aluno.Text;
            string queryIDTurma = "select * from Aluno where ID_Aluno != '" + ID_Aluno + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                listBoxTdAlunos.Items.Add( MyReader2["Nome"].ToString());
            }
            connection.Close();

        }
        private BindingSource LoadTurma()
        {
            string ID_Turma = textBoxID_Turma.Text;
            string query = "select Nome, Email, Telemovel from Aluno where id_turma = '" + ID_Turma + "' order by nome ;";
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
        public Aluno()
        {
            InitializeComponent();
        }



        private void Aluno_Load(object sender, EventArgs e)
        {


            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            connection.Open();

            string queryAlHex = "select * from VAR where ID_Var = '1';";
            MySqlCommand MyCommand = new MySqlCommand(queryAlHex, connection);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                textBoxID_Aluno.Text = MyReader["var"].ToString();
            }
            connection.Close();

            connection.Open();

            string ID_Aluno = textBoxID_Aluno.Text;
            string queryIDTurma = "select * from Aluno where id_aluno = '" + ID_Aluno + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
                textBoxID_Turma.Text = MyReader2["ID_Turma"].ToString();
            }
            connection.Close();

            dataGridView1.DataSource = LoadTurma();

            LoadComboBoxDisc();
            LoadListBox();
            LoadPerfil();
            Notificacao();
            LoadLabelTurma();
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;


        }

        private BindingSource LoadAgendaT()
        {
            string Hoje = DateTime.Now.ToShortDateString();
            string ID_ALuno = textBoxID_Aluno.Text;
            string query = "select Evento.ID_Evento, Evento.Tipo, Disciplina.Disciplina from Evento, disciplina, aluno_evento where aluno_evento.ID_Aluno = '"+ID_ALuno+ "' and aluno_evento.ID_Evento = evento.ID_Evento and Evento.ID_Disciplina = disciplina.ID_Disciplina and Evento.DT_Final > '"+Hoje+"' order by Evento.dt_inicio;";
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

        private BindingSource LoadAgenda()
        {
            string Hoje = DateTime.Now.ToShortDateString();
            string ID_ALuno = textBoxID_Aluno.Text;
            string ID_Disciplina = textBoxID_Disc1.Text;
            string query = "select Evento.ID_Evento, Evento.Tipo, Disciplina.Disciplina from Evento, disciplina, aluno_evento where aluno_evento.ID_Aluno = '" + ID_ALuno + "' and aluno_evento.ID_Evento = evento.ID_Evento and Evento.ID_Disciplina = disciplina.ID_Disciplina and Evento.ID_Disciplina = '" + ID_Disciplina + "' and Evento.Dt_Final > '" + Hoje + "' order by Evento.dt_inicio;";
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

        void FillcomboboxDisc()
        {
            string ID_Aluno = textBoxID_Aluno.Text;
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select distinct Disciplina.Disciplina from Disciplina, Aluno, Aluno_Evento, Evento where Evento.ID_Disciplina = Disciplina.ID_Disciplina and aluno_evento.ID_Aluno = '" + ID_Aluno + "' and aluno_evento.ID_Evento = Evento.ID_Evento;";
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

                    comboBox1.Items.Add(sDisc);
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

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            FillcomboboxDisc();
            comboBox1.Items.Add("Todas");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Todas")
            {
                dataGridView2.DataSource = "";
                textBoxID_Disc1.Text = "";
                dataGridView2.DataSource = LoadAgendaT();
                this.dataGridView2.Columns["ID_Evento"].Visible = false;

            }
            else
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                connection.Open();

                string Disciplina = comboBox1.SelectedItem.ToString();
                string queryIDTurma = "select * from Disciplina where Disciplina = '" + Disciplina + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(queryIDTurma, connection);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    textBoxID_Disc1.Text = MyReader2["ID_Disciplina"].ToString();
                }
                connection.Close();

                dataGridView2.DataSource = "";

                dataGridView2.DataSource = LoadAgenda();

                this.dataGridView2.Columns["ID_Evento"].Visible = false;
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string select = dataGridView2.SelectedCells[0].Value.ToString();

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
                textBoxID_Turma2.Text = MyReader["ID_Turma"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Teste";
            popup.ContentText = "Teste123";
            popup.Popup();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private Exit form = new Exit();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBoxUtilizador.Text = "Aluno";
            form.textBox1.Text = textBoxUtilizador.Text;
            form.Show();

        }

        private void textBoxUtilizador_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBoxNotificacao.Visible == true)
            {
                tabControl1.SelectedTab = tabPage2;

                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string id_Aluno = textBoxID_Aluno.Text;

                connection.Open();

                string query = "update Aluno_Evento set notificacao = 0 where id_Aluno = '" + id_Aluno + "'";
                adapter.InsertCommand = new MySqlCommand(query, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();

                Notificacao();
            }
            else
            {
                tabControl1.SelectedTab = tabPage2;
            }
            
        }

        private void listBoxSelecAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxSelecAlunos_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (listBoxTdAlunos.SelectedItem == null)
            {
                MessageBox.Show("Seleciona o aluno");
            }
            else
            {
                listBoxIDAluno.Items.Clear();
                listBoxSelecAlunos.Items.Add(listBoxTdAlunos.SelectedItem);
                //listBoxTdAlunos.Items.Clear();
                //LoadListBox();
                listBoxTdAlunos.Items.Remove(listBoxTdAlunos.SelectedItem);

                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                foreach (var listBoxItem in listBoxSelecAlunos.Items)
                {
                    connection.Open();
                    string i = listBoxItem.ToString();

                    string query3 = "select * from Aluno where Nome = '" + i + "' ;";
                    MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        listBoxIDAluno.Items.Add(MyReader3["ID_Aluno"].ToString());
                    }
                    connection.Close();
                }
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (listBoxSelecAlunos.SelectedItem == null)
            {
                MessageBox.Show("Seleciona o aluno que queres remover");
            }
            else
            {
                listBoxIDAluno.Items.Clear();
                listBoxTdAlunos.Items.Add(listBoxSelecAlunos.SelectedItem);
                listBoxSelecAlunos.Items.Remove(listBoxSelecAlunos.SelectedItem);

                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                foreach (var listBoxItem in listBoxSelecAlunos.Items)
                {
                    connection.Open();
                    string i = listBoxItem.ToString();

                    string query3 = "select * from Aluno where Nome = '" + i + "' ;";
                    MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        listBoxIDAluno.Items.Add(MyReader3["ID_Aluno"].ToString());
                    }
                    connection.Close();
                }
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxID_Turma_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxIDAluno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= DateTime.Today)
            {
                textBoxInicio.Text = dateTimePicker1.Value.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Não podes selecionar uma data inferior à de hoje!");
            }
        }

        private void textBoxInicio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInicio.Text))
            {
                MessageBox.Show("Insere primeiramente a data inicial");
            }
            else
            {
                DateTime Inicial = Convert.ToDateTime(textBoxInicio.Text);
                //DateTime Final = Convert.ToDateTime();
                if (Inicial > dateTimePicker1.Value)
                {
                    MessageBox.Show("A data final não pode ser antes da data inicial");
                }
                else
                {
                    textBoxFim.Text = dateTimePicker1.Value.ToShortDateString();
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textBoxDesc.Text = "";
            textBoxInicio.Text = "";
            textBoxFim.Text = "";
            comboBoxDisc.SelectedItem = null;
            comboBoxTipo.SelectedItem = null;
            listBoxSelecAlunos.Items.Clear();
            listBoxIDAluno.Items.Clear();
            LoadListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (comboBoxDisc.SelectedItem == null || comboBoxTipo.SelectedItem == null || textBoxDesc.Text == "" || textBoxInicio.Text == "")
            {
                MessageBox.Show("Tens que preencher todos os parâmetros " + Environment.NewLine + "(O prazo final não é obrigatório)");
            }
            else
            {
                if (textBoxFim.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Não queres acrescentar um prazo final", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        if (listBoxSelecAlunos.Items.Count == 0)
                        {
                            DialogResult dialogResult2 = MessageBox.Show("Não queres partilhar este evento com nenhum colega?", "", MessageBoxButtons.YesNo);
                            if (dialogResult2 == DialogResult.Yes)
                            {

                            }
                            else if (dialogResult2 == DialogResult.No)
                            {
                                connection.Open();
                                CriarEvento();

                                string ID_Turma = textBoxID_Turma.Text;
                                string ID_Disciplina = textBoxID_Disc.Text;
                                string Tipo = comboBoxTipo.SelectedItem.ToString();
                                string dt_inicio = textBoxInicio.Text;
                                string dt_final = textBoxFim.Text;
                                string descricao = textBoxDesc.Text;

                                string query2 = "select * from Evento where ID_Turma = '" + ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and DT_Inicio = '" + dt_inicio + "' and dt_Final = '" + dt_final + "' and Descricao = '" + descricao + "' ";

                                MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);
                                
                                MySqlDataReader MyReader2;
                                MyReader2 = MyCommand2.ExecuteReader();
                                while (MyReader2.Read())
                                {
                                    textBoxID_Evento.Text = MyReader2["ID_Evento"].ToString();
                                }
                                connection.Close();

                                string ID_Aluno = textBoxID_Aluno.Text;
                                string ID_Evento = textBoxID_Evento.Text;

                                string query3 = "insert into Aluno_Evento (ID_Aluno, ID_Evento,notificacao) values ('" + ID_Aluno + "','" + ID_Evento + "','1')";

                                connection.Open();
                                adapter.InsertCommand = new MySqlCommand(query3, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();
                                Clear();
                            }
                        }
                        else
                        {
                            connection.Open();
                            CriarEvento();

                            string ID_Turma = textBoxID_Turma.Text;
                            string ID_Disciplina = textBoxID_Disc.Text;
                            string Tipo = comboBoxTipo.SelectedItem.ToString();
                            string dt_inicio = textBoxInicio.Text;
                            string dt_final = textBoxFim.Text;
                            string descricao = textBoxDesc.Text;

                            string query2 = "select * from Evento where ID_Turma = '" + ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and DT_Inicio = '" + dt_inicio + "' and dt_Final = '" + dt_final + "' and Descricao = '" + descricao + "' ";

                            MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);

                            MySqlDataReader MyReader2;
                            MyReader2 = MyCommand2.ExecuteReader();
                            while (MyReader2.Read())
                            {
                                textBoxID_Evento.Text = MyReader2["ID_Evento"].ToString();
                            }
                            connection.Close();

                            string ID_Aluno = textBoxID_Aluno.Text;
                            string ID_Evento = textBoxID_Evento.Text;

                            string query3 = "insert into Aluno_Evento (ID_Aluno, ID_Evento,notificacao) values ('" + ID_Aluno + "','" + ID_Evento + "','0')";

                            connection.Open();
                            adapter.InsertCommand = new MySqlCommand(query3, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            connection.Close();

                            foreach (var listBoxItem in listBoxIDAluno.Items)
                            {
                                connection.Open();
                                string i = listBoxItem.ToString();

                                string query4 = "insert into Aluno_Evento (ID_Aluno, ID_Evento, notificacao) values ('" + i + "','" + ID_Evento + "', '1');";
                                adapter.InsertCommand = new MySqlCommand(query4, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();
                            }
                            Clear();
                        }
                    }

                }
                else
                {
                    if (listBoxSelecAlunos.Items.Count == 0)
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Não queres partilhar este evento com nenhum colega?", "", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {

                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            connection.Open();
                            CriarEvento();

                            string ID_Turma = textBoxID_Turma.Text;
                            string ID_Disciplina = textBoxID_Disc.Text;
                            string Tipo = comboBoxTipo.SelectedItem.ToString();
                            string dt_inicio = textBoxInicio.Text;
                            string dt_final = textBoxFim.Text;
                            string descricao = textBoxDesc.Text;

                            string query2 = "select * from Evento where ID_Turma = '" + ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and DT_Inicio = '" + dt_inicio + "' and dt_Final = '" + dt_final + "' and Descricao = '" + descricao + "' ";

                            MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);

                            MySqlDataReader MyReader2;
                            MyReader2 = MyCommand2.ExecuteReader();
                            while (MyReader2.Read())
                            {
                                textBoxID_Evento.Text = MyReader2["ID_Evento"].ToString();
                            }
                            connection.Close();

                            string ID_Aluno = textBoxID_Aluno.Text;
                            string ID_Evento = textBoxID_Evento.Text;

                            string query3 = "insert into Aluno_Evento (ID_Aluno, ID_Evento,notificacao) values ('" + ID_Aluno + "','" + ID_Evento + "','0')";

                            connection.Open();
                            adapter.InsertCommand = new MySqlCommand(query3, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            connection.Close();
                            Clear();
                        }
                    }
                    else
                    {
                        connection.Open();
                        CriarEvento();

                        string ID_Turma = textBoxID_Turma.Text;
                        string ID_Disciplina = textBoxID_Disc.Text;
                        string Tipo = comboBoxTipo.SelectedItem.ToString();
                        string dt_inicio = textBoxInicio.Text;
                        string dt_final = textBoxFim.Text;
                        string descricao = textBoxDesc.Text;

                        string query2 = "select * from Evento where ID_Turma = '" + ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and DT_Inicio = '" + dt_inicio + "' and dt_Final = '" + dt_final + "' and Descricao = '" + descricao + "' ";

                        MySqlCommand MyCommand2 = new MySqlCommand(query2, connection);

                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxID_Evento.Text = MyReader2["ID_Evento"].ToString();
                        }
                        connection.Close();

                        string ID_Aluno = textBoxID_Aluno.Text;
                        string ID_Evento = textBoxID_Evento.Text;

                        string query3 = "insert into Aluno_Evento (ID_Aluno, ID_Evento,notificacao) values ('" + ID_Aluno + "','" + ID_Evento + "','0')";

                        connection.Open();
                        adapter.InsertCommand = new MySqlCommand(query3, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();

                        foreach (var listBoxItem in listBoxIDAluno.Items)
                        {
                            connection.Open();
                            string i = listBoxItem.ToString();

                            string query4 = "insert into Aluno_Evento (ID_Aluno, ID_Evento,notificacao) values ('" + i + "','" + ID_Evento + "','1');";
                            adapter.InsertCommand = new MySqlCommand(query4, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                        Clear();
                    }
                }
            }
        }

        private void comboBoxDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            if (comboBoxDisc.SelectedItem == null)
            {

            }
            else
            {
                connection.Open();
                string Disc = comboBoxDisc.SelectedItem.ToString();
                string query3 = "select * from Disciplina where Disciplina = '" + Disc + "' ;";
                MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_Disc.Text = (MyReader3["ID_Disciplina"].ToString());
                }
                connection.Close();
            }
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBoxNotificacao_Click(object sender, EventArgs e)
        {

            
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count <= 0)
            {
                return;
            }

            string select = dataGridView2.SelectedCells[0].Value.ToString();

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
                textBoxID_Turma2.Text = MyReader["ID_Turma"].ToString();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
