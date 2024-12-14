using leave_a_comment_api.Data;
using leave_a_comment_api.Model;
using Microsoft.EntityFrameworkCore;

namespace leave_a_comment_api.Repository
{
    public class CommentRepository 
    {
        private readonly CommentDbContext _context;

        public CommentRepository(CommentDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllCommentsAsync() // Implementación del nuevo método
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
