using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("aseoehigiene", Schema = "public")]
    public class Iaseo
    {
        [Key]
        public string marcadeproducto { get; set; }
        public string tipodeproducto { get; set; }
        public string tipodeenvaseopaquete { get; set; }
        public int cantenpesooml { get; set; }
        public int cantexistente { get; set; }
        public string zonasupermercado { get; set; }

    }
}