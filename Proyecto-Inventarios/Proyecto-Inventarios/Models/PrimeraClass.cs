using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models
{
     [Table("primera", Schema = "public")]
    public class PrimeraClass
    {
        [Key]
        public int idprimera { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public int salario { get; set; }
        

    }
}