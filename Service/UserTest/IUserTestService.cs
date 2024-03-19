using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public interface IUserTestService
    {
        Task<UserTestModel> GetAsync(int id);
        Task CreateAsync(UserTestModel model);
        Task UpdateAsync(int id, UserTestModel model);
        Task DeleteAsync(int id);
    }
}
