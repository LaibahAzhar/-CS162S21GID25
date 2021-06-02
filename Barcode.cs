using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.Barcode;
using BasselTech_CamCapture;

namespace dashboard
{
    public partial class Barcode : Form
    {
        Camera cam;
        Timer t;
        BackgroundWorker worker;
        Bitmap CapImage;
        public Barcode()
        {
            InitializeComponent();

            t = new Timer();
            cam = new Camera(pictureBox1);
            worker = new BackgroundWorker();

            worker.DoWork += Worker_DoWork;
            t.Tick += T_Tick;
            t.Interval = 1;
        }
        private void T_Tick(object sender, EventArgs e)
        {
            CapImage = cam.GetBitmap();
            if (CapImage != null && !worker.IsBusy)
                worker.RunWorkerAsync();
        }

        //method to decode the barcode
        private void Worker_DoWork(Object sender, DoWorkEventArgs e)
        {
            //barcode Decoder object

            BarcodeDecoder decoder = new BarcodeDecoder();

            try
            {
                string decoded_text = decoder.Decode(CapImage).Text;

                if (decoded_text == "FALAH Pharmacy")
                {
                    this.Hide();
                    Done don = new Done();
                    don.Show();
                }
                else
                {

                    WarnMsg warn = new WarnMsg();
                    warn.Show();
                }
            }
            catch (Exception)
            {

            }

        }

        private void scanbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                cam.Start();
                t.Start();
                stopbtn.Enabled = true;
                scanbtn.Enabled = false;
            }
            catch (Exception ex)
            {
                cam.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void stopbtn_Click_1(object sender, EventArgs e)
        {
            t.Stop();
            cam.Stop();
            stopbtn.Enabled = false;
            scanbtn.Enabled = true;
        }
    }
}
