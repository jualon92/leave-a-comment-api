namespace leave_a_comment_api.Model
{
    public class Comment
    { 
        public int Id { get; set; }
        public string? Text { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
