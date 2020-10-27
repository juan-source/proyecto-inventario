using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("drogueria", Schema = "public")]
    public class Idrogueria
    {
        [Key]
        public string marcalaboratorio { get; set; }
        public string nombredroga { get; set; }
        public string tipodeenvase { get; set; }
        public int pesoengramos { get; set; }
        public int cantexistente { get; set; }
        public DateTime fechadevencimiento { get; set; }

    }
}