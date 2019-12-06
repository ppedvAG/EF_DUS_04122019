using ppedv.Hampelmann.Model;
using ppedv.Hampelmann.Model.Contracts;
using System;

namespace ppedv.Hampelmann.Data.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext context = new EfContext();

        public IStandRepository StandRepository => new EfStandRepository(context);

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(context);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
