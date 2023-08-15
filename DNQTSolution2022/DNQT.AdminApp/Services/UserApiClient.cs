using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.User;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> TStrAuthenticate(CreateUser_ViewModel mRequest)
        {
            string strJson = JsonConvert.SerializeObject(mRequest);
            var httpContent = new StringContent(strJson, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(STR_api.STR_BASE_ADDRESS.STR);
            var response = await client.PostAsync(STR_URI_User.STR_URI_INSERT_USER.STR, httpContent);
            string strToken = await response.Content.ReadAsStringAsync();
            return strToken;
        }
    }
}
