using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Bodegas_Inventarios
{
    [Table("bodegabebidas", Schema = "public")]
    public class Bbebida
    {
        [Key]
        public string marcadebebida { get; set; }
        public string tipodebebida { get; set; }
        public string tipodeenvase { get; set; }
        public int cantenml { get; set; }
        public int cantexistente { get; set; }
        public string zonasupermercado { get; set; }
        public DateTime fechadevencimiento { get; set; }

    }
}