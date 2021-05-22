using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPortal admn = new AdminPortal();
            admn.Show();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Show();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text;
        }
    }
}
