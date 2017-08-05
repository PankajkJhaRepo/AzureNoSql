using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emisoft.TeamsSR.WorkflowDAL.Interface
{
    /// <summary>
    /// Interface ISpecification
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface ISpecification<E>
    {
        /// <summary>
        /// Select/Where Expression
        /// </summary>
        /// <value>The eval predicate.</value>
        Expression<Func<E, bool>> EvalPredicate { get; }
        /// <summary>
        /// Function to evaluate where Expression
        /// </summary>
        /// <value>The eval function.</value>
        Func<E, bool> EvalFunc { get; }
    }
}
