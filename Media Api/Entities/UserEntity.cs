namespace Media_Api.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public List<PostEntity> Posts { get; set; }
    public List<CommentEntity> Comments { get; set; }
}