using Emisoft.TeamsSR.WorkflowDAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emisoft.TeamsSR.WorkflowDAL.Implementations
{
    /// <summary>
    /// Class UnitOfWork.
    /// </summary>
    /// <typeparam name="C"></typeparam>
    /// <seealso cref="Emisoft.TeamsSR.WorkflowDAL.Interface.IUnitOfWork" />
    public class UnitOfWork<C> : IUnitOfWork where C : DbContext
    {
        /// <summary>
        /// The transaction
        /// </summary>
        private DbTransaction _transaction;
        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> _repositories;
        /// <summary>
        /// The CTX
        /// </summary>
        private C _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{C}"/> class.
        /// </summary>
        public UnitOfWork()
        {
            _ctx = Activator.CreateInstance<C>();
            _repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TSet">The type of the t set.</typeparam>
        /// <returns>IRepository&lt;TSet&gt;.</returns>
        public IRepository<TSet> GetRepository<TSet>() where TSet : class
        {
            if (_repositories.Keys.Contains(typeof(TSet)))
                return _repositories[typeof(TSet)] as IRepository<TSet>;

            var repository = new Repository<TSet, C>(_ctx);
            _repositories.Add(typeof(TSet), repository);
            return repository;
        }
        /// <summary>
        /// Start Transaction
        /// </summary>
        /// <returns>DbTransaction.</returns>
        public DbTransaction BeginTransaction()
        {
            if (null == _transaction)
            {
                if (_ctx.Database.Connection.State != ConnectionState.Open)
                {
                    _ctx.Database.Connection.Open();
                }
                this._transaction = _ctx.Database.Connection.BeginTransaction();
            }
            return _transaction;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            return _ctx.SaveChanges();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <returns>C.</returns>
        public C getContext()
        {
            return _ctx;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (null != _transaction)
            {
                _transaction.Dispose();
            }

            if (null != _ctx)
            {
                _ctx.Dispose();
            }
        }

        #endregion

    }
}
