using System;

namespace Repositories.Stock.Interface
{
    public interface IUnitOfWork// : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}