using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;
using System.Linq;
using rndcorecustomoperations.Repositories;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Business
{
    public class BlogsBusiness : BaseBusiness<IBlogsRepository, Blog>, IBlogBusiness
    {
        public BlogsBusiness(IBlogsRepository repository) : base(repository)
        {
        }

        public override async Task<IList<Blog>> FindAsync()
        {
            var result = await Repository.FindAsync();
            
            return result.ToList();
        }
    }
}