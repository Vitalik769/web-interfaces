using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public class UserTestService : IUserTestService
    {
        private readonly List<UserTestModel> _data;

        public UserTestService()
        {
            _data = new List<UserTestModel>();
            // Add 10 records to simulate working with the database
            for (int i = 1; i <= 10; i++)
            {
                _data.Add(new UserTestModel { Id = i, Name = $"Item {i}" });
            }
        }

        public Task<UserTestModel> GetAsync(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
        }

        public Task CreateAsync(UserTestModel model)
        {
            _data.Add(model);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(int id, UserTestModel model)
        {
            var existingItem = _data.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = model.Name;
                existingItem.Email = model.Email;
                existingItem.Password = model.Password;
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
