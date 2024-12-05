using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(350)]
        public string Password { get; set; }
        public User(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
    }
}
