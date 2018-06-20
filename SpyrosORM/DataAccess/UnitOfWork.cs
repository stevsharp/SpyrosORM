using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyrosORM.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        protected IDbConnection _connection;
        /// <summary>
        /// 
        /// </summary>
        protected IDbTransaction _transaction;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _transaction = connection.BeginTransaction();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
        /// <summary>
        /// 
        /// </summary>
        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction have already been commited. Check your transaction handling.");

            _transaction.Commit();
            _transaction = null;

        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }

        }
    }
}
