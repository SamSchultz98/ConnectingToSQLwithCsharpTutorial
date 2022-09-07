using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PrsLibrary.Models;
using PrsLibrary.Controllers;


namespace PrsLibrary.Controllers
{
    public class VendorsController
    {
        public Connection connection = null;
     
        
        public VendorsController(Connection conn)
        {
            connection = conn;
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            string sql = "Select * from Vendors;";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Vendor> vendors = new();
            while (reader.Read())
            {
                Vendor vendor = new();
                vendor.Id = Convert.ToInt32(reader["Id"]);
                vendor.Code = Convert.ToString(reader["Code"]);
                vendor.Name = Convert.ToString(reader["Name"]);
                vendor.Address = Convert.ToString(reader["Address"]);
                vendor.City = Convert.ToString(reader["City"]);
                vendor.State = Convert.ToString(reader["State"]);
                if (reader["Phone"] == System.DBNull.Value)
                {
                    vendor.Phone = null;
                }
                else vendor.Phone = Convert.ToString(reader["Phone"]);
                
                if (reader["Email"] == System.DBNull.Value)
                {
                    vendor.Email = null;
                }
                else vendor.Email = Convert.ToString(reader["Email"]);
                vendors.Add(vendor);
            }
            reader.Close();
            return vendors;
        }
        public Vendor? GetByPk(int id)
        {
            string sql = $"Select * from Vendors where ID = {id};";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
            Vendor vendor = new Vendor();
            vendor.Id = Convert.ToInt32(reader["ID"]);
            vendor.Code = Convert.ToString(reader["Code"]);
            vendor.Name = Convert.ToString(reader["Name"]);
            vendor.Address = Convert.ToString(reader["Address"]);
            vendor.City = Convert.ToString(reader["City"]);
            vendor.State = Convert.ToString(reader["State"]);
            if (reader["Phone"] == System.DBNull.Value)
            {
                vendor.Phone = null;
            }
            else vendor.Phone = Convert.ToString(reader["Phone"]);

            if (reader["Email"] == System.DBNull.Value)
            {
                vendor.Email = null;
            }
            else vendor.Email = Convert.ToString(reader["Email"]);
            
        
        reader.Close();
            return vendor;
            
        }
        
        public bool Delete(int id)
        {
            string sql = $"Delete from vendors where ID = {id};";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        }
        
        public bool Insert(Vendor vendor)
        {
            string sql = " INSERT into Vendors" + " ( Code,Name,Address,City,State,Phone,Email) " + " VALUES " +
                "( @Code, @Name, @Address, @City, @State, @Phone, @Email );";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@Email", vendor.Email);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        }
    }
}
