using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using cms_api;
using cms_api.Helper;
using cms_api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace TESTS
{
    public class BaseControllerTest<TEntity> where TEntity:BaseModel
    {
        protected TestServer _server;
        protected HttpClient _client;
        protected string Controller;
        public TEntity model;
        public BaseControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();

        }
        public virtual async Task GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/{Controller}");
            var resultStr = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);
        }
        public virtual async Task AddUpdateDeleteAsync()
        {
            
            var response = await _client.PostAsync($"/api/v1/{Controller}",new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8, "application/json"));
            var resultStr = await response.Content.ReadAsStringAsync();
            
            var result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

            response = await _client.PutAsync($"/api/v1/{Controller}",new StringContent(JsonSerializer.Serialize(result.Result),Encoding.UTF8, "application/json"));
            resultStr = await response.Content.ReadAsStringAsync();
            
            result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

            response = await _client.DeleteAsync($"/api/v1/{Controller}/{model.Id}");
            resultStr = await response.Content.ReadAsStringAsync();
            
            result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

        }
    }
}
