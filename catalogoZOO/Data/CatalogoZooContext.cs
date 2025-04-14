using System.Runtime.Intrinsics.X86;
using catalogoZOO.Model;
using Microsoft.EntityFrameworkCore;

namespace catalogoZOO.Data
{
    public class CatalogoZooContext : DbContext
    {
        public CatalogoZooContext(DbContextOptions<CatalogoZooContext> options): base(options) { }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeia cada classe derivada para sua própria tabela
            modelBuilder.Entity<Mamiferos>().ToTable("Mamiferos");
            modelBuilder.Entity<Repteis>().ToTable("Repteis");
            modelBuilder.Entity<Aves>().ToTable("Aves");

            // Configura a relação de chave estrangeira entre as tabelas derivadas e a tabela base Animal
            modelBuilder.Entity<Mamiferos>()
                .HasOne<Animal>()
                .WithOne()
                .HasForeignKey<Mamiferos>(m => m.AnimalId)
                .IsRequired(); // Garante que todo Mamifero tem um Animal correspondente

            modelBuilder.Entity<Repteis>()
                .HasOne<Animal>()
                .WithOne()
                .HasForeignKey<Repteis>(r => r.AnimalId)
            .IsRequired();

            modelBuilder.Entity<Aves>()
                .HasOne<Animal>()
            .WithOne()
                .HasForeignKey<Aves>(a => a.AnimalId)
                .IsRequired();

            // Configura a chave primária para as tabelas derivadas (geralmente herdada de AnimalId)
            modelBuilder.Entity<Mamiferos>().HasKey(m => m.AnimalId);
            modelBuilder.Entity<Repteis>().HasKey(r => r.AnimalId);
            modelBuilder.Entity<Aves>().HasKey(a => a.AnimalId);

            // Configura a chave primária para a tabela base Animal
            modelBuilder.Entity<Animal>().HasKey(a => a.AnimalId);
        }
    }
}

