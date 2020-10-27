using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("verduleria", Schema = "public")]
    public class Iverduleria
    {
        [Key]
        public string tipodeproducto { get; set; }
        public int cantenbultosocanastas { get; set; }

    }
}