namespace Autumn.BookManagement.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual IEnumerable<UserBook> UserBooks { get; set; }
    }
}
