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
        public static bool Guardar(PresupuestosDetalles presupuestosDetalle)
        {
            using (var context = new Respository<PresupuestosDetalles>())
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

        public static PresupuestosDetalles Buscar(Expression<Func<PresupuestosDetalles, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosDetalles>())
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

        public static bool Eliminar(PresupuestosDetalles presupuestosDetalle)
        {
            using (var context = new Respository<PresupuestosDetalles>())
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

        public static List<PresupuestosDetalles> GetListAll()
        {
            using (var context = new Respository<PresupuestosDetalles>())
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

        public static List<PresupuestosDetalles> GetList(Expression<Func<PresupuestosDetalles, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosDetalles>())
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
