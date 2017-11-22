using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PresupuestosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PresupestoId { get; set; }
        public string Descripcion { get; set; }
        public string Meta { get; set; }
        public string Logrado { get; set; }

        public PresupuestosDetalle()
        {

        }

        public PresupuestosDetalle(int presupuestoId, int categoriaId, string descripcion, string meta, string logrado)
        {
            this.PresupestoId = presupuestoId;
            this.Descripcion = descripcion;
            this.Meta = meta;
            this.Logrado = logrado;
        }
    }
}
