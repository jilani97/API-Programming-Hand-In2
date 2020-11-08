using System.Data.Entity;
using Npgsql;

namespace WebApplication1.DAL
{
    public class NpgSqlCon: DbConfiguration
    {
        
        public NpgSqlCon()
        {
            var name = "Npgsql";

            SetProviderFactory(providerInvariantName: name,
                providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(providerInvariantName: name,
                provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
        }
    }
}