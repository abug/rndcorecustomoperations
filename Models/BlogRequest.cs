using System.Collections.Generic;
using System.Data;

namespace rndcorecustomoperations.Models
{
    public class BlogRequest
    {
        public BlogRequest()
        {
            BlogIds = new DataTable();
        }

        //public IList<int> BlogIds { get; set; }
        public DataTable BlogIds { get; set;}
    }
}