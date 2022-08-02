namespace Autumn.BookManagement.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
