using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public class QuoteTestService : IQuoteTestService
    {
        private readonly List<QuoteTestModel> _data;

        public QuoteTestService()
        {
            _data = new List<QuoteTestModel>();
            // Add 10 records to simulate working with the database
            for (int i = 1; i <= 10; i++)
            {
                _data.Add(new QuoteTestModel { Id = i, Text = $"Quote {i}" });
            }
        }

        public Task<QuoteTestModel> GetAsync(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
        }

        public Task CreateAsync(QuoteTestModel model)
        {
            _data.Add(model);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(int id, QuoteTestModel model)
        {
            var existingItem = _data.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Text = model.Text;
                existingItem.Author = model.Author;
                existingItem.Category = model.Category;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var itemToRemove = _data.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                _data.Remove(itemToRemove);
            }
            return Task.CompletedTask;
        }
    }
}