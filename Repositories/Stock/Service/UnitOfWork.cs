using Repositories.Stock.Interface;
using RepositoryEF.Data;
using System.Transactions;

namespace Repositories.Stock.Service
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private RepositoryEFContext _context;

        //private TransactionScope _transaction;
        public UnitOfWork(RepositoryEFContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            //_transaction = new TransactionScope();
        }

        public void Commit()
        {
            _context.SaveChanges();
            //_transaction.Complete();
            //_transaction.Dispose();
        }

        public void Rollback()
        {
            //_transaction.Dispose();
        }
    }
}
