using Microsoft.Data.SqlClient;
using PrsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers
{
    public class ProductsController
    {
        public readonly Connection connection = null;
        private VendorsController vendCtrl = null;
        //readonly allows this variable to not be changed
        //Read only: You can initilize in a constructor but you can not anywhere else
        public ProductsController(Connection conn)
        {   
            connection = conn;
            vendCtrl = new(connection);
        }
        public IEnumerable<Product> GetAll()
        {
            string sql = Product.SqlSelectAll;
            SqlCommand cmd = new(sql, connection.sqlconnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> Products = new();
            while (reader.Read())
            {
                Product product = new();
                Product.LoadFromReader(product, reader);
                Products.Add(product);
            }
            reader.Close();
            foreach(Product p in Products)
            {
                p.Vendor = vendCtrl.GetByPk(p.VendorsId);
            }
            return Products;

        }
        public Product? GetByPk(int id)
        {
            string sql = Product.SqlSelectByPk;
            SqlCommand cmd = new(sql, connection.sqlconnection);
            Product.SetSqlParameterId(cmd, id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
            Product product = new();
            Product.LoadFromReader(product, reader);
            reader.Close();
            product.Vendor = vendCtrl.GetByPk(product.VendorsId);
            return product;



            reader.Close();
            return product;
        }
        public bool Delete(int id)
        {
            string sql = Product.SqlDelete;
            SqlCommand cmd = new(sql, connection.sqlconnection);
            Product.SetSqlParameterId(cmd, id);
            int rowsAffected= cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
            
        }

        public bool Update(Product product)
        {
            string sql = Product.SqlUpdate;
            SqlCommand cmd = new(sql, connection.sqlconnection);
            product.SetSqlParameters(cmd);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        }

        public bool Insert(Product product)
        {
            string sql = Product.SqlInsert;
            SqlCommand cmd = new(sql, connection.sqlconnection);
            product.SetSqlParameters(cmd);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;

        }

        
    }

    
}
