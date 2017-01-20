public class PersonRepository : BaseRepository
{
    public PersonRepository(string connectionString): base (connectionString) { }

    public async Task<Person> GetPersonById(Guid Id)
    {
        return await WithConnection(async c => {

            // Here's all the same data access code,
            // albeit now it's async, and nicely wrapped
            // in this handy WithConnection() call.
            var p = new DynamicParameters();
            p.Add("Id", Id, DbType.Guid);
            var people = await c.QueryAsync<Person>(
                sql: "sp_Person_GetById", 
                param: p, 
                commandType: CommandType.StoredProcedure);
            return people.FirstOrDefault();

        });
    }
}