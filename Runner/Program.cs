using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=V:\Code\DapperExample\Runner\Runner\Database.mdf;Integrated Security=True";

            DefaultExample.RunExample(connectionString);

            Console.WriteLine("Completed");
            Console.ReadKey();

        }
    }
}
