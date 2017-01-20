using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FizzWare.NBuilder;

namespace Runner
{
/// example comes
https://www.google.co.uk/amp/www.joesauve.com/async-dapper-and-async-sql-connection-management/amp/?client=safari

 public class PersonRepository 
{
    public Person GetPersonById(Guid Id) 
    {
        using (var connection = new SQLConnection("myConnectionString")) 
        {
            try {
                connection.Open(); // synchronously open a connection to the database

                var p = new DynamicParameters();
                p.Add("Id", Id, DbType.Guid);
                var people = c.Query<Person>(
                    sql: "sp_Person_GetById", 
                    param: p, 
                    commandType: CommandType.StoredProcedure);
                return people.FirstOrDefault();
            } catch {
                // handle exception
            }
        } // as our scope closes, so does the sql connection, by virtue of the IDisposable interface
    }
}}