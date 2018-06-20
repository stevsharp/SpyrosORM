using System.Data;

namespace SpyrosORM.DataAccess
{
    public interface IUnitOfWork
    {
        IDbCommand CreateCommand();

        void SaveChanges();

        void Dispose();
    }
}