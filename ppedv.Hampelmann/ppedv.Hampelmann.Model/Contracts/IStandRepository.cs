using System.Collections.Generic;

namespace ppedv.Hampelmann.Model.Contracts
{
    public interface IStandRepository : IRepository<Stand>
    {
        IEnumerable<Stand> GetStaendeOfYear(int year);
    }
}
