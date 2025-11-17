using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagementSystem
{
    class AddProductsData
    {
        public int ID { set; get; }
        public string ProdID { set; get; }
        public string ProdName { set; get; }
        public string Supplier { set; get; }
        public string Price { set; get; }
        public string Stock { set; get; }
        public string ImagePath { set; get; } // ✅ FIXED: Should be string, not int
        public string Status { set; get; }
        public string Date { set; get; }

        public List<AddProductsData> AllProductsData()
        {
            List<AddProductsData> listData = new List<AddProductsData>();

            using (SqlConnection connect = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Products";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddProductsData uData = new AddProductsData();

                        uData.ID = Convert.ToInt32(reader["id"]);
                        uData.ProdID = reader["prod_id"].ToString();
                        uData.ProdName = reader["prod_name"].ToString();
                        uData.Supplier = reader["supplier"].ToString();
                        uData.Price = reader["price"].ToString();
                        uData.Stock = reader["stock"].ToString();
                        uData.ImagePath = reader["image_path"].ToString(); // ✅ added
                        uData.Status = reader["status"].ToString();
                        uData.Date = reader["date_insert"].ToString();

                        listData.Add(uData);
                    }
                }
            }

            return listData;
        }
        public List<AddProductsData> allAvailableProducts()
        {
            List<AddProductsData> listData = new List<AddProductsData>();
            using (SqlConnection connect = new SqlConnection(
               @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\monle\OneDrive\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Products WHERE status = @status";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@status", "Available");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddProductsData uData = new AddProductsData();

                        uData.ID = Convert.ToInt32(reader["id"]);
                        uData.ProdID = reader["prod_id"].ToString();
                        uData.ProdName = reader["prod_name"].ToString();
                        uData.Supplier = reader["supplier"].ToString();
                        uData.Price = reader["price"].ToString();
                        uData.Stock = reader["stock"].ToString();
                        uData.ImagePath = reader["image_path"].ToString(); // ✅ added
                        uData.Status = reader["status"].ToString();
                        uData.Date = reader["date_insert"].ToString();

                        listData.Add(uData);
                    }
                }
            }

            return listData;
        }
    }
}
