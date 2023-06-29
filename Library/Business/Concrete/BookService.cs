using Business.Abstract;
using Business.ReturnTypes;
using Business.Schema;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedRepository _borrowedRepository;
        private readonly IUserRepository _userRepository;
        
        public BookService(IBookRepository bookRepository, IBorrowedRepository borrowedRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _borrowedRepository = borrowedRepository;
            _userRepository = userRepository;
            
        }

        public IResult GetAll()
        {
            var books = _bookRepository.GetAllIQueryalbe().Include(b=>b.Category).Include(b=> b.Borrowed).ToList();

            

            return new DataResult<List<Book>>(true,null,books);
        }

        public IResult Reserve(int id, int userId, DateTime returnDate)
        {
            var book = _bookRepository.Get(b => b.Id == id);
            if (book.IsBorrowed == false)
            {
                var user = _userRepository.Table.Where(u => u.Id == userId).Select(u=> new {u.Name, u.Surname, u.Email}).FirstOrDefault();
                
                var borrowed = new Borrowed();
                borrowed.UserId = userId;
                borrowed.ReturnDate = returnDate;
                borrowed.UserName = user.Name + " " + user.Surname;
                borrowed.UserEmail = user.Email;
                borrowed.BookId = book.Id;
                _borrowedRepository.Add(borrowed);
                book.IsBorrowed = true;
                
                _bookRepository.Update(book);
                return new Result(true, "Book reserved");
            }
            else
            {
                return new DataResult<Book>(false, null, book);
            }
        }

        public IResult AddBook (AddBookView model)
        {
            if (model == null)
            {
                return new Result(false, "Invalid submission");
            }
            var book = new Book();
            book.AuthorName = model.AuthorName;
            book.CategoryId = model.CategoryId;
            book.Name = model.Name;
            book.Publisher = model.Publisher;
            book.PageCount = model.PageCount;



            var pic = model.BookPicture;
            if(pic.FileName == null || pic.FileName.Length == 0)
            {
                return new Result(false, null);
            }
            string _fileName = pic.FileName;
            var nameList = _fileName.Split('.');
            string fileName = nameList[0]+DateTime.Now.ToString().Replace(":","").Replace("/","").Replace(" ","")+"."+nameList[1];
            var path = Path.Combine(Directory.GetCurrentDirectory().ToString(),"Images", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                pic.CopyTo(stream);
                stream.Close();
            }
            book.PicturePath = path;
            _bookRepository.Add(book);
            

            return new Result(true, "Book added");
        }
    }
}
