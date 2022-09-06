using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PrsLibrary.Models;

namespace PrsLibrary.Controllers
{


    public class UsersController
    {
        public Connection connection = null;

        public UsersController(Connection conn)
        {
            connection = conn;
        }

        public IEnumerable<User> GetAllUsers()                   //This will make an collection of users and send it to the reader
        {
            string sql = "SELECT * from Users;";
            SqlCommand cmd = new(sql, connection.sqlconnection);                               //Sql stament first, then connection
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new();
            while (reader.Read())                           //This indicates for each row of data there is, create a new user for each instance
            {
                User user = new();
                user.ID = Convert.ToInt32(reader["ID"]);
                user.Username = Convert.ToString(reader["Username"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.Firstname = Convert.ToString(reader["Firstname"]);
                user.Lastname = Convert.ToString(reader["Lastname"]);
                if (reader["Phone"] == System.DBNull.Value)                             //This is how you handle a null value
                {
                    user.Phone = null;
                }
                else
                {
                    user.Phone = Convert.ToInt64(reader["Phone"]);
                }
                if (reader["Phone"] == System.DBNull.Value)                             //This is how you handle a null value
                {
                    user.Email = null;
                }
                else
                {
                    user.Email = Convert.ToString(reader["Email"]);
                }
                user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                users.Add(user);


            }
            reader.Close();
            return users;
        }

        public User? GetByPk(int id)
        {
            {
                string sql = $"SELECT * from Users Where ID = {id};";
                SqlCommand cmd = new(sql, connection.sqlconnection);                               //Sql stament first, then connection
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }
                //This indicates for each row of data there is, create a new user for each instance
                reader.Read();
                User user = new();
                user.ID = Convert.ToInt32(reader["ID"]);
                user.Username = Convert.ToString(reader["Username"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.Firstname = Convert.ToString(reader["Firstname"]);
                user.Lastname = Convert.ToString(reader["Lastname"]);
                if (reader["Phone"] == System.DBNull.Value)                             //This is how you handle a null value
                {
                    user.Phone = null;
                }
                else
                {
                    user.Phone = Convert.ToInt64(reader["Phone"]);
                }
                if (reader["Phone"] == System.DBNull.Value)                             //This is how you handle a null value
                {
                    user.Email = null;
                }
                else
                {
                    user.Email = Convert.ToString(reader["Email"]);
                }
                user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);




                reader.Close();
                return user;
            }
        }
        public bool Delete(int id)
        {
            string sql = $"Delete from users where ID = {id};";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        }
        public bool Insert(User user)
        {
            string sql = " INSERT into users " + " ( Username,Password,Firstname,Lastname,Phone,Email,IsReviewer,IsAdmin) " + " VALUES " +
                "( @Username, @Password,@Firstname, @Lastname, "
                + " @Phone,@Email,@IsReviewer,@IsAdmin );";
            SqlCommand cmd = new(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        
        }
        public bool Update(User user)
        {
            string sql = " UPDATE users SET " +
                "Username = @Username, " +
                "Password = @Password, " +
                "Firstname = @Firstname, " +
                "Lastname = @Lastname, " +
                "Phone = @Phone, " +
                "Email = @Email, " +
                "IsReviewer = @IsReviewer, " +
                "IsAdmin = @IsAdmin " +
                " Where Id = @Id;";

            SqlCommand cmd = new(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            cmd.Parameters.AddWithValue("@Id", user.ID);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return false;
            }
            return true;
        
        }
      
    }

}

