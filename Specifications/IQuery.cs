using System.Collections.Generic;

namespace rndcorecustomoperations.Specifications
{
    public interface IQuery<TEntity>
    {
        string QueryBody { get; }

        IDictionary<string, object> Parameters { get; }
    }
}