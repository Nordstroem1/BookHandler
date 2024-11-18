namespace Domain.Models
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public int Pages { get; set; }
        public Book(Guid id, string title, Guid authorId, int pages)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Pages = pages;
        }
    }
}
