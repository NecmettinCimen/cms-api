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
    public class BaseControllerTest<TEntity> where TEntity : BaseModel
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

            await GetToken();

            var response = await _client.PostAsync($"/api/v1/{Controller}", new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json"));
            var resultStr = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

            response = await _client.PutAsync($"/api/v1/{Controller}", new StringContent(JsonSerializer.Serialize(result.Result), Encoding.UTF8, "application/json"));
            resultStr = await response.Content.ReadAsStringAsync();

            result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

            BaseModel idModel = JsonSerializer.Deserialize<BaseModel>(JsonSerializer.Serialize(result.Result));
            response = await _client.DeleteAsync($"/api/v1/{Controller}/{idModel.Id}");
            resultStr = await response.Content.ReadAsStringAsync();

            result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
            Assert.True(result.Success);

        }

        protected virtual async Task GetToken()
        {
            string token = string.Empty;
            if (System.IO.File.Exists("Token.txt"))
            {
                token = System.IO.File.ReadAllText("Token.txt");

            }
            else
            {
                var response = await _client.PostAsync($"/api/v1/User/Authenticate", new StringContent(JsonSerializer.Serialize(new
                {
                    email = "admin",
                    password = "123qwe"
                }), Encoding.UTF8, "application/json"));
                var resultStr = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<CommonApiResponse>(resultStr);
                Assert.True(result.Success);
                token = result.Result.ToString();
                System.IO.File.WriteAllText("Token.txt", token);
            }
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        }
    }
}
