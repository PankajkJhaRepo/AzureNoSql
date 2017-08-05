using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emisoft.TeamsSR.WorkflowDAL.Interface
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TSet">The type of the t set.</typeparam>
        /// <returns>IRepository&lt;TSet&gt;.</returns>
        IRepository<TSet> GetRepository<TSet>() where TSet : class;
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>DbTransaction.</returns>
        DbTransaction BeginTransaction();
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int Save();
    }
}
