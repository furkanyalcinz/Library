using Business.ReturnTypes;
using Business.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        public IResult GetAll();
        public IResult Reserve(int id, int userId, DateTime returnDate);
        public IResult AddBook(AddBookView model);
    }
}
