using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases
{
    public class MySqlDatabase : DbContext
    {
        public MySqlDatabase(DbContextOptions<MySqlDatabase> options) : base(options){}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> AuthorBooks { get; set; }

    }
}
 