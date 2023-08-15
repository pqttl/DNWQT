using DNQT.ViewModels.Admin.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public interface IViewRenderService
    {
        Task<string> TStrRenderToStringAsync(string viewName, object model);
    }
}
