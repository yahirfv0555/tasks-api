using Dapper;
using earrings_api;
using EarringsApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EarringsApi.Handlers
{
    public class DapperHandler
    {
        private readonly string envConfig;

        public DapperHandler()
        {
            envConfig = JsonConfiguration.GetEnvironment();
        }

        private string GetConnectionDB(string keyDB = "Tasks")
        {
            return JsonConfiguration.AppSetting[$"ConnectionDB:{keyDB}:{envConfig}"] ?? "";
        }

        public async Task<List<T>> GetFromProcedure<T>(string spName, DynamicParameters? spParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            await using SqlConnection connection = new(GetConnectionDB());

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            IEnumerable<T> result = await connection.QueryAsync<T>(spName, spParams, commandType: commandType);

            return result.ToList();
        }

        public async Task<Execution> SetFromProcedure(string spName, DynamicParameters spParams, CommandType commandType = CommandType.StoredProcedure)
        {
            await using SqlConnection connection = new(GetConnectionDB());

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            Execution result = await connection.QuerySingleAsync<Execution>(spName, spParams, commandType: commandType);

            return result;
        }
        
    }
}
