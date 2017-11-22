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
    public class PresupuestosBLL
    {
        public static bool Guardar(Entidades.Presupuestos presupuesto)
        {
            using (var context = new Respository<Entidades.Presupuestos>())
            {
                try
                {
                    if (Buscar(p => p.PresupuestoId == presupuesto.PresupuestoId) == null)
                    {
                        return context.Guardar(presupuesto);
                    }
                    else
                    {
                        return context.Modificar(presupuesto);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static Presupuestos Buscar(Expression<Func<Presupuestos, bool>> criterio)
        {
            using (var context = new Respository<Presupuestos>())
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

        public static bool Eliminar(Presupuestos presupuesto)
        {
            using (var context = new Respository<Presupuestos>())
            {
                try
                {
                    return context.Eliminar(presupuesto);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Presupuestos> GetListAll()
        {
            using (var context = new Respository<Presupuestos>())
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

        public static List<Presupuestos> GetList(Expression<Func<Presupuestos, bool>> criterio)
        {
            using (var context = new Respository<Presupuestos>())
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
