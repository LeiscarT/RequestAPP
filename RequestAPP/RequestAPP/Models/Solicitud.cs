using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAPP.Models
{
    public class Solicitud
    {
        public int Id { get; set; }

        //foreign Key
        public int PersonaId { get; set; }
        public Persona persona { get; set; }

        public Estado estado { get; set; }
        public DateTimeOffset FechaDeCreacion { get; set; }

    }
}
