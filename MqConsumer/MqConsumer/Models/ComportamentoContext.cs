using Microsoft.EntityFrameworkCore;

namespace MqConsumer.Models
{
    public class ComportamentoContext : DbContext
    {
        private readonly string connectionString;

        public ComportamentoContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Comportamento> Comportamento { get; set; }
    }
}
