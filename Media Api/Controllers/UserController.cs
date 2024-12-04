using Media_Api.Models;
using Media_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Media_Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [Route("users")]
    [ProducesResponseType(typeof(List<IdentifiedUser>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<IdentifiedUser>>> GetAllUsers()
    {
        try
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: 500);
        }
    }

    [HttpGet]
    [Route("user/{id:int}")]
    [ProducesResponseType(typeof(IdentifiedUser), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IdentifiedUser>> GetUserById(int id)
    {
        try
        {
            var user = await _userRepository.GetById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: 404);
        }
    }

    [HttpPost]
    [Route("users")]
    [ProducesResponseType(typeof(IdentifiedUser), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IdentifiedUser>> CreateUser(User user)
    {
        try
        {
            var created = await _userRepository.Add(user);
            return Created($"/users/{created.Id}", created);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: 400);
        }
    }

    [HttpPut]
    [Route("users/{id:int}")]
    public async Task<ActionResult> UpdateUserPassword(int id, string password)
    {
        try
        {
            await _userRepository.UpdatePassword(id, password);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: 404);
        }
    }

    [HttpDelete]
    [Route("users/{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            await _userRepository.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: 500);
        }
    }
}