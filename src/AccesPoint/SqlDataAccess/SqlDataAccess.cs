using AccesPoint.Inferfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
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

        public async Task SaveData<T>(string sql, T parameters, string connectionId)
        {
            connectionId = "DefaultConnection";
            string connectionString = _configuration.GetConnectionString(connectionId) ?? "";

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = connection.Query<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Exepction while executing SQL");
                throw;
            }
        }
    }
}
