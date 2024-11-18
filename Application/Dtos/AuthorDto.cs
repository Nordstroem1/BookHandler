namespace Application.Dtos
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AuthorDto(){}   
        public AuthorDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
