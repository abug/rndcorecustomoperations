using System.Collections.Generic;

namespace rndcorecustomoperations
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();

        public override string ToString()
        {
            return $"{BlogId} / {Url}";
        }
    }
}