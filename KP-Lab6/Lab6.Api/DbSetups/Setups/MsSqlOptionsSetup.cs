using Lab6.Api.DbSetups.Options;
using Microsoft.Extensions.Options;

namespace Lab6.Api.DbSetups.Setups
{
    public class MsSqlOptionsSetup : IConfigureOptions<MsSqlOptions>
    {
        private readonly IConfiguration _configuration;

        public MsSqlOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(MsSqlOptions options)
        {
            if (options is not null)
            {
                var connectionString = _configuration.GetConnectionString("mssql_connection");

                if (!string.IsNullOrWhiteSpace(connectionString))
                    options.MsSqlConnectionString = connectionString;

                _configuration.GetSection("MsSql").Bind(options);
            }
        }
    }

}
