using System.Data;

namespace SpyrosORM.DataAccess
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDbCommand CreateCommand();
        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// 
        /// </summary>
        void Dispose();
    }
}