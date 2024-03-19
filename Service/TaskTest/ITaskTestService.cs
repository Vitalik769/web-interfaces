using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public interface ITaskTestService
    {
        Task<TaskTestModel> GetAsync(int id);
        Task CreateAsync(TaskTestModel model);
        Task UpdateAsync(int id, TaskTestModel model);
        Task DeleteAsync(int id);
    }
}