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
    }
}
