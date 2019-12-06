using ppedv.Hampelmann.Model;
using ppedv.Hampelmann.Model.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.Hampelmann.Data.EF
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfContext context = null;

        public EfRepository(EfContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var loaded = GetById(entity.Id);
            if (loaded != null)
                context.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
