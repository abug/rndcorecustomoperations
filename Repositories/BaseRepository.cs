using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;
using Microsoft.EntityFrameworkCore;
using rndcorecustomoperations.Specifications;
using rndcorecustomoperations.Extensions;
using System.Linq;

namespace rndcorecustomoperations.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BloggingContext context;

        public BaseRepository(BloggingContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            IQuery<TEntity> query, ISpecification<TEntity> specification = null)
        {
            var connection = context.Database.GetDbConnection();

            var text = SpecificationEvaluator<TEntity>.GetQuery(query, specification);

            return await connection.QueryListAsync<TEntity>(text);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            ISpecification<TEntity> specification = null)
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public Task<TEntity> GetEntity(
            IQuery<TEntity> query, ISpecification<TEntity> specification = null)
        {
           throw new System.NotImplementedException();
        }

        public Task Update(ISpecification<TEntity> specification)
        {
            throw new System.NotImplementedException();
        }
    }
}