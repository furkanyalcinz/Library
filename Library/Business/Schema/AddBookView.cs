using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema
{
    public class AddBookView
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
        public List<IFormFile> BookPicture { get; set; }
    }
}
