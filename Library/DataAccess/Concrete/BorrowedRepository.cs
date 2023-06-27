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
    public class BorrowedRepository : Repository<Borrowed>, IBorrowedRepository
    {
        public BorrowedRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
