namespace rndcorecustomoperations.Repositories
{
    public class DatabaseRepository : BaseDapperRepository, IDatabaseRepository
    {
        public DatabaseRepository(IDatabaseConnection connection) : base(connection)
        {
            
        }
    }
}