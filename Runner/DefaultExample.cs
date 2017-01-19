using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FizzWare.NBuilder;

namespace Runner
{
    public class DefaultExample
    {
        public static void RunExample(string connectionString)
        {
            GetDataFromTable(connectionString);
            InsertRecords(connectionString, 5000);
            GetDataFromTable(connectionString);
        }

        public static void CountRecords(string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = connection.ExecuteScalar<int>("select count(*) from dbo.Temp_Processing");

                Console.WriteLine($"Number of records: {result}");
            }
        }

        public static void GetDataFromTable(string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                foreach (Temp_Processing processingRecord in connection.Query<Temp_Processing>("select * from dbo.Temp_Processing").ToList())
                {
                    Console.WriteLine($"Record:{processingRecord.Id} - {processingRecord.Message} - {processingRecord.Created}");
                }
            }

        }

        internal static void InsertRecords(string connectionString, int noOfRecords)
        {
            var records = Builder<Temp_Processing>.CreateListOfSize(noOfRecords).All().With(x=>x.Id = Guid.NewGuid())
                .Build();


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (IDbTransaction transactionScope = db.BeginTransaction(IsolationLevel.Serializable))
                {
                    string insertQuery = @"INSERT INTO [dbo].[Temp_Processing](	[Id] , 
    [Type] ,
	[Message], 
    [Status] , 
    [Errors] , 
    [Created] , 
    [Completed] , 
    [Processed] ) VALUES (
    @Id , 
    @Type,
	@Message, 
    @Status , 
    @Errors , 
    @Created , 
    @Completed , 
    @Processed )";

                    var result = db.Execute(insertQuery, records, transactionScope);
                    transactionScope.Commit();
                }
            }

        }
    }
}