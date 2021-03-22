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
using System.Net.Mail;

namespace WindowsFormsApplication6
{
    public partial class EsqueceuPass : Form
    {
        public EsqueceuPass()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            Login newform = new Login();
            this.Hide();
            newform.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string conexao = "Server=localhost;Database=Scholendar;Uid=root";
            var connection = new MySqlConnection(conexao);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //QUERY'S
            MySqlCommand queryAl = new MySqlCommand("select * from Aluno where Utilizador = '" + textBoxNomeUtilizador.Text + "'", connection);
            MySqlCommand queryAd = new MySqlCommand("select * from Admin where Utilizador = '" + textBoxNomeUtilizador.Text + "'", connection);
            MySqlCommand queryProf = new MySqlCommand("select * from Professor where Utilizador = '" + textBoxNomeUtilizador.Text + "'", connection);
            MySqlCommand queryEE = new MySqlCommand("select * from EE where Utilizador = '" + textBoxNomeUtilizador.Text + "'", connection);

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
                    textBoxTipoUtilizador.Text = "Aluno";
                }
                else
                {

                }
            }

            foreach (DataRow list2 in dataTable2.Rows) // Admin
            {
                if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                {
                    textBoxTipoUtilizador.Text = "Administrador";
                }
                else
                {

                }

            }

            foreach (DataRow list3 in dataTable3.Rows) //Professor
            {
                if (Convert.ToInt32(list3.ItemArray[0]) > 0)
                {
                    textBoxTipoUtilizador.Text = "Professor";
                }
                else
                {

                }
            }


            foreach (DataRow list4 in dataTable4.Rows) //EE
            {
                if (Convert.ToInt32(list4.ItemArray[0]) > 0)
                {
                    textBoxTipoUtilizador.Text = "EE";
                }
                else
                {

                }
            }

            string Utilizador = textBoxNomeUtilizador.Text;

            if (textBoxTipoUtilizador.Text == "Aluno") // Aluno
            {
                if (label1.Text == "Insira o seu nome de utilizador :")
                {
                    string query = "select * from Aluno where Utilizador = '" + textBoxNomeUtilizador.Text + "' ";
                    connection.Open();
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxID_Utilizador.Text = MyReader["ID_Aluno"].ToString();
                        textBoxEmail.Text = MyReader["Email"].ToString();
                        textBoxNome.Text = MyReader["Nome"].ToString();
                    }
                    connection.Close();

                    var chars = "0123456789";
                    var stringChars = new char[6];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    string codigo = new String(stringChars);
                    textBoxCodigo.Text = codigo;

                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("scholendar@gmail.com");
                    mail.To.Add(textBoxEmail.Text);
                    mail.Subject = "Mudar a palavra-passe";
                    mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "" + Environment.NewLine + "Seu código de confirmação : " + codigo + "" + Environment.NewLine + "Obrigado!";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show("Foi enviado para o seu email um código de confirmação! Insira o código para criar a nova palavra-passe." + Environment.NewLine + "Aguarde! Esta operação poderá demorar alguns minutos.");
                    label1.Text = "Código : ";
                    textBoxcodigovar.Visible = true;
                    textBoxNomeUtilizador.Visible = false;
                }
                

                else if (label1.Text == "Código : ")
                {
                    if (textBoxcodigovar.Text == textBoxCodigo.Text)
                    {
                        var chars2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars2 = new char[8];
                        var random2 = new Random();

                        for (int i = 0; i < stringChars2.Length; i++)
                        {
                            stringChars2[i] = chars2[random2.Next(chars2.Length)];
                        }

                        string pass = new String(stringChars2);

                        string sql = "update Aluno set pass = '" + pass + "' where ID_aluno = '" + textBoxID_Utilizador.Text + "'";
                        connection.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();

                        connection.Close();
                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("scholendar@gmail.com");
                        mail.To.Add(textBoxEmail.Text);
                        mail.Subject = "Scholendar - Novas Credenciais";
                        mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi atualizada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxNomeUtilizador.Text + Environment.NewLine + "Password - " + pass + Environment.NewLine + "Obrigado!";

                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Foi enviado um email com as novas credenciais. Assim que entrar na conta vai lhe ser pedido para mudar a palavra-passe.");
                        Login newform = new Login();
                        this.Hide();
                        newform.Show();
                    }
                }

            }
            else if (textBoxTipoUtilizador.Text == "Administrador") // Admin
            {
                if (label1.Text == "Insira o seu nome de utilizador :")
                {
                    string query = "select * from Admin where Utilizador = '" + textBoxNomeUtilizador.Text + "' ";
                    connection.Open();
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxID_Utilizador.Text = MyReader["ID_Admin"].ToString();
                        textBoxEmail.Text = MyReader["Email"].ToString();
                        textBoxNome.Text = MyReader["Nome"].ToString();
                    }
                    connection.Close();

                    var chars = "0123456789";
                    var stringChars = new char[6];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    string codigo = new String(stringChars);
                    textBoxCodigo.Text = codigo; 

                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("scholendar@gmail.com");
                    mail.To.Add(textBoxEmail.Text);
                    mail.Subject = "Mudar a palavra-passe";
                    mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "" + Environment.NewLine + "Seu código de confirmação : " + codigo + "" + Environment.NewLine + "Obrigado!";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show("Foi enviado para o seu email um código de confirmação! Insira o código para criar a nova palavra-passe." + Environment.NewLine + "Aguarde! Esta operação poderá demorar alguns minutos.");
                    label1.Text = "Código : ";
                    textBoxcodigovar.Visible = true;
                    textBoxNomeUtilizador.Visible = false;
                }
                

                else if (label1.Text == "Código : ")
                {
                    if (textBoxcodigovar.Text == textBoxCodigo.Text)
                    {
                        var chars2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars2 = new char[8];
                        var random2 = new Random();

                        for (int i = 0; i < stringChars2.Length; i++)
                        {
                            stringChars2[i] = chars2[random2.Next(chars2.Length)];
                        }

                        string pass = new String(stringChars2);

                        string sql = "update Admin set pass = '" + pass + "' where ID_Admin = '" + textBoxID_Utilizador.Text + "'";
                        connection.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();

                        connection.Close();

                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("scholendar@gmail.com");
                        mail.To.Add(textBoxEmail.Text);
                        mail.Subject = "Scholendar - Novas Credenciais";
                        mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi atualizada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxNomeUtilizador.Text + Environment.NewLine + "Password - " + pass + Environment.NewLine + "Obrigado!";

                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Foi enviado um email com as novas credenciais. Assim que entrar na conta vai lhe ser pedido para mudar a palavra-passe.");
                        Login newform = new Login();
                        this.Hide();
                        newform.Show();
                    }
                }
            }
            else if (textBoxTipoUtilizador.Text == "Professor") // Professor
            {
                if (label1.Text == "Insira o seu nome de utilizador :")
                {
                    string query = "select * from Professor where Utilizador = '" + textBoxNomeUtilizador.Text + "' ";
                    connection.Open();
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxID_Utilizador.Text = MyReader["ID_Professor"].ToString();
                        textBoxEmail.Text = MyReader["Email"].ToString();
                    }
                    connection.Close();

                    var chars = "0123456789";
                    var stringChars = new char[6];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    string codigo = new String(stringChars);
                    textBoxCodigo.Text = codigo;

                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("scholendar@gmail.com");
                    mail.To.Add(textBoxEmail.Text);
                    mail.Subject = "Scholendar - Código de Confirmação ";
                    mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "" + Environment.NewLine + "Seu código de confirmação : " + codigo + "" + Environment.NewLine + "Obrigado!";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show("Foi enviado para o seu email um código de confirmação! Insira o código para criar a nova palavra-passe." + Environment.NewLine + "Aguarde! Esta operação poderá demorar alguns minutos.");
                    label1.Text = "Código : ";
                    textBoxcodigovar.Visible = true;
                    textBoxNomeUtilizador.Visible = false;
                }

                else if (label1.Text == "Código : ")
                {
                    if (textBoxcodigovar.Text == textBoxCodigo.Text)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[8];
                        var random = new Random();

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }

                        string pass = new String(stringChars);

                        string sql = "update Professor set pass = '" + pass + "' where ID_Professor = '" + textBoxID_Utilizador.Text + "'";
                        connection.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();

                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("scholendar@gmail.com");
                        mail.To.Add(textBoxEmail.Text);
                        mail.Subject = "Scholendar - Novas Credenciais";
                        mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi atualizada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxNomeUtilizador.Text + Environment.NewLine + "Password - " + pass + Environment.NewLine + "Obrigado!";

                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Foi enviado um email com as novas credenciais. Assim que entrar na conta vai lhe ser pedido para mudar a palavra-passe.");

                        Login newform = new Login();
                        this.Hide();
                        newform.Show();
                    }
                }
            }

            else if (textBoxTipoUtilizador.Text == "EE") // EE
            {
                if (label1.Text == "Insira o seu nome de utilizador :")
                {
                    string query = "select * from EE where Utilizador = '" + textBoxNomeUtilizador.Text + "' ";
                    connection.Open();
                    MySqlCommand MyCommand = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    while (MyReader.Read())
                    {
                        textBoxID_Utilizador.Text = MyReader["ID_EE"].ToString();
                        textBoxEmail.Text = MyReader["Email"].ToString();
                        textBoxNome.Text = MyReader["Nome"].ToString();
                    }
                    connection.Close();
                    //textBoxVar.Text = "";
                    connection.Close();

                    var chars = "0123456789";
                    var stringChars = new char[6];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    string codigo = new String(stringChars);
                    textBoxCodigo.Text = codigo;

                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("scholendar@gmail.com");
                    mail.To.Add(textBoxEmail.Text);
                    mail.Subject = "Mudar a palavra-passe";
                    mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "" + Environment.NewLine + "Seu código de confirmação : " + codigo + "" + Environment.NewLine + "Obrigado!";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show("Foi enviado para o seu email um código de confirmação! Insira o código para criar a nova palavra-passe." + Environment.NewLine + "Aguarde! Esta operação poderá demorar alguns minutos.");
                    label1.Text = "Código : ";
                    textBoxcodigovar.Visible = true;
                    textBoxNomeUtilizador.Visible = false;
                }

                else if (label1.Text == "Código : ")
                {
                    if (textBoxNomeUtilizador.Text == textBoxCodigo.Text)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[8];
                        var random = new Random();

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }

                        string pass = new String(stringChars);

                        string sql = "update EE set pass = '" + pass + "' where ID_EE = '" + textBoxID_Utilizador.Text + "'";
                        connection.Open();
                        adapter.InsertCommand = new MySqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();

                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("scholendar@gmail.com");
                        mail.To.Add(textBoxEmail.Text);
                        mail.Subject = "Scholendar - Novas Credenciais";
                        mail.Body = "Caro/a " + textBoxTipoUtilizador.Text + " " + textBoxNome.Text + "," + Environment.NewLine + "A sua conta Scholendar foi atualizada! Pode aceder à sua conta a partir das seguintes credenciais : " + Environment.NewLine + "Utilizador - " + textBoxNomeUtilizador.Text + Environment.NewLine + "Password - " + pass + Environment.NewLine + "Obrigado!";

                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Foi enviado um email com as novas credenciais. Assim que entrar na conta vai lhe pedir para mudar a palavra-passe.");

                        Login newform = new Login();
                        this.Hide();
                        newform.Show();
                    }
                }

            }
            else if (textBoxTipoUtilizador.Text == "")
            {
                MessageBox.Show("Utilizador não existe");
            }
            }

        private void EsqueceuPass_Load(object sender, EventArgs e)
        {

        }
    }
    }
