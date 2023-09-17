using Microsoft.EntityFrameworkCore;


namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class ApplicationDbContext : DbContext
    {
        #region Fields

        private readonly string _connectionString;

        #endregion


        #region ClassLifeCycles

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
        }

        #endregion


        #region DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(_connectionString));
        }

        #endregion
    }
}
