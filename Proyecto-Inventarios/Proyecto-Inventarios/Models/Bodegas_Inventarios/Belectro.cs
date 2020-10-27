using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Bodegas_Inventarios
{
    [Table("bodegaelectrodomesticos", Schema = "public")]
    public class Belectro
    {
        [Key]
        public string marca { get; set; }
        public string tipoproducto{ get; set; }
        public int pesootamaño{ get; set; }
        public int cantexistente { get; set; }

    }
}