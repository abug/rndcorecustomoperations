using System.Collections.Generic;

namespace rndcorecustomoperations.Repositories
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