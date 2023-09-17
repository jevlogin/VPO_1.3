namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class DatabaseService
    {
        private readonly AppConfig _config;
        private readonly ApplicationDbContext _dbContext;


        public DatabaseService(AppConfig appConfig, ApplicationDbContext dbContext)
        {
            _config = appConfig;
            _dbContext = dbContext;
        }
    } 
}