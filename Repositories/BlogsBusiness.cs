using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;
using System.Linq;

namespace rndcorecustomoperations.Repositories
{
    public class BlogsBusiness : BaseBusiness<IBlogsRepository, Blog>, IBlogBusiness
    {
        public BlogsBusiness(IBlogsRepository repository) : base(repository)
        {
        }

        public override async Task<IList<Blog>> FindAsync()
        {
            var result = await Repository.GetAllAsync(new BlogsQuery());
            
            return result.ToList();
        }
    }
}