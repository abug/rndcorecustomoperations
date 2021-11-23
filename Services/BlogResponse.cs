namespace rndcorecustomoperations.Services
{
    public class BlogResponse
    {
        public string Url { get; set; }

        public override string ToString()
        {
            return $"Blog url: {Url}";
        }
    }
}