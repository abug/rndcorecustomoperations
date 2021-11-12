using System.Collections.Generic;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Repositories
{
    public class BlogSpecification : ISpecification<Blog>
    {
        public IDictionary<string, string> Parameters => throw new System.NotImplementedException();
    }
}