using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.DataAccess.Data
{
    public class VeterinariaDbContext : IdentityDbContext<VeterinariaIdentityUser>
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Mascota> Mascotas { get; set; } = default!;
        public DbSet<TipoMascota> TipoMascotas { get; set; } = default!;
        public DbSet<Cita> Citas { get; set; } = default!;
        public DbSet<Servicio> Servicios { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VeterinariaIdentityUser>(e => e.ToTable("Usuarios"));
            modelBuilder.Entity<IdentityRole>(e => e.ToTable("Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRoles"));

            modelBuilder.Entity<Cliente>()
            .HasQueryFilter(p => p.Estado);

            modelBuilder.Entity<Cita>()
              .HasQueryFilter(p => p.Estado);
            modelBuilder.Entity<Mascota>()
              .HasQueryFilter(p => p.Estado);
            modelBuilder.Entity<Servicio>()
              .HasQueryFilter(p => p.Estado);
            modelBuilder.Entity<TipoMascota>()
              .HasQueryFilter(p => p.Estado);
        }
    }
}
