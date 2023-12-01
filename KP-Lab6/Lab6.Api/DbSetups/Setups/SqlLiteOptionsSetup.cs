using Lab6.Api.DbSetups.Options;
using Microsoft.Extensions.Options;

namespace Lab6.Api.DbSetups.Setups
{
    public class SqlLiteOptionsSetup : IConfigureOptions<SqlLiteOptions>
    {
        private readonly IConfiguration _configuration;

        public SqlLiteOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SqlLiteOptions options)
        {
            if (options is not null)
            {
                var connectionString = _configuration.GetConnectionString("sqllite_connection");

                if (!string.IsNullOrWhiteSpace(connectionString))
                    options.SqlLiteConnection = connectionString;

                _configuration.GetSection("SqlLite").Bind(options);
            }
        }
    }

}
