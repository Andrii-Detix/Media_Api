using Media_Api.Entities;
using Media_Api.Models;
using Media_Api.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace Media_Api.Repositories;

public class UserRepository
{
    private readonly MediaDbContext _dbContext;

    public UserRepository(MediaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<IdentifiedUser>> GetAll()
    {
        var users = await _dbContext.Users
            .Select(u => new IdentifiedUser(u))
            .ToListAsync();

        return users;
    }

    public async Task<IdentifiedUser> GetById(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user is null)
            throw new Exception($"User with id {id} not found");

        return new IdentifiedUser(user);
    }

    public async Task<IdentifiedUser> Add(User user)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Login == user.Login))
            throw new Exception($"User with login {user.Login} already exists");

        if (await _dbContext.Users.AnyAsync(u => u.Email == user.Email))
            throw new Exception($"User with email {user.Email} already exists");

        var created = new UserEntity()
        {
            Login = user.Login,
            Name = user.Name,
            Password = user.Password,
            Email = user.Email,
            Age = user.Age
        };

        await _dbContext.Users.AddAsync(created);
        await _dbContext.SaveChangesAsync();

        return new IdentifiedUser(created);
    }

    public async Task UpdatePassword(int id, string password)
    {
        int count = await _dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Password, password));

        if (count == 0)
            throw new Exception($"User with id {id} not found");
    }

    public async Task Delete(int id)
    {
        await _dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
    }
}