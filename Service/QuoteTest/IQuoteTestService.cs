using System.Threading.Tasks;

namespace SwaggerTest.Service
{
    public interface IQuoteTestService
    {
        Task<QuoteTestModel> GetAsync(int id);
        Task CreateAsync(QuoteTestModel model);
        Task UpdateAsync(int id, QuoteTestModel model);
        Task DeleteAsync(int id);
    }
}