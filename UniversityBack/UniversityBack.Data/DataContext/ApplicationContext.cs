
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityBack.Domain.Entities;

namespace UniversityBack.Data.DataContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Postulacion> Postulaciones { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Empresa - Oferta (1 a muchos)
            builder.Entity<Empresa>()
                .HasMany(e => e.Ofertas)
                .WithOne(o => o.Empresa)
                .HasForeignKey(o => o.Id);

            // Oferta - Postulación (1 a muchos)
            builder.Entity<Oferta>()
                .HasMany(o => o.Postulaciones)
                .WithOne(p => p.Oferta)
                .HasForeignKey(p => p.Id);

            // Usuario - Postulación (1 a muchos)
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Postulaciones)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Postulación - Log (1 a muchos)
            builder.Entity<Postulacion>()
                .HasMany(p => p.Logs)
                .WithOne(l => l.Postulacion)
                .HasForeignKey(l => l.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
