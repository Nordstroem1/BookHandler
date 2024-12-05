using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Id required.")]
        public Guid Id { get; private set; }
        [MinLength(3)]
        [MaxLength(70)]
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        [Range(1, int.MaxValue)]
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
