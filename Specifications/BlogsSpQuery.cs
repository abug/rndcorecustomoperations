using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Specifications
{
    public class BlogsSpQuery : BaseQuery<Blog>
    {
        public override string QueryBody => "ListBlogsParams";
    }
}