using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Inventarios_Generales
{
    [Table("electrodomesticos", Schema = "public")]
    public class Ielectro
    {
        [Key]
        public string marca { get; set; }
        public string tipoproducto { get; set; }
        public int pesootamaño { get; set; }
        public int cantexistente { get; set; }

    }
}