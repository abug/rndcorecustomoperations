using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;
using System.Linq;
using rndcorecustomoperations.Repositories;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Business
{
    public class BaseBusiness<TRepository, TEntity> : 
        IBaseBusiness<TEntity> where TRepository : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> Repository;
        //protected readonly ILogger Logger;

        public BaseBusiness(TRepository repository)//, ILogger logger)
        {
            Repository = repository;
            //Logger = logger;
        }

        public virtual async Task<IList<TEntity>> FindAsync()
        {
            var result = await Repository.GetAllAsync(new BaseQuery<TEntity>());
            
            return result.ToList<TEntity>();
        }
    }
}