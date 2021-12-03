using System.Data;

namespace rndcorecustomoperations.Repositories
{
    public class SynapseRepository : BaseDapperRepository, ISynapseRepository
    {
        public SynapseRepository(ISynapseConnection connection) : base(connection)
        {
        }
    }
}