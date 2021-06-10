using System;
using System.Collections.Generic;
using System.Text;

namespace dashboard
{
    abstract class Medicines
    {
        public static Medicine med;
        public Medicines(){
             medList = new List<Medicines>();
            }
        protected string medicineName;
        protected string medicineID;
        protected string chemicalName;
        protected DateTime manufacturingDate;
        protected DateTime expiryDate;
        protected string compnany;
        protected int marketPrice;
        protected int stock;
        protected int sellingPrice;
        protected string category;
        protected string status;
        protected private List<Medicines> medList;
        public static Medicine getObject()
        {
            if (med == null)
            {
                med = new Medicine();
            }
            return med;
        }

        public string MedicineName
        {
            get; set;
        }
        public string MedicineID
        {
            get; set;
        }
        public int Stock
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
        public DateTime ExpiryDate
        {
            get; set;
        }
        abstract public void AddDataInList(Medicines med);
        abstract public void AddDataInDataBase(Medicines med);



    }
}
