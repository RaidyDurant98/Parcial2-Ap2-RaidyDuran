using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL
{
    public class Respository<TEntity> : IResporitory<TEntity> where TEntity : class
    {
        DAL.Parcial2Db Context = null;

        public Respository()
        {
            Context = new Parcial2Db();
        }

        private DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.FirstOrDefault(criterioBusqueda);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public bool Eliminar(TEntity laEntidad)
        {
            try
            {
                EntitySet.Attach(laEntidad);
                EntitySet.Remove(laEntidad);
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.Where(criterioBusqueda).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Guardar(TEntity laEntidad)
        {
            try
            {
                EntitySet.Add(laEntidad);
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TEntity laEntidad)
        {
            try
            {
                EntitySet.Attach(laEntidad);
                Context.Entry(laEntidad).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TEntity> GetListAll()
        {
            try
            {
                return EntitySet.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity BuscarOtro(int id)
        {
            try
            {
                return EntitySet.Find(id);              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
