using DNQT.ViewModels.Admin.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.BackendApi.Services
{
    public interface ILoginService
    {
        string StrJsonAuthencate(LoginRequest_ViewModel mRequest);
    }
}
