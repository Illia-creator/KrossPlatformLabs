namespace Lab6.Api.DbSetups.Options
{
    public class MsSqlOptions
    {
        public string MsSqlConnectionString { get; set; } = string.Empty;

        public int MaxRetryCount { get; set; }
        public int CommandTimeout { get; set; }
        public bool EnableDetailedErrors { get; set; }
        public bool EnableSensitiveLogging { get; set; }

        public bool IsEnable { get; set; } = false;
    }

}
