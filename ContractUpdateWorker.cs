using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestBackgroundApis.Models;

namespace TestBackgroundApis
{
    public class ContractUpdateWorker
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DataContext _dbContext;
        private string url = "http://localhost:3000";
        public ContractUpdateWorker(IHttpClientFactory httpClientFactory, DataContext dataContext)
        {
            _httpClientFactory = httpClientFactory;
            _dbContext = dataContext;
        }

        public async Task UpdateRecords(int index = 0)
        {
            var startIndex = index - 99;
            for (; startIndex <= index; startIndex++)
            {
                var context = _httpClientFactory.CreateClient();
                var result = await context.GetAsync($"{url}/{startIndex}", new CancellationToken()).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    var fakeObj = JsonConvert.DeserializeObject<Fake>(json);
                    if (fakeObj != null)
                    {
                        _dbContext.Fakes.Update(fakeObj);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }

}
