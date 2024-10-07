using ChallengeDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDotnet.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Previsao> Previsoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}