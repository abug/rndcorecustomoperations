using System.Collections.Generic;

namespace rndcorecustomoperations.Specifications
{
    public class BaseQuery<TEntity> : IQuery<TEntity>
    {
        public BaseQuery()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        public virtual string QueryBody => string.Empty;

        public virtual IDictionary<string, string> Parameters { get; set; }
    }
}