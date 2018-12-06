using System;
using System.Data;
using System.Data.SqlClient;

namespace ADLNETDisconected
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // never commit your connection strings to source control like git.
            var ConnectionString = SecretConfiguration.ConnectionString;

            //var commandString = "SELECT * FROM Movies.Movie";

            Console.WriteLine("Enter name of movie:");
            // be careful; can drop tables and such
            var input = Console.ReadLine();
            var commandString = $"Select * from Movies.Movie where name = '{input}';";
            // unsanitized user input must not be used to construct SQL queries
            // or you'll get haxxored


            // disconnected architecture - get it all
            // load into dataset
            // process

            // more overhead on the C# side but keeps connection open for less time
            // which is good because the DB is usually the bottleneck

            var dataSet = new DataSet(); // will hold our results.

            using (var connection = new SqlConnection(ConnectionString))
            {
                // disconnected architecture 
                // step 1: open the connection
                connection.Open();
                // step 2: execute query
                using (var command = new SqlCommand(commandString, connection))
                // command.ExecuteReader for SELECT queries that return things
                // command.ExecuteNonQuery for all other commands
                using (var adaptor = new SqlDataAdapter(command))
                {
                    // step 3: fill dataset
                    adaptor.Fill(dataSet);
                    // still uses DataReader object internally
                }
                // step 4: close the connection
                connection.Close();

            }

            // step 5 process results
            var firstTable = dataSet.Tables[0];
            // foreach without generics does a cast when you assign a type here
            
            foreach (DataRow row in firstTable.Rows)
            {
                // DataSet contains DataTable, DataColumn, DataRow, etc.

                object id = row["id"];
                object name = row["Name"];
                Console.WriteLine($"ID: {id}, Name: {name}");
            }

        }
    }
}
