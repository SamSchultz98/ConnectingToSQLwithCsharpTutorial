using Microsoft.Data.SqlClient;

namespace PrsLibrary
{
    public class Connection
    {
        private string connectionString = @"server=localhost\sqlexpress;" +
                                "database =Exercise;trusted_connection=true;" +             //You can have spaces around the equal signs
                                "trustServerCertificate=true;";                 //This last one may not be needed, new in windows 11

        public Microsoft.Data.SqlClient.SqlConnection? sqlconnection { get; set; }      //got the microsoft data stuff from NuGet from tools

        public void connect()
        {
            if(sqlconnection is not null)
            {
                System.Diagnostics.Debug.WriteLine("Connection already established");
                return;
            }
            sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();                                                      //Have to declare it open. It attempts to connect to the database
            if(sqlconnection.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Could not make connection to database!");
            }
            System.Diagnostics.Debug.WriteLine("Connection opened successfully!");
        }

        public void SelectSql(string sql)             //Using this one whenever we use a select statement in sql
        {
            sql = "SELECT * from Users;";
            SqlCommand sqlCommand = new(sql, sqlconnection);           //connection is the open connection in our library 
            SqlDataReader reader = sqlCommand.ExecuteReader();                         //Function of sql command that does a read statement
            while (reader.Read())                                      //True if there is data to read, false if there is no more data to read from
            {
                int id =Convert.ToInt32(reader["ID"]);
                string username = Convert.ToString(reader["Username"]);
                string firstname = Convert.ToString(reader["Firstname"]);
                string lastname = Convert.ToString(reader["Lastname"]);
                System.Diagnostics.Debug.WriteLine($"{id} | {username} | {firstname} | {lastname}");
            }
            reader.Close();                     //HAVE TO CLOSE READER, CAN ONLY HAVE ONE OPEN AT A TIME
        }

        public void disconnect()
        {
            if(sqlconnection is not null)          //Is not is more descriptive than !=, do is not null when you can
            {
                sqlconnection.Close();
                sqlconnection = null;
            }
        }

        
    }
}