using Microsoft.EntityFrameworkCore;
using MiniProject.DBModels;

namespace MiniProject.Models
{
    public class InboxContext(DbContextOptions<InboxContext> options) : DbContext(options)
    {
        public DbSet<Posts> Burhan_Post { get; set; }
        public DbSet<Users> Burhan_User { get; set; }

        //public DbSet<UsersReturn> Burhan_User { get; set; }
    }

}
