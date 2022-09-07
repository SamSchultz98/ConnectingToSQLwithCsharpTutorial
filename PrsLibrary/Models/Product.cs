using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string? Photopath { get; set; }
        public int VendorsId { get; set; }
        public virtual Vendor Vendor { get; set; }

       
       
        public static string SqlSelectByPk = "Select * from Products Where Id = @Id;";

        public static void SetSqlParameterId(SqlCommand cmd, int id)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }



        public static void LoadFromReader(Product product, SqlDataReader reader)        //This is to make the code more readable, not as much clutter 

        {
            product.Id = Convert.ToInt32(reader["Id"]);
            product.PartNbr = Convert.ToString(reader["PartNbr"]);
            product.Name = Convert.ToString(reader["Name"]);
            product.Price = Convert.ToDecimal(reader["Price"]);
            product.Photopath = Convert.ToString(reader["Photopath"]);
            product.VendorsId = Convert.ToInt32(reader["VendorsId"]);
         
        }



        public void LoadFromReader(SqlDataReader reader)
        {
            LoadFromReader(this, reader);       //This identifies which one is the method

        }


        public static string SqlDelete = $"Delete From Products where id = @id;";

        public static string SqlInsert =
            " INSERT Into Products " +
            " (PartNbr, Name, Price, Unit, Photopath, VendorId ) " +
            " VALUES " +
            " (@PartNbr, @Name, @Price, @Unit, @Photopath, @VendorId ) ";


            public void SetSqlParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PartNbr", PartNbr);
            cmd.Parameters.AddWithValue("@Name",Name);
            cmd.Parameters.AddWithValue("@Price",Price);
            cmd.Parameters.AddWithValue("@Unit",Unit);
            cmd.Parameters.AddWithValue("@Photopath", Photopath);
            cmd.Parameters.AddWithValue("@VendorId",VendorsId);
            SetSqlParameters(cmd);

        }

        public static string SqlUpdate =
            "UPDATE Products Set" +
            " PartNbr= @PartNbr, " +
            " Name = @Name, " +
            " Price = @Price, " +
            " Unit = @Unit, " +
            "Photopath = @Photopath, " +
            " VendorId = @VendorId, " +
            " Where ID = @Id;";
        
        public static string SqlSelectAll =
            " select * from Products; ";



      
    }
}
