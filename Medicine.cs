using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class Medicine : Form
    {
        ViewMed view = new ViewMed();
        public Medicine()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            panel3.Controls.Add(view);
            panel3.Controls["ViewMed"].BringToFront();
            

        }

        private void button8_Click(object sender, EventArgs e)
        {   
            panel3.Controls.Remove(view);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill b = new GenerateBill();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
        }
    }
}
