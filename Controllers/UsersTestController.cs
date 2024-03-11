using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTestController : ControllerBase
    {
        private readonly List<User> _users = new List<User>();

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            try
            {
                return Ok(_users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetUserById/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _users.Find(u => u.Id == userId);
                if (user == null)
                    return NotFound("User not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("PostUser")]
        public IActionResult PostUser([FromBody] User model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Invalid model");

                _users.Add(model);

                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var user = _users.Find(u => u.Id == userId);
                if (user == null)
                    return NotFound("User not found");

                _users.Remove(user);

                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}