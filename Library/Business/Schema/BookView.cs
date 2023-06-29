using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema
{
    public class BookView
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string AuthorName { get; set; }
        public bool? IsBorrowed { get; set; } = false;
    }
}
