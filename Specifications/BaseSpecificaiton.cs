using System.Collections.Generic;

namespace rndcorecustomoperations.Specifications
{
    public class BaseSpecificaiton<TEntity> : ISpecification<TEntity>
    {
        private string _commandText;
        private IDictionary<string, string> _parameters;

        public IDictionary<string, string> Parameters => _parameters;

        public BaseSpecificaiton()
        {
            _parameters = new Dictionary<string, string>();
        }

        protected void AddParameter(KeyValuePair<string, string> parameter)
        {
            _parameters.Add(parameter);
        }
    }
}