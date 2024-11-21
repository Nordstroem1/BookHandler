using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; private set; }
        [MinLength(3)]
        [MaxLength(70)]
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
