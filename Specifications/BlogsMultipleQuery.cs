using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Specifications
{
    public class BlogsMultipleQuery : BaseQuery<BlogRequest>
    {

        public BlogsMultipleQuery() : base()
        {
            
        }

        public BlogsMultipleQuery(BlogRequest request) : base(request)
        {
            AddTableParameter(r => r.BlogIds);
        }

        public override string QueryBody => "ListBlogsWithTableParams";


    }
}