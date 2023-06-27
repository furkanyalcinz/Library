using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BookPicture:BaseEntity
    {
        public int BookId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

        public BookPicture(int bookId, string fileName, string path)
        {
            BookId = bookId;
            FileName = fileName;
            Path = path;
        }

    }
}
