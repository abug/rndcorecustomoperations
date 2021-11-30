using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;
using rndcorecustomoperations.Repositories;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Services
{
    public class BlogsService : BaseService, IBlogsService
    {
        public BlogsService(IDapperRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<BlogResponse>> GetBlogResponseAsync(BlogRequest request)
        {
            var response = await repository.FindAsync<BlogRequest, BlogUrlResponse, BlogsBodyResponse>(
                new BlogsMultipleQuery(request));

            var blogResponse = new List<BlogResponse>();

            foreach (var item in response.Item2)
            {
                blogResponse.Add(new BlogResponse { Url = item.UrlValue });
            }

            var altResponse = await repository.FindAsync<BlogRequest, dynamic, dynamic>(new BlogsMultipleQuery(request));

            return blogResponse;
        }
    }
}