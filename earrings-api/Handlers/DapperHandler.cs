using Dapper;
using earrings_api;
using EarringsApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EarringsApi.Handlers
{
    public class DapperHandler
    {
        private static readonly string envConfig = JsonConfiguration.GetEnvironment();

        private static string GetConnectionDB(string keyDB = "Tasks")
        {
            return JsonConfiguration.AppSetting[$"ConnectionDB:{keyDB}:{envConfig}"] ?? "";
        }

        public async static Task<List<T>> GetFromProcedure<T>(string spName, DynamicParameters? spParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            await using SqlConnection connection = new(GetConnectionDB());

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            IEnumerable<T> result = await connection.QueryAsync<T>(spName, spParams, commandType: commandType);

            return result.ToList();
        }

        public static async Task<Execution> SetFromProcedure(string spName, DynamicParameters spParams, CommandType commandType = CommandType.StoredProcedure)
        {
            await using SqlConnection connection = new(GetConnectionDB());

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            Execution result = await connection.QuerySingleAsync<Execution>(spName, spParams, commandType: commandType);

            return result;
        }
        
    }
}
