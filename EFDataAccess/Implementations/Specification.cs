using Emisoft.TeamsSR.WorkflowDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emisoft.TeamsSR.WorkflowDAL.Implementations
{
    /// <summary>
    /// Class Specification.
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <seealso cref="Emisoft.TeamsSR.WorkflowDAL.Interface.ISpecification{E}" />
    public class Specification<E> : ISpecification<E>
    {
        #region Private Members

        /// <summary>
        /// The eval function
        /// </summary>
        private Func<E, bool> _evalFunc = null;
        /// <summary>
        /// The eval predicate
        /// </summary>
        private Expression<Func<E, bool>> _evalPredicate;

        #endregion

        #region Virtual Accessors

        /// <summary>
        /// Matcheses the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Matches(E entity)
        {
            return _evalPredicate.Compile().Invoke(entity);
        }

        /// <summary>
        /// Select/Where Expression
        /// </summary>
        /// <value>The eval predicate.</value>
        public virtual Expression<Func<E, bool>> EvalPredicate
        {
            get { return _evalPredicate; }
        }

        /// <summary>
        /// Function to evaluate where Expression
        /// </summary>
        /// <value>The eval function.</value>
        public virtual Func<E, bool> EvalFunc
        {
            get { return _evalPredicate != null ? _evalPredicate.Compile() : null; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification{E}"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public Specification(Expression<Func<E, bool>> predicate)
        {
            _evalPredicate = predicate;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Specification{E}"/> class from being created.
        /// </summary>
        private Specification() { }

        #endregion

        #region Private Nested Classes

        /// <summary>
        /// Class AndSpecification.
        /// </summary>
        /// <seealso cref="Emisoft.TeamsSR.WorkflowDAL.Implementations.Specification{E}" />
        private class AndSpecification : Specification<E>
        {
            /// <summary>
            /// The left
            /// </summary>
            private readonly ISpecification<E> _left;
            /// <summary>
            /// The right
            /// </summary>
            private readonly ISpecification<E> _right;
            /// <summary>
            /// Initializes a new instance of the <see cref="AndSpecification"/> class.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            public AndSpecification(ISpecification<E> left, ISpecification<E> right)
            {
                this._left = left;
                this._right = right;

                this._evalFunc =
                    (Func<E, bool>)Delegate.Combine
                    (left.EvalPredicate.Compile(),
                    right.EvalPredicate.Compile());

               //check _evalPredicate = left.EvalPredicate.And(right.EvalPredicate);
            }
            /// <summary>
            /// Matcheses the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public override bool Matches(E entity)
            {
                return EvalPredicate.Compile().Invoke(entity);
            }
        }

        /// <summary>
        /// Class OrSpecification.
        /// </summary>
        /// <seealso cref="Emisoft.TeamsSR.WorkflowDAL.Implementations.Specification{E}" />
        private class OrSpecification : Specification<E>
        {
            /// <summary>
            /// The left
            /// </summary>
            private readonly ISpecification<E> _left;
            /// <summary>
            /// The right
            /// </summary>
            private readonly ISpecification<E> _right;
            /// <summary>
            /// Initializes a new instance of the <see cref="OrSpecification"/> class.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            public OrSpecification(ISpecification<E> left, ISpecification<E> right)
            {
                this._left = left;
                this._right = right;

                this._evalFunc =
                    (Func<E, bool>)Delegate.Combine
                    (left.EvalPredicate.Compile(),
                    right.EvalPredicate.Compile());

               // _evalPredicate = left.EvalPredicate.Or(right.EvalPredicate);
            }
            /// <summary>
            /// Matcheses the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public override bool Matches(E entity)
            {
                return EvalPredicate.Compile().Invoke(entity);
            }
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Implements the &amp; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Specification<E> operator &(Specification<E> left, ISpecification<E> right)
        {
            return new AndSpecification(left, right);
        }

        /// <summary>
        /// Implements the | operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Specification<E> operator |(Specification<E> left, ISpecification<E> right)
        {
            return new OrSpecification(left, right);
        }

        #endregion

    }
}
