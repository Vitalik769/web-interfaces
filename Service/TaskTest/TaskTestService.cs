using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public class TaskTestService : ITaskTestService
    {
        private readonly List<TaskTestModel> _data;

        public TaskTestService()
        {
            _data = new List<TaskTestModel>();
            // Add 10 records to simulate working with the database
            for (int i = 1; i <= 10; i++)
            {
                _data.Add(new TaskTestModel { Id = i, Name = $"Task {i}" });
            }
        }

        public Task<TaskTestModel> GetAsync(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
        }

        public Task CreateAsync(TaskTestModel model)
        {
            _data.Add(model);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(int id, TaskTestModel model)
        {
            var existingItem = _data.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = model.Name;
                existingItem.Description = model.Description;
                existingItem.Priority = model.Priority;
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