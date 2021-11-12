using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Repositories
{
    public class BlogsRepository : BaseRepository<Blog>, IBlogsRepository
    {
        public BlogsRepository(BloggingContext context) : base(context)
        {
        }
    }
}