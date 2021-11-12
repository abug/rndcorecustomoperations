using System.Collections.Generic;

namespace rndcorecustomoperations.Repositories
{
    public interface IQuery<TEntity>
    {
        string QueryBody { get; }

        IDictionary<string, string> Parameters { get; set; }
    }
}