using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestoDetalleBLL
    {
        public static bool Guardar(PresupuestosDetalle presupuestosDetalle)
        {
            using (var context = new Respository<PresupuestosDetalle>())
            {
                try
                {
                    if (Buscar(p => p.Id == presupuestosDetalle.Id) == null)
                    {
                        return context.Guardar(presupuestosDetalle);
                    }
                    else
                    {
                        return context.Modificar(presupuestosDetalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static PresupuestosDetalle Buscar(Expression<Func<PresupuestosDetalle, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosDetalle>())
            {
                try
                {
                    return context.Buscar(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static bool Eliminar(PresupuestosDetalle presupuestosDetalle)
        {
            using (var context = new Respository<PresupuestosDetalle>())
            {
                try
                {
                    return context.Eliminar(presupuestosDetalle);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<PresupuestosDetalle> GetListAll()
        {
            using (var context = new Respository<PresupuestosDetalle>())
            {
                try
                {
                    return context.GetListAll();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<PresupuestosDetalle> GetList(Expression<Func<PresupuestosDetalle, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosDetalle>())
            {
                try
                {
                    return context.GetList(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
