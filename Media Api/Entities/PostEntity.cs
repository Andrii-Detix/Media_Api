namespace Media_Api.Entities;

public class PostEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
    public UserEntity Author { get; set; }
    public List<CommentEntity> Comments { get; set; }
}