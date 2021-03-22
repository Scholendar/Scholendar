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
    public partial class Professor : Form
    {
        public Professor()
        {
            InitializeComponent();
        }

        private void CriarEvento()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string ID_Turma = textBoxID_Turma3.Text;
            string ID_Disciplina = textBoxID_Disc3.Text;
            string Tipo = comboBoxTipo3.SelectedItem.ToString();
            string Inicio = textBoxInicio.Text;
            string Fim = textBoxFim.Text;
            string Descricao = textBoxDesc3.Text;

            string query = "insert into Evento (ID_Turma, ID_Disciplina, Tipo, Dt_Inicio, Dt_Final, Descricao) values('" + ID_Turma + "', '" + ID_Disciplina + "', '" + Tipo + "' ,  '" + Inicio + "' ,  '" + Fim + "' ,  '" + Descricao + "');";
            try
            {
                connection.Open();
                adapter.InsertCommand = new MySqlCommand(query, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show((comboBoxTipo3.SelectedItem.ToString()) + " Criado");



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

        void Clear()
        {
            comboBoxDisc3.SelectedItem = null;
            comboBoxTipo3.SelectedItem = null;
            comboBoxTurma3.SelectedItem = null;
            textBoxDesc3.Text = "";
            textBoxInicio.Text = "";
            textBoxFim.Text = "";
            listBoxIDAluno.Items.Clear();
        }

        private BindingSource LoadAgenda()
        {
            string Hoje = DateTime.Now.ToShortDateString();
            string ID_Professor = textBoxID_Prof.Text;
            string query = "select distinct Evento.Tipo, Turma.turma, disciplina.disciplina, Evento.ID_Evento from Evento, Turma, Disciplina, Professor_Evento where professor_evento.ID_Professor = '" + ID_Professor + "' and Evento.ID_Disciplina = disciplina.ID_Disciplina and Evento.ID_Turma = Turma.ID_Turma and Evento.ID_Evento = Professor_Evento.ID_Evento and Evento.Dt_Final > '" + Hoje + "' ;";
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

            //string ID_Professor = textBoxID_Prof.Text;
            //string Conexao = "SERVER=localhost;" + "DATABASE=escola;" + "UID=root;";
            //string query = "select * from Evento where ID_Professor = '"+ ID_Professor + "' order by DT_inicio ;";
            //MySqlConnection connection = new MySqlConnection(Conexao);
            //MySqlCommand cmdconnection = new MySqlCommand(query, connection);
            //MySqlDataReader myReader;
            //try
            //{
            //    connection.Open();
            //    myReader = cmdconnection.ExecuteReader();

            //    while (myReader.Read())
            //    {
            //        string sTipo = myReader.GetString("Tipo");
            //        //listBox1.Items.Add(sTipo);
            //        dataGridView2.DataSource = sTipo;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }

        private void LoadPerfil()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            string ID_Professor = textBoxID_Prof.Text;

            string query = "select * from Professor where ID_Professor = '" + ID_Professor + "' ";
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


        private void Professor_Load(object sender, EventArgs e)
        {

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
                textBoxID_Prof.Text = MyReader["var"].ToString();
            }
            connection.Close();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewEventosTurma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEventosTurma.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;



            LoadPerfil();
            
        }

        void FillcomboboxDisc()
        {
            string ID_Prof = textBoxID_Prof.Text;
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string query = "select disciplina.disciplina from disciplina, professor, prof_turma where disciplina.ID_Disciplina=prof_turma.ID_Disciplina and prof_turma.ID_Professor = '"+ID_Prof+"' and prof_turma.ID_Turma = '"+comboBoxTurma3.SelectedItem.ToString()+"';";
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

                    comboBoxDisc3.Items.Add(sDisc);
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

        public void LoadComboTurma()
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            string ID_Professor = textBoxID_Prof.Text;
            string query = "select distinct turma from Turma inner join prof_turma on prof_turma.ID_Turma = turma.ID_Turma and prof_turma.ID_Professor = '" + ID_Professor + "' order by Turma;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlCommand cmdconnection = new MySqlCommand(query, connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = cmdconnection.ExecuteReader();

                while (myReader.Read())
                {
                    string sDisc = myReader.GetString("Turma");
                    comboBox1.Items.Add(sDisc);
                    comboBoxTurma3.Items.Add(sDisc);
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

        private BindingSource LoadEventosTurma() 
        {
            string ID_Turma = textBoxID_Turma3.Text;
            string Query2 = "select Evento.ID_Evento, Evento.Tipo, Disciplina.Disciplina, Evento.Dt_Inicio from Evento, disciplina where Tipo = 'Teste' and ID_Turma = '" + ID_Turma + "' and Evento.ID_Disciplina=Disciplina.ID_Disciplina or Tipo = 'Ficha' and ID_Turma = '" + ID_Turma + "' and Evento.ID_Disciplina=Disciplina.ID_Disciplina ; ";
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();


            cmd = new MySqlCommand(Query2, connection);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            connection.Close();
            return bs;

        }

        private BindingSource LoadDGV() // Carregar a primeira DGV (Dentro)
        {
            string ID_Turma = textBoxID_Turma.Text;
            string Query2 = "select Nome, DataDeNascimento, Email, Telemovel from Aluno where ID_Turma = '" + ID_Turma + "' order by Nome;";
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            connection.Open();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();


            cmd = new MySqlCommand(Query2, connection);

            Adapter.SelectCommand = cmd;
            Adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            connection.Close();
            return bs;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            string Turma = comboBox1.SelectedItem.ToString();
            string query = "SELECT * from Turma where Turma = '" + Turma + "';";
            

            if (comboBox1.SelectedItem != null)
            {
                try
                {
                    dataGridView1.DataSource = LoadDGV();
                    connection.Open();
                    MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader3;
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {
                        textBoxID_Turma.Text = MyReader3["ID_Turma"].ToString(); //String com o valor ID_Turma
                        dataGridView1.DataSource = LoadDGV();
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
            }
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            LoadComboTurma();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = LoadAgenda();
            this.dataGridView2.Columns["ID_Evento"].Visible = false;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string select = dataGridView2.SelectedCells[3].Value.ToString();

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

            connection.Open();

            string ID_Turma = textBoxID_Turma2.Text;
            string query3 = "select Turma from Turma where ID_Turma = '" + ID_Turma + "' ;";
            MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
            MySqlDataReader MyReader3;
            MyReader3 = MyCommand3.ExecuteReader();
            while (MyReader3.Read())
            {
                textBoxTurmaAgenda.Text = MyReader3["Turma"].ToString();
            }
            connection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Exit form = new Exit();

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBoxUtilizador.Text = "Professor";
            form.textBox1.Text = textBoxUtilizador.Text;
            form.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabPage1;

        private void pictureBox6_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabPage2;

        private void textBoxID_Evento_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            if (comboBoxTipo3.SelectedItem == null || comboBoxTurma3.SelectedItem == null || comboBoxDisc3.SelectedItem == null || textBoxDesc3.Text == "" || textBoxInicio.Text == "")
            {
                MessageBox.Show("Preencha todos os parâmetros");
            }
            else
            {
                if (textBoxFim.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Não quer adicionar prazo final ao Evento?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        connection.Open();
                        CriarEvento();
                        

                        string ID_Turma = textBoxID_Turma3.Text;
                        string ID_Disciplina = textBoxID_Disc3.Text;
                        string Tipo = comboBoxTipo3.SelectedItem.ToString();
                        string Inicio = textBoxInicio.Text;
                        string Fim = textBoxFim.Text;
                        string Descricao = textBoxDesc3.Text;

                        string query = "select * from Evento where ID_Turma = '"+ ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and dt_inicio = '" + Inicio + "' and dt_final = '" + Fim + "' and Descricao = '" + Descricao + "'";
                        MySqlCommand MyCommand2 = new MySqlCommand(query, connection);

                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                            textBoxID_Evento3.Text = MyReader2["ID_Evento"].ToString();
                        }
                        connection.Close();

                        connection.Open();
                        string ID_Evento = textBoxID_Evento3.Text;
                        string ID_Professor = textBoxID_Prof.Text;
                        string query2 = "insert into professor_Evento values ('" + ID_Evento + "', '" + ID_Professor + "','0')";
                        adapter.InsertCommand = new MySqlCommand(query2, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();

                        if (listBoxID_AlunoEspecifico.Items.Count == 0)
                        {
                            connection.Open();

                            string query3 = "select * from Aluno where ID_Turma = '" + ID_Turma + "' ;";
                            MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                            MySqlDataReader MyReader3;
                            MyReader3 = MyCommand3.ExecuteReader();
                            while (MyReader3.Read())
                            {
                                listBoxIDAluno.Items.Add((MyReader3["ID_Aluno"].ToString()));
                            }

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
                        }
                        else
                        {
                            foreach (var listBoxItem in listBoxID_AlunoEspecifico.Items)
                            {
                                connection.Open();
                                string i = listBoxItem.ToString();

                                string query5 = "insert into Aluno_Evento (ID_Aluno, ID_Evento, notificacao) values ('" + i + "','" + ID_Evento + "', '1');";
                                adapter.InsertCommand = new MySqlCommand(query5, connection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                        

                        Clear();
                        dataGridView2.DataSource = LoadAgenda();
                        dataGridViewEventosTurma.DataSource = LoadEventosTurma();
                        listBoxAdicionar.Items.Clear();
                        listBoxID_AlunoEspecifico.Items.Clear();

                    }
                }
                else
                {
                    connection.Open();
                    CriarEvento();
                    

                    string ID_Turma = textBoxID_Turma3.Text;
                    string ID_Disciplina = textBoxID_Disc3.Text;
                    string Tipo = comboBoxTipo3.SelectedItem.ToString();
                    string Inicio = textBoxInicio.Text;
                    string Fim = textBoxFim.Text;
                    string Descricao = textBoxDesc3.Text;

                    string query = "select * from Evento where ID_Turma = '" + ID_Turma + "' and ID_Disciplina = '" + ID_Disciplina + "' and Tipo = '" + Tipo + "' and dt_inicio = '" + Inicio + "' and dt_final = '" + Fim + "' and Descricao = '" + Descricao + "'";
                    MySqlCommand MyCommand2 = new MySqlCommand(query, connection);

                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                        textBoxID_Evento3.Text = MyReader2["ID_Evento"].ToString();
                    }
                    connection.Close();

                    connection.Open();
                    string ID_Evento = textBoxID_Evento3.Text;
                    string ID_Professor = textBoxID_Prof.Text;
                    string query2 = "insert into professor_Evento values ('" + ID_Evento + "', '" + ID_Professor + "',1)";
                    adapter.InsertCommand = new MySqlCommand(query2, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();

                    if (listBoxID_AlunoEspecifico.Items.Count == 0)
                    {
                        connection.Open();

                        string query3 = "select * from Aluno where ID_Turma = '" + ID_Turma + "' ;";
                        MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                        MySqlDataReader MyReader3;
                        MyReader3 = MyCommand3.ExecuteReader();
                        while (MyReader3.Read())
                        {
                            listBoxIDAluno.Items.Add((MyReader3["ID_Aluno"].ToString()));
                        }

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
                    }
                    else
                    {
                        foreach (var listBoxItem in listBoxID_AlunoEspecifico.Items)
                        {
                            connection.Open();
                            string i = listBoxItem.ToString();

                            string query4 = "insert into Aluno_Evento (ID_Aluno, ID_Evento, notificacao) values ('" + i + "','" + ID_Evento + "', '1');";
                            adapter.InsertCommand = new MySqlCommand(query4, connection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    //Clear();
                    dataGridView2.DataSource = LoadAgenda();
                    dataGridViewEventosTurma.DataSource = LoadEventosTurma();
                    listBoxAdicionar.Items.Clear();
                    listBoxID_AlunoEspecifico.Items.Clear();
                }
            }
            
        }

        private void textBoxID_Disc3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            if (comboBoxTurma3.SelectedItem == null)
            {
                MessageBox.Show("Selecione a turma primeiro.");
            }
            else
            {
                comboBoxDisc3.Items.Clear();
                FillcomboboxDisc();
            }
            
        }

        private void comboBoxTurma3_DropDown(object sender, EventArgs e)
        {
            comboBoxTurma3.Items.Clear();
            LoadComboTurma();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date >= DateTime.Today)
            {
                textBoxInicio.Text = dateTimePicker2.Value.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Não pode selecionar uma data inferior à de hoje!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInicio.Text))
            {
                MessageBox.Show("Insira primeiramente a data inicial");
            }
            else
            {
                DateTime Inicial = Convert.ToDateTime(textBoxInicio.Text);
                //DateTime Final = Convert.ToDateTime();
                if (Inicial > dateTimePicker2.Value)
                {
                    MessageBox.Show("A data final não pode ser antes da data inicial");
                }
                else
                {
                    textBoxFim.Text = dateTimePicker2.Value.ToShortDateString();
                }
            }

            
        }

        private void comboBoxDisc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            if (comboBoxDisc3.SelectedItem == null)
            {

            }
            else
            {
                connection.Open();
                string Disc = comboBoxDisc3.SelectedItem.ToString();
                string query3 = "select * from Disciplina where Disciplina = '" + Disc + "' ;";
                MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_Disc3.Text = (MyReader3["ID_Disciplina"].ToString());
                }
                connection.Close();
            }
        }

        private void comboBoxTurma3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
            MySqlConnection connection = new MySqlConnection(Conexao);

            if (comboBoxTurma3.SelectedItem == null)
            {

            }
            else
            {
                
                connection.Open();
                string Turma = comboBoxTurma3.SelectedItem.ToString();
                string query3 = "select * from Turma where Turma = '" + Turma + "' ;";
                MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_Turma3.Text = MyReader3["ID_Turma"].ToString();
                }
                connection.Close();
                dataGridViewEventosTurma.DataSource = LoadEventosTurma();
                this.dataGridViewEventosTurma.Columns["ID_Evento"].Visible = false;

                listBoxAluno.Items.Clear();
                connection.Close();
                connection.Open();

                string query = "select Nome from Aluno where ID_Turma = '" + textBoxID_Turma3.Text + "'";
                MySqlCommand MyCommand = new MySqlCommand(query, connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    listBoxAluno.Items.Add(MyReader.GetString("Nome"));
                }
                connection.Close();

                listBoxAdicionar.Items.Clear();
                listBoxID_AlunoEspecifico.Items.Clear();
        }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count <= 0)
            {
                return;
            }
            string select = dataGridView2.SelectedCells[3].Value.ToString();

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

            connection.Open();

            string ID_Turma = textBoxID_Turma2.Text;
            string query3 = "select Turma from Turma where ID_Turma = '" + ID_Turma + "' ;";
            MySqlCommand MyCommand3 = new MySqlCommand(query3, connection);
            MySqlDataReader MyReader3;
            MyReader3 = MyCommand3.ExecuteReader();
            while (MyReader3.Read())
            {
                textBoxTurmaAgenda.Text = MyReader3["Turma"].ToString();
            }
            connection.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Today = DateTime.Now.ToShortDateString();
            MessageBox.Show(Today);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBoxTurma3.SelectedItem == null)
            {
                MessageBox.Show("Selecione a turma dos alunos");
            }
            else
            {
                panel2.Visible = true;
                pictureBox1.Visible = false;
                pictureBox8.Visible = true;
                pictureBox13.Visible = true;

                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                connection.Open();


                connection.Close();
            }
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pictureBox1.Visible = true;
            pictureBox8.Visible = false;
            pictureBox13.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e) // ADICIONAR
        {
            textBoxValidacao.Text = "1"; // Ativo

            if (listBoxAluno.SelectedItem != null)
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                connection.Open();

                string query = "select * from Aluno where Nome = '" + listBoxAluno.SelectedItem.ToString() + "'";

                MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    listBoxID_AlunoEspecifico.Items.Add(MyReader3["ID_Aluno"].ToString());
                }
                connection.Close();


                listBoxAdicionar.Items.Add(listBoxAluno.SelectedItem.ToString());
                listBoxAluno.Items.Remove(listBoxAluno.SelectedItem.ToString());
            }
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (listBoxAdicionar.SelectedItem != null)
            {
                string Conexao = "SERVER=localhost;" + "DATABASE=Scholendar;" + "UID=root;";
                MySqlConnection connection = new MySqlConnection(Conexao);
                connection.Open();

                string query = "select * from Aluno where Nome = '" + listBoxAdicionar.SelectedItem.ToString() + "'";

                MySqlCommand MyCommand3 = new MySqlCommand(query, connection);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while (MyReader3.Read())
                {
                    textBoxID_AlunoEspecifico.Text = MyReader3["ID_Aluno"].ToString();
                }
                connection.Close();

                textBoxValidacao.Text = "0"; //Inativo
                listBoxAluno.Items.Add(listBoxAdicionar.SelectedItem.ToString());
                listBoxAdicionar.Items.Remove(listBoxAdicionar.SelectedItem.ToString());
                listBoxID_AlunoEspecifico.Items.Remove(textBoxID_AlunoEspecifico.Text);
            }
           

            //if (textBoxValidacao.Text == "1")
            //{
                
            //}
        }

        private void listBoxAdicionar_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void listBoxAdicionar_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
