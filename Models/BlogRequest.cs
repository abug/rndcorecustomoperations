using System.Collections.Generic;

namespace rndcorecustomoperations.Models
{
    public class BlogRequest
    {
        public BlogRequest()
        {
            BlogIds = new Dictionary<string, IList<int>>();
        }

        public IDictionary<string, IList<int>> BlogIds { get; set; }
    }
}