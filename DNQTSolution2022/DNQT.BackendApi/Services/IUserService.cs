using DNQT.ViewModels.Admin.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.BackendApi.Services
{
    public interface IUserService
    {
        string TStrAuthencate(CreateUser_ViewModel mRequest);
    }
}
