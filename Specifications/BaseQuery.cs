using System.Collections.Generic;

namespace rndcorecustomoperations.Specifications
{
    public class BaseQuery<TEntity> : IQuery<TEntity>
    {
        private IDictionary<string, string> _parameters;

        public BaseQuery()
        {
            _parameters = new Dictionary<string, string>();
        }

        public virtual string QueryBody => string.Empty;

        public virtual IDictionary<string, string> Parameters => _parameters;
    }
}