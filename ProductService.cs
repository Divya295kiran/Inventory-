using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Inventory.Models;

namespace Inventory
{
    public  class ProductService
    {
         private string _connectionString = "Server=DESKTOP-GDG7CCB\\SQLEXPRESS;Database=Inventory;Integrated Security=true;"; // creating sql connection string
        private readonly ObservableCollection<Product> _products = new ObservableCollection<Product>();
        
        public ProductService()
        {
            _products = new ObservableCollection<Product>();
        }

        #region DisplayOperation
        public ObservableCollection<Product> GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    _products.Clear();
                    SqlCommand cmd = new SqlCommand("DisplayProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(); 
                    while (reader.Read())
                    {
                        _products.Add(new Product
                        {
                            Id = (int)reader["ProductId"],
                            ProductName = reader["Product Name"].ToString(),
                            ProductDescription = reader["ProductDescription"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Price = Convert.ToInt32(reader["Price"]),
                            ProductType = reader["ProductType"].ToString(),
                            ShipmentStatus = reader["ShipmentStatus"].ToString()
                        }
                        );
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return _products;
        }
        #endregion

        #region SaveOperation
        public int Save(Product product)
        { 
            int count=0;
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product cannot be null");
                }
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("InsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ProductType", product.ProductType);
                    cmd.Parameters.AddWithValue("@ShipmentStatus", product.ShipmentStatus);
                    count =  cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return count;
        }
        #endregion

        #region UpdateOperation
        public int Update(Product product)
        {
            int count = 0;
            try
            {
                
                if (product.Id == 0) 
                { 
                    throw new ArgumentException($"Product with Id {product.Id} not found."); 
                }
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", product.Id);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ProductType", product.ProductType);
                    cmd.Parameters.AddWithValue("@ShipmentStatus", product.ShipmentStatus);
                    count= cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return count;

        }
        #endregion


        #region DeleteOperation
        public int Remove(int id)
        {
            int count = 0;
            try
            {
                
                if (id == 0) 
                { 
                    throw new ArgumentException($"Product with Id {id} not found."); 
                }
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", id);
                    count = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return count;

        }
        #endregion


    }
}
