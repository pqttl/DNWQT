using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public class LoginApiClient : BaseApiClient, ILoginApiClient
    {

        public LoginApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<string> TStrJsonAuthenticate(LoginRequest_ViewModel mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Login.STR_URI_DANGNHAP.STR;

            string strJsonDictionary = await TStringPostAsync(strRequestUri, strJsonInput);
            return strJsonDictionary;
        }

    }
}
