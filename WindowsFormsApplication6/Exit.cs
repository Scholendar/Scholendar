using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login newform = new Login();
            newform.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Aluno")
            {
                this.Hide();
                Aluno newform = new Aluno();
                newform.Show();
            }

            else if (textBox1.Text == "Professor")
            {
                this.Hide();
                Professor newform = new Professor();
                newform.Show();
            }

            else if (textBox1.Text == "Administrador")
            {
                this.Hide();
                Admin newform = new Admin();
                newform.Show();
            }
            else if (textBox1.Text == "EE")
            {
                this.Hide();
                EE newform = new EE();
                newform.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Exit_Load(object sender, EventArgs e)
        {

        }
    }
}
