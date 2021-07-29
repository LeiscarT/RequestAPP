using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAPP.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Pasaporte { get; set; }
        public string Direccion { get; set; }
        public enum Sexo { Masculino, Femenino }
        public ICollection<Solicitud> Solicitudes { get; set; }

    }
}
