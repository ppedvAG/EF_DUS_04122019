namespace ppedv.Hampelmann.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepo<T>() where T : Entity;
        IStandRepository StandRepository { get; }

        void Save();
    }
}
