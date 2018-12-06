using System;
using System.Data.SqlClient;

namespace ADONetConnecting
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET is technically MS's umbrella name for all data-related libraries
            // incl Entity Framework
            // but when we say ADO.NET we typically are talking about older stuff.
            // DataReader, DataAdapter objects

            // in various GUIs, you need server URL, login, password
            // in code, we have developed a convention to use what we call a connection string
            // which will jam all that data into one string

            // never commit your connection strings to source control like git.
            var ConnectionString = SecretConfiguration.ConnectionString;

            var commandString = "SELECT * FROM Movies.Movie";

            using (var connection = new SqlConnection(ConnectionString)) 
            {
                // connected architecture 
                // step 1: open the connection
                connection.Open();
                // step 2: execute query
                using (var command = new SqlCommand(commandString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // step 3 process results
                    while (reader.Read())
                    {
                        var id = reader["ID"]; // access values by column name
                        var name = reader["Name"];
                        Console.WriteLine($"ID: {id}, Name: {name}");
                    }
                }
                // step 4: close the connection
                connection.Close();

            }


        }
    }
}
