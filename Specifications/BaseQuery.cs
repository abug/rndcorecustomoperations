using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace rndcorecustomoperations.Specifications
{
    public class BaseQuery<TRequest> : IQuery<TRequest>
    {
        private IDictionary<string, object> _parameters;

        private readonly TRequest request;

        public BaseQuery()
        {
            _parameters = new Dictionary<string, object>();
        }

        public BaseQuery(TRequest request) : this()
        {
            this.request = request;
        }

        public virtual string QueryBody => string.Empty;

        public virtual IDictionary<string, object> Parameters => _parameters;

        protected void AddTableParameter(
            Expression<Func<TRequest, object>> expression)
        {
            var name = GetParameterName(expression);
            var columnType = GetParameterType(expression);

            var value = GetParameterValue(request, expression);

            
        }

        protected void AddTableParameter(
            Expression<Func<TRequest, object>> expression, IList<object> columnValues)
        {
            var columnName = GetParameterName(expression);
            var columnType = GetParameterType(expression);

            var tableParameters = new DataTable();
            tableParameters.Columns.Add(columnName, columnType);

            foreach (var value in columnValues)
            {
                var row = tableParameters.NewRow();
                row[columnName] = value;

                tableParameters.Rows.Add(row);
            }

            _parameters.Add(columnName, tableParameters);
        }

        protected void AddParameter(
            Expression<Func<TRequest, object>> property)
        {
            var name = GetParameterName(property);

            var value = GetParameterValue(request, property);

            AddParameter(name, value);
        }

        protected void AddParameter(
            Expression<Func<TRequest, object>> property, int value)
        {
            var name = GetParameterName(property);

            AddParameter(name, value);
        }

        protected void AddParameter(
            Expression<Func<TRequest, object>> property, string value)
        {
            var name = GetParameterName(property);

            AddParameter(name, value);
        }

        protected void AddParameter(string name, object value)
        {
            _parameters.Add(name, value);
        }

        protected void AddParameter(KeyValuePair<string, object> parameter)
        {
            _parameters.Add(parameter);
        }

        private object GetParameterValue(TRequest request, Expression<Func<TRequest, object>> expression)
        {
            MemberExpression memberExpr = (MemberExpression)expression.Body;
            string memberName = memberExpr.Member.Name;
            Func<TRequest, object> compiledDelegate = expression.Compile();
            object value = compiledDelegate(request);

            return value;
        }

        private PropertyInfo GetPropertyInfo(Expression<Func<TRequest, object>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            // return lambda.NodeType.GetType();

            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return ((PropertyInfo)memberExpression.Member);
        }

        private Type GetParameterType(Expression<Func<TRequest, object>> expression)
        {
            var propertyInfo = GetPropertyInfo(expression);

            return propertyInfo.PropertyType;
        }

        private string GetParameterName(Expression<Func<TRequest, object>> expression)
        {
             var propertyInfo = GetPropertyInfo(expression);

            return propertyInfo.Name;
        }
    }
}