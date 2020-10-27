using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Bodegas_Inventarios
{
    [Table("bodegaverduleria", Schema = "public")]
    public class BVerduleria
    {
        [Key]
        public string tipodeproducto { get; set; }
        public int cantenbultosocanastas { get; set; }

    }
}