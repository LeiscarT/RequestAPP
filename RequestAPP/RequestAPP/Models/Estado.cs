using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAPP.Models
{
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
      //  public string Estado_Solicitud { get; set; }

        public string Estado_Solicitud { get; set; }

      //  public ICollection<Solicitud> Solicitudes { get; set; }


    }
}
