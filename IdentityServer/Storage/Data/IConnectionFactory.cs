using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Storage.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
