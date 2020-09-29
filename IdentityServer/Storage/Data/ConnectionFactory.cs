using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Storage.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
