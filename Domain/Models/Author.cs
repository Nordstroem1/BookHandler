namespace Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }    
        public Author(Guid id, string name, DateOnly dateOfBirth, string placeOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
        }
    }
}
