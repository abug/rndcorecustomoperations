using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace rndcorecustomoperations.Specifications
{
    public class BaseSpecificaiton<TEntity> : ISpecification<TEntity>
    {
        private readonly List<Expression<Func<TEntity, object>>> _includeCollection = 
            new List<Expression<Func<TEntity, object>>>();

        //private string _commandText;
        private IDictionary<string, string> _parameters;

        public IDictionary<string, string> Parameters => _parameters;

        public Expression<Func<TEntity, bool>> FilterCondition { get; private set; }

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public List<Expression<Func<TEntity, object>>> Includes { get { return _includeCollection; } }

        public Expression<Func<TEntity, object>> GroupBy { get; private set; }

        public BaseSpecificaiton()
        {
            _parameters = new Dictionary<string, string>();
        }

        protected void AddParameter(
            Expression<Func<TEntity, object>> property, string value)
        {
            var name = GetParameterName(property);

            AddParameter(name, value);
        }

        protected void AddParameter(string name, string value)
        {
            _parameters.Add(name, value);
        }

        protected void AddParameter(KeyValuePair<string, string> parameter)
        {
            _parameters.Add(parameter);
        }

         protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void SetFilterCondition(Expression<Func<TEntity, bool>> filterExpression)
        {
            FilterCondition = filterExpression;
        }

        protected void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        private string GetParameterName(Expression<Func<TEntity, object>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return ((PropertyInfo)memberExpression.Member).Name;
        }
    }
}