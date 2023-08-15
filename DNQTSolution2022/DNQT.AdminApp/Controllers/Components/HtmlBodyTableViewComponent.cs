using DNQT.ViewModels.Admin.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers.Components
{
    public class HtmlBodyTableViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(DisplayColumn_VMDataTable mdisplay
            , System.Data.DataTable dt, System.Data.DataRow datarow, string strViewName = "Default")
        {
            var strNameComponent = DNQT.ToolCommon.QTConstants.Components.HtmlBodyTable.STR;
            if (strNameComponent == "")
            {
            }

            (DisplayColumn_VMDataTable mdisplay
            , System.Data.DataTable dt, System.Data.DataRow datarow) data
                = (mdisplay, dt, datarow);
            return Task.FromResult((IViewComponentResult)View(strViewName, data));
        }
    }
}
