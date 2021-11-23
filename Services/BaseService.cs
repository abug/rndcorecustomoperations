using rndcorecustomoperations.Repositories;

namespace rndcorecustomoperations.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IDapperRepository repository;

        public BaseService(IDapperRepository repository)
        {
            this.repository = repository;
        }
    }
}