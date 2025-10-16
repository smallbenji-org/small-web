using AccesPoint.Inferfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AccesPoint.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SqlDataAccess> _logger;

        public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess> logger)
        {
            this._configuration = configuration;
            this._logger = logger;
        }

        public Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId)
        {
            connectionId = "DefaultConnection";
            string connectionString = _configuration.GetConnectionString(connectionId) ?? "";

            try
            {
                using (IDbConnection connection = new NpgsqlConnection(connectionString))
                {
                    _logger.LogInformation("Executing SQL: {sql}", sql);
                    var data = connection.Query<T>(sql, parameters);
                    return Task.FromResult(data);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exepction while executing SQL");
                throw;
            }

        }

        public Task SaveData<T>(string sql, T parameters, string connectionId)
        {
            throw new NotImplementedException();
        }
    }
}
