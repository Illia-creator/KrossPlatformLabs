using Lab6.Api.DbSetups.Options;
using Microsoft.Extensions.Options;

namespace Lab6.Api.DbSetups.Setups
{
    public class InMemoryOptionsSetup : IConfigureOptions<InMemoryOptions>
    {
        private readonly IConfiguration _configuration;

        public InMemoryOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(InMemoryOptions options)
        {
            if (options is not null)
            {
                _configuration.GetSection("In_Memory").Bind(options);
            }
        }
    }
}
