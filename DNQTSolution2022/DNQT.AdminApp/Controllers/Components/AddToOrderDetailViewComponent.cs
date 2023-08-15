using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers.Components
{
    public class AddToOrderDetailViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string strPart, string strViewName = "Default")
        {
            var strNameComponent = DNQT.ToolCommon.QTConstants.Components.AddToOrderDetail.STR;
            if (strNameComponent == "")
            {
            }

            return Task.FromResult((IViewComponentResult)View(strViewName, strPart));
        }
    }
}
