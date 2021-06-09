using System;
using System.Windows.Forms;

namespace dashboard
{
    public partial class StaffPortal : Form
    {
        public StaffPortal()
        {
            InitializeComponent();
        }

        private void Medbtn_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Show();
        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            stk.Show();
        }

        private void billingbtn_Click(object sender, EventArgs e)
        {
            GenerateBill bil = new GenerateBill();
            bil.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Dispose();
            log.Show();

        }

        private void StaffPortal_Load(object sender, EventArgs e)
        {
            label4.Text = Login.UserName;
        }
    }
}
