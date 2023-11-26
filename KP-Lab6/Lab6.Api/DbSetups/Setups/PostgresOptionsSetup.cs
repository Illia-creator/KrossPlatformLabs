using Lab6.Api.DbSetups.Options;
using Microsoft.Extensions.Options;

namespace Lab6.Api.DbSetups.Setups;

public class PostgresOptionsSetup : IConfigureOptions<PostgresOptions>
{
    private readonly IConfiguration _configuration;

    public PostgresOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PostgresOptions options)
    {
        if (options is not null)
        {
            var connectionString = _configuration.GetConnectionString("postgres_connection");

            if (!string.IsNullOrWhiteSpace(connectionString))
                options.PostgresConnection = connectionString;

            _configuration.GetSection("Postgres").Bind(options);
        }
    }
}
