namespace Autumn.BookManagement.Models
{
    public class UserBook : BaseEntity
    {
        public string Type { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
