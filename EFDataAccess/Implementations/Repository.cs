using Emisoft.TeamsSR.WorkflowDAL.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emisoft.TeamsSR.WorkflowDAL.Implementations
{
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="C"></typeparam>
    /// <seealso cref="Emisoft.TeamsSR.WorkflowDAL.Interface.IRepository{T}" />
    public class Repository<T, C> : IRepository<T>
        where T : class
        where C : DbContext
    {
        /// <summary>
        /// The CTX
        /// </summary>
        private readonly C _ctx;
        /// <summary>
        /// The entity
        /// </summary>
        private readonly T _entity;

        /// <summary>
        /// The key property
        /// </summary>
        private string _KeyProperty = "ID";

        /// <summary>
        /// Gets or sets the key property.
        /// </summary>
        /// <value>The key property.</value>
        public string KeyProperty
        {
            get
            {
                return _KeyProperty;
            }
            set
            {
                _KeyProperty = value;
            }
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public C Context
        {
            get { return _ctx; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T, C}"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public Repository(C session)
        {
            _ctx = session;
            this._dbSet = this._ctx.Set<T>();
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public T Entity
        {
            get { return _entity; }
        }


        /// <summary>
        /// The data set of the repository
        /// </summary>
        private IDbSet<T> _dbSet;

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>All entities</returns>
        public IEnumerable<T> GetAll()
        {
            return this._dbSet;
        }

        /// <summary>
        /// Gets all entities matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>All entities matching the predicate</returns>
        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where(predicate);
        }

        /// <summary>
        /// Set based on where condition
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <returns>The records matching the given condition</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where(predicate);
        }

        /// <summary>
        /// Finds an entity matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate</returns>
        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where(predicate);
        }

        /// <summary>
        /// Determines if there are any entities matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>True if a match was found</returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Any(predicate);
        }

        /// <summary>
        /// Returns the first entity that matches the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate</returns>
        public T First(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.First(predicate);
        }

        /// <summary>
        /// Returns the first entity that matches the predicate else null
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate else null</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Adds a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to add to the context</param>
        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        /// <summary>
        /// Deletes a given entity from the context
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }

        /// <summary>
        /// Attaches a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to attach</param>
        public void Attach(T entity)
        {
            this._dbSet.Attach(entity);
        }

        /// <summary>
        /// Attaches a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to attach</param>
        /// <returns>T.</returns>
        public T Update(T entity)
        {
            var updated = this._dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return updated;
        }

        /// <summary>
        /// Includes the specified name.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Include(string Name)
        {
          return this._dbSet.Include(Name);
        }

        /// <summary>
        /// Includes the specified name.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="includeMoreColumns">The include more columns.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Include(string Name, params string[] includeMoreColumns)
        {
            IQueryable<T> q1 = this._dbSet.Include(Name);
            foreach (var item in includeMoreColumns)
                q1.Include(item);
            return q1;
        }
        /// <summary>
        /// Includes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Include(Expression<Func<T, T>> path)
        {
            return this._dbSet.Include(path);
        }
        /// <summary>
        /// Includes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Include(Expression<Func<T, ICollection<T>>> path)
        {
            return this._dbSet.Include(path);
        }
    }
}
