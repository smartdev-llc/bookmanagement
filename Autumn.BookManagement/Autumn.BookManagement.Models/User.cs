namespace Autumn.BookManagement.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<UserBook> UserBooks { get; set; }
    }
}
