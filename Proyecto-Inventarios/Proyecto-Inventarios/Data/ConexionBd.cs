using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proyecto_Inventarios.Models;
using Proyecto_Inventarios.Models.Bodegas_Inventarios;
using Proyecto_Inventarios.Models.Inventarios_Generales;

namespace Proyecto_Inventarios.Data
{
    public class ConexionBd : DbContext {
        public ConexionBd():base(nameOrConnectionString:"Myconnection") {

        }
        //connexiones a inventarios de bodegas
        public virtual DbSet<PrimeraClass> primeras {get; set;}

        public virtual DbSet<Bbebida> bebidas { get; set; }

        public virtual DbSet<Baseo> baseo { get; set; }

        public virtual DbSet<Bdrogueria> bdrogueria { get; set; }

        public virtual DbSet<Belectro> belectro { get; set; }

        public virtual DbSet<Bjuguetes> bjuguetes { get; set; }

        public virtual DbSet<Blicores> blicores { get; set; }

        public virtual DbSet<BproductosAliment> bproductosAliment { get; set; }

        public virtual DbSet<BproductosEnlatados> bproductosEnlatados { get; set; }

        public virtual DbSet<BVerduleria> bverduleria { get; set; }
        //conexiones a inventarios generales

        public virtual DbSet<Iaseo> iAseo { get; set; }

        public virtual DbSet<Ibebidas> ibebidas{ get; set; }

        public virtual DbSet<Idrogueria> idrogueria { get; set; }

        public virtual DbSet<Ielectro> ielectro { get; set; }

        public virtual DbSet<Ijuguetes> ijuguetes { get; set; }

        public virtual DbSet<Ilicores> ilicores { get; set; }

        public virtual DbSet<Ipalimenticios> ipalimenticios { get; set; }

        public virtual DbSet<Ienlatados> ienlatados { get; set; }

        public virtual DbSet<Iverduleria> iverduleria { get; set; }

        public virtual DbSet<Icarne> icarne { get; set; }

        public virtual DbSet<Ipanaderia> ipanaderia { get; set; }
    }
}