using Microsoft.EntityFrameworkCore;
using WebApi_Camiones.Datos.Models;

namespace Api_Camiones.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camionero_Camiones>()
                .HasOne(b => b.Camionero)
                .WithMany(ba => ba.Camionero_Camion)
                .HasForeignKey(bi=>bi.CamioneroId);
            modelBuilder.Entity<Camionero_Camiones>()
                .HasOne(b => b.Camion)
                .WithMany(ba => ba.Camionero_Camion)
                .HasForeignKey(bi => bi.CamionId);


            //Este es para la conexion ruta_camion
            modelBuilder.Entity<Camion_Ruta>()
                .HasOne(b => b.ruta)
                .WithMany(ba => ba.Camion_Ruta)
                .HasForeignKey(bi => bi.IdRuta);
            modelBuilder.Entity<Camion_Ruta>()
                .HasOne(b => b.ruta)
                .WithMany(ba => ba.Camion_Ruta)
                .HasForeignKey(bi => bi.IdRuta);

        }


        public DbSet<Camionero> camioneros {get; set;}
        public DbSet<Camiones> camiones { get; set;}
        public DbSet<Camionero_Camiones> camionero_Camiones { get; set;}

        public DbSet<Ruta> rutas { get; set; }
        public DbSet<Camion_Ruta> camion_Rutas { get; set; }
    }
}
