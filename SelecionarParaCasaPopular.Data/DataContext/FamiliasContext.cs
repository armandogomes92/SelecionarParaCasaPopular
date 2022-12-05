using Microsoft.EntityFrameworkCore;
using SelecionarParaCasaPopular.Data.Models;

namespace SelecionarParaCasaPopular.Data.DataContext
{
    public class FamiliasContext : DbContext
    {
        private string DbPath { get; }
        public FamiliasContext(DbContextOptions<FamiliasContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "CadastroCasaPopular.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Familia.Configuration());
            modelBuilder.ApplyConfiguration(new Pessoa.Configuration());
        }
    
    }
}
