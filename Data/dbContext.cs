using GreenLight.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenLight.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lampada> Lampadas { get; set; }
        public DbSet<Registro> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais de relacionamento, se necessário
            modelBuilder.Entity<Lampada>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Lampadas)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); // Definindo delete em cascata para Lampada -> Usuario

            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Lampada)
                .WithMany() // Sem relação inversa explícita
                .HasForeignKey(r => r.LampadaId)
                .OnDelete(DeleteBehavior.Cascade); // Definindo delete em cascata para Registro -> Lampada
        }
    }
}
