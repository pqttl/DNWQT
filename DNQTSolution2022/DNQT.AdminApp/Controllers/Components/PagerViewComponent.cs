using DNQT.ToolCommon;
using DNQT.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            var strNameComponent = DNQT.ToolCommon.QTConstants.Components.Pager.STR;
            if (strNameComponent == "")
            {
            }

            string strViewName = QTConstants.Components.Pager.Default.STR;
            return Task.FromResult((IViewComponentResult)View(strViewName, result));
        }
    }
}
