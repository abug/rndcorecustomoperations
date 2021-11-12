using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetEntity(
            IQuery<TEntity> query, ISpecification<TEntity> specification = null);

        Task<IEnumerable<TEntity>> GetAllAsync(
            IQuery<TEntity> query, ISpecification<TEntity> specification = null);

        Task Update(ISpecification<TEntity> specification);
    }
}