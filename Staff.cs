﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class Staff : Form
    {
        ViewStaff vew = new ViewStaff();
        UpdtEmp upd = new UpdtEmp();
        public Staff()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(upd);
            panel3.Controls["UpdtEmp"].BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(vew);
            panel3.Controls["ViewStaff"].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Remove(vew);
            panel3.Controls.Remove(upd);
        }
    }
}