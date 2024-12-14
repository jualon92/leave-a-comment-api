using leave_a_comment_api.Model;
using Microsoft.EntityFrameworkCore;

namespace leave_a_comment_api.Data
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }


}
