using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RequestAPP.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Solicitud> Solicitud { get; set; }

        public DbSet<Estado> Estado { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .ToTable("Estado");
            modelBuilder.Entity<Estado>()
                .HasData(
                    new Estado
                    {
                        Id = 1,
                        Estado_Solicitud = "Abiertas"
                    },
                    new Estado
                    {
                        Id = 2,
                      Estado_Solicitud ="Aprobadas"
                    },

                     new Estado
                     {
                         Id = 3,
                         Estado_Solicitud = "Canceladas"
                     }
                );
        }
    }
}
