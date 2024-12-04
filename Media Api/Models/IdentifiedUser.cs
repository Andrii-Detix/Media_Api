using Media_Api.Entities;

namespace Media_Api.Models;

public class IdentifiedUser : User, IHasId
{
    public IdentifiedUser(int id, string login, string name, string password, string email, int? age)
        : base(login, name, password, email, age)
    {
        Id = id;
    }

    public IdentifiedUser(UserEntity u) : this(u.Id, u.Login, u.Name, u.Password, u.Email, u.Age)
    {
    }

    public int Id { get; }
}