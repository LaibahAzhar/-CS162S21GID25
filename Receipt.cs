using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.IO;


namespace dashboard
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            textBoxDate.Text = Convert.ToString(now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (var bmp = new Bitmap(Invoice.Width, Invoice.Height))
                {
                    Invoice.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@"ReceiptRecord/" + textBoxName.Text + ".bmp");
                }

                Done done = new Done();
                done.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                MessageBox.Show(message);
            }




        }
    }
}
