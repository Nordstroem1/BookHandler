using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Author
    {
        [Required]
        public Guid Id { get; private set; }
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [MinLength(2)]
        [MaxLength(80)]
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
