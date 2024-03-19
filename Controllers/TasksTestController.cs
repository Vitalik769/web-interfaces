using Microsoft.AspNetCore.Mvc;
using SwaggerTest.Service;
using System.Threading.Tasks;

namespace SwaggerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksTestController : ControllerBase
    {
        private readonly ITaskTestService _taskService;

        public TasksTestController(ITaskTestService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _taskService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskTestModel model)
        {
            await _taskService.CreateAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskTestModel model)
        {
            await _taskService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteAsync(id);
            return Ok();
        }
    }
}