using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Services
{
    public interface IBlogsService
    {
        Task<IEnumerable<BlogResponse>> GetBlogResponseAsync(BlogRequest request);
    }
}