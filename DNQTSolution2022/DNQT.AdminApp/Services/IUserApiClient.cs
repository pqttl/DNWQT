using DNQT.ViewModels.Admin.User;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> TStrAuthenticate(CreateUser_ViewModel mRequest);
    }
}
