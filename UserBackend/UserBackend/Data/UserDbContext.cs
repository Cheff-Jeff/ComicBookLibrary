using UserBackend.Modals;
using Microsoft.EntityFrameworkCore;

namespace UserBackend.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}
