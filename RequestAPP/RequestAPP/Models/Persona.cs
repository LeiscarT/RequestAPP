using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAPP.Models
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Pasaporte { get; set; }
        public string Direccion { get; set; }
        public enum Sexo { Masculino, Femenino }
        public ICollection<Solicitud> Solicitudes { get; set; }

    }
}
