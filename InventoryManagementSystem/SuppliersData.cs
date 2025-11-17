using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagementSystem
{
    class SuppliersData
    {
        public int id { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }

        public List<SuppliersData> AllSupplierData()
        {
            List<SuppliersData> listData = new List<SuppliersData>();

            using (SqlConnection connect = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Suppliers"; // <-- use Suppliers table

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SuppliersData sData = new SuppliersData();
                        sData.id = (int)reader["id"];
                        sData.SupplierName = reader["SupplierName"].ToString();
                        sData.ContactName = reader["ContactName"].ToString();

                        listData.Add(sData);
                    }
                }
            }

            return listData;
        }
    }
}
