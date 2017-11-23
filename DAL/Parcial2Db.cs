using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Parcial2Db : DbContext
    {
        public Parcial2Db() : base("ConStr")
        {

        }

        public DbSet<Presupuestos> Presupuesto { get; set; }
        public DbSet<PresupuestosDetalles> PresupuestosDetalle { get; set; }
    }
}
