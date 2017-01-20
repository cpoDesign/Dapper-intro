using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FizzWare.NBuilder;

namespace Runner
{
public abstract class DapperExRepositoryBase<TEntity> where TEntity : class
{
    public virtual bool Delete(TEntity entity)
    {
        using (var conn = ConnectionFactory.GetConnection())
        {
            return conn.Delete(entity);
        }
    }
 
    public virtual dynamic Insert(TEntity entity)
    {
        using (var conn = ConnectionFactory.GetConnection())
        {
            return conn.Insert(entity);
        }
    }
 
    public virtual bool Update(TEntity entity)
    {
        using (var conn = ConnectionFactory.GetConnection())
        {
            return conn.Update(entity);
        }
    }
}

public class DapperConnection
{
    public IDbConnection DapperCon {
        get
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());

        }
    }
}


}