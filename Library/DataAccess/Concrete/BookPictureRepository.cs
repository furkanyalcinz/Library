using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BookPictureRepository : Repository<BookPicture>, IBookPictureRepository
    {
        public BookPictureRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
