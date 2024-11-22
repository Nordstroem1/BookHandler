namespace Domain.Models
{
    public class User
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
    }
}
