namespace Application.Dtos
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public AuthorDto(Guid id, Guid bookId, string name)
        {
            Id = id;
            BookId = bookId;
            Name = name;
        }
    }
}
