using ppedv.Hampelmann.Model;
using ppedv.Hampelmann.Model.Contracts;
using System;
using System.Collections.Generic;

namespace ppedv.Hampelmann.Data.EF
{
    public class EfStandRepository : EfRepository<Stand>, IStandRepository
    {

        public EfStandRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Stand> GetStaendeOfYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
