using leave_a_comment_api.Data;
using leave_a_comment_api.Model;
using leave_a_comment_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace leave_a_comment_api.Services
{
    public class CommentService
    {
        private readonly CommentDbContext _context;
        private readonly CommentRepository _commentRepository;
        public CommentService(CommentDbContext context, CommentRepository commentRepository)
        {
            _context = context;
            _commentRepository = commentRepository;
        }

        public async Task<Comment> AddCommentAsync(string text)
        {
            var comment = new Comment
            {
                DateCreated = DateTime.UtcNow,
                Text = text
            };

            return await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllCommentsAsync();
        }
    }
}


