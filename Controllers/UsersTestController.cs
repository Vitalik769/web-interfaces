using Microsoft.AspNetCore.Mvc;
using SwaggerTest.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaggerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTestController : ControllerBase
    {
        private readonly IUserTestService _userService;

        public UsersTestController(IUserTestService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTestModel model)
        {
            await _userService.CreateAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserTestModel model)
        {
            await _userService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
