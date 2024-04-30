using System.Data;
using System.Data.SqlClient;

namespace ContactsAdm.Data
{
    public class ContactsDapperContext(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly string _connection = configuration.GetConnectionString("Default");

        public IDbConnection CreateConnection() => new SqlConnection(_connection);

    }
}
