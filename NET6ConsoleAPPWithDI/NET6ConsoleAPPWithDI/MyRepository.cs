using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace NET6ConsoleAPPWithDI
{
    public class MyRepository: IMyRepository
    {
        private readonly string _connectionString;

        public MyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("localDatabase");
        }

        public async Task<int> GetSomethingFromDb()
        {
            string sqlQuery = $@"SELECT COUNT(*) FROM `users`";
            await using var connection = new MySqlConnection(this._connectionString);
            var result = (await connection.QueryAsync<int>(sqlQuery)).FirstOrDefault();
            if (result <= 0)
            {
                throw new Exception("DB query failed");
            }

            return result;
        }
    }
}
