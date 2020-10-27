using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("carne", Schema = "public")]
    public class Icarne
    {
        [Key]
        public string especieanimal { get; set; }

        public string tipodecarne { get; set; }
        public int cantenlb { get; set; }

    }
}