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
        private string medicineName;
        private string medicineID;
        private string chemicalName;
        private DateTime manufacturingDate;
        private DateTime expiryDate;
        private string compnany;
        private int marketPrice;
        private int sellingPrice;
        private string category;
        private string status;
        public string MedicineName
        {
            get;set;
        }
        public string MedicineID
        {
            get; set;
        }
        public string ChemicalName
        {
            get; set;
        }
        public string Company
        {
            get; set;
        }
        public int MarketPrice
        {
            get; set;
        }
        public int SellingPrice
        {
            get; set;
        }
        public string Category
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public DateTime ManufacturingDate
        {
            get; set;
        }
        //public DateTime ExpiryDate;
        //{
        //    get; set;
        //}
        

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

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
