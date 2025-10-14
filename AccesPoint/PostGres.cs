using Npgsql;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace AccesPoint
{
    public class PostGres : IDbHandler
    {
        private readonly IConfiguration configuration;

        public PostGres(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDataReader ExecuteReader(string query)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(configuration.GetConnectionString("defaultConnection"));
            return conn.ExecuteReader(query);
        }

        public object ExecuteScalar(string query, object param = null)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(configuration.GetConnectionString("defaultConnection"));
            return conn.ExecuteScalar(query, param);
        }

        public object Execute(string query, object param = null)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(configuration.GetConnectionString("defaultConnection"));
            return conn.Execute(query, param);
        }
    }
}
