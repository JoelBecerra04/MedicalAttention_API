using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MedicalAttention_API.Data
{


    
    public class ApplicationDBContext
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;

        public ApplicationDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

    }
}
