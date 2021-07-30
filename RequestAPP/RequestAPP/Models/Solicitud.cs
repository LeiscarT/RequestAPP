using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAPP.Models
{

    public class Solicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //foreign Key
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public Persona persona { get; set; }

        public int EstadoId { get;set; }
        public Estado estado { get; set; }
        public DateTimeOffset FechaDeCreacion { get; set; }


       

    }
}
