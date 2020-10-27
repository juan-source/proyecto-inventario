using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("juguete", Schema = "public")]
    public class Ijuguetes
    {
        [Key]
        public string tipoproducto { get; set; }
        public int cantexistente { get; set; }

    }
}