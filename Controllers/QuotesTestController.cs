using Microsoft.AspNetCore.Mvc;
using SwaggerTest.Service;
using System.Threading.Tasks;

namespace SwaggerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesTestController : ControllerBase
    {
        private readonly IQuoteTestService _quoteService;

        public QuotesTestController(IQuoteTestService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _quoteService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuoteTestModel model)
        {
            await _quoteService.CreateAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuoteTestModel model)
        {
            await _quoteService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quoteService.DeleteAsync(id);
            return Ok();
        }
    }
}