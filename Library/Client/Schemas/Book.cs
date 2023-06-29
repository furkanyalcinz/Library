namespace Client.Schemas
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
        public bool? IsBorrowed { get; set; } = false;
        public string PicturePath { get; set; }
        public virtual Category Category { get; set; }
        public virtual Borrowed? Borrowed { get; set; }
    }

    public class Category
    {
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Borrowed
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
