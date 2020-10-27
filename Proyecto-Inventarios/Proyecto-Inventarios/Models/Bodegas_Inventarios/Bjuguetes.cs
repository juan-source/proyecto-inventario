﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Inventarios.Models.Bodegas_Inventarios
{
    [Table("bodegajuguete", Schema = "public")]
    public class Bjuguetes
    {
        [Key]
        public string tipoproducto { get; set; }
        public int cantexistente { get; set; }

    }
}