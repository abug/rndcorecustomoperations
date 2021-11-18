using System.Collections.Generic;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Specifications
{
    public class BlogSpecification : BaseSpecificaiton<Blog>
    {
        public BlogSpecification()
        {
            AddParameter(b => b.Url, "q");
        }
    }
}