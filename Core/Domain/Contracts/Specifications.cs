using System.Linq.Expressions;

namespace Domain.Contracts
{
    public abstract class Specifications<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; }
        public List<Expression<Func<T, object>>>? IncludeExpressions { get; } = new();
 
        protected Specifications(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> expression)
             => IncludeExpressions.Add(expression);
    }
}
