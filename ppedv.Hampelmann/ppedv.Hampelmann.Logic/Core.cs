using ppedv.Hampelmann.Model.Contracts;
using System;

namespace ppedv.Hampelmann.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

    }
}
