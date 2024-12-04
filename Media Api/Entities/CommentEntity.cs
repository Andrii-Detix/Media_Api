namespace Media_Api.Entities;

public class CommentEntity
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public UserEntity User { get; set; }
    public PostEntity Post { get; set; }
}