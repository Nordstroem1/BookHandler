namespace Application.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public BookDto(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
