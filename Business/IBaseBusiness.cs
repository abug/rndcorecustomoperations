using System.Collections.Generic;
using System.Threading.Tasks;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Business
{
    public interface IBaseBusiness<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> FindAsync();
    }
}