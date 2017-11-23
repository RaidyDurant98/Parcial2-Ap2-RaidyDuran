using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PresupuestosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Meta { get; set; }
        public decimal Logrado { get; set; }

        public PresupuestosDetalles()
        {

        }

        public PresupuestosDetalles(string descripcion, decimal meta, decimal logrado)
        {
            this.Descripcion = descripcion;
            this.Meta = meta;
            this.Logrado = logrado;
        }
    }
}
