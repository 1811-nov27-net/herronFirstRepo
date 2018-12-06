using System;

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

        }
    }
}
