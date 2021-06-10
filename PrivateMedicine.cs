using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace dashboard
{
    class PrivateMedicine : PrescriptedMedicine
    {
        override
        public void AddDataInList(Medicines med)
        {
            medList.Add(med);
        }
        override
        public void AddDataInDataBase(Medicines med)
        {
            SqlConnection con = new SqlConnection(Configuration.conection);
            try
            {
                con.Open();

                string insertCommand = "INSERT INTO MedicineTable (MedicineName,MedicineID,ChemicalName,Stock,ManufacturingDate,ExpiryDate,MarketPrice,SellingPrice,Company,Status) VALUES (@MedicineName,@MedicineID,@ChemicalName ,@Stock ,@ManufacturingDate,@ExpiryDate ,@MarketPrice,@SellingPrice,@Company ,@Status )";
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MedicineName", med.MedicineName);
                    cmd.Parameters.AddWithValue("@MedicineID", med.MedicineID);
                    cmd.Parameters.AddWithValue("@ChemicalName", med.ChemicalName);
                    cmd.Parameters.AddWithValue("@Stock", med.Stock);
                    cmd.Parameters.AddWithValue("@ManufacturingDate", med.ManufacturingDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", med.ExpiryDate);
                    cmd.Parameters.AddWithValue("@MarketPrice", med.MarketPrice);
                    cmd.Parameters.AddWithValue("@SellingPrice", med.SellingPrice);
                    cmd.Parameters.AddWithValue("@Company", med.Company);
                    cmd.Parameters.AddWithValue("@Status", med.Stock);

                    cmd.ExecuteNonQuery();


                }
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
    }
}
