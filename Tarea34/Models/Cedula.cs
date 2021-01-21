using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea34.Models
{
    public class cedula
    {
        
           [Key]
            public string Cedula { get; set; }

            public string Nombres { get; set; }

            public string Apellido1 { get; set; }

            public string FechaNacimiento { get; set; }

            public string correo { get; set; }

            public string telefono { get; set; }

            public bool Ok { get; set; }
        
    }
}
