using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class Stock : Form
    {
        ViewMed viewM = new ViewMed();
        UpdtMed updt = new UpdtMed();
        EditingMed edt = new EditingMed();
        public Stock()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(viewM);
            panel3.Controls["ViewMed"].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Remove(viewM);
            panel3.Controls.Remove(updt);
        }

        private void updt_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(updt);
            panel3.Controls["UpdtMed"].BringToFront();

          
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine m = new Medicine();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill b = new GenerateBill();
            b.Show();
        }
    }
}
