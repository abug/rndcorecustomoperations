using System.Threading.Tasks;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Repositories
{
    public interface IDapperRepository
    {
        Task<TResponse> FindAsync<TRequest, TResponse>(IQuery<TRequest> query, ISpecification<TRequest> specification = null);
    }

    public class BaseDapperRepository : IDapperRepository
    {
        

        public Task<TResponse> FindAsync<TRequest, TResponse>(IQuery<TRequest> query, ISpecification<TRequest> specification = null)
        {
            throw new System.NotImplementedException();
        }
    }
}