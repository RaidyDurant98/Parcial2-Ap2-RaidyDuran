using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Presupuestos
    {
        [Key]
        public int PresupuestoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        public Presupuestos()
        {

        }

        public Presupuestos(int presupuestoId, string descripcion, decimal monto, DateTime fecha)
        {
            this.PresupuestoId = presupuestoId;
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.Fecha = fecha;
        }
    }
}
