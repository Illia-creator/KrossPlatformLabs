namespace Lab6.Api.DbSetups.Options
{
    public class PostgresOptions
    {
        public string PostgresConnection { get; set; } = string.Empty;

        public bool IsEnable { get; set; } = false;
    }
}
