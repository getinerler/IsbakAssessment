using IsbakAssessment.Models;
using Microsoft.EntityFrameworkCore;


namespace IsbakAssessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString =
                "data source=.;initial catalog=IsbakAssessment;user id=sa;" +
                "MultipleActiveResultSets=True;integrated security=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<CryptoItem> CryptoItems { get; set; }
    }
}
