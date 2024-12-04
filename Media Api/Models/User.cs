namespace Media_Api.Models;

public class User
{
    public User(string login, string name, string password, string email, int? age)
    {
        Login = login;
        Name = name;
        Password = password;
        Email = email;
        Age = age;
    }

    public string Login { get; }
    public string Name { get; }
    public string Password { get; }
    public string Email { get; }
    public int? Age { get; }
}