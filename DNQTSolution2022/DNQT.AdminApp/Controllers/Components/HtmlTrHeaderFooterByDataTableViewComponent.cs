using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers.Components
{
    public class HtmlTrHeaderFooterByDataTableViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(List<string> LstStringColumnCollapse
            , System.Data.DataTable dt, List<string> LstStringColumnAddToEnd, string strViewName = "Default")
        {
            var strNameComponent = DNQT.ToolCommon.QTConstants.Components.HtmlTrHeaderFooterByDataTable.STR;
            if (strNameComponent == "")
            {
            }

            (List<string> LstStringColumnCollapse, System.Data.DataTable dt, List<string> LstStringColumnAddToEnd) data 
                = (LstStringColumnCollapse, dt, LstStringColumnAddToEnd);
            //string strViewName = QTConstants.Components.HtmlTrHeaderFooterByDataTable.Default.STR;
            return Task.FromResult((IViewComponentResult)View(strViewName, data));
        }
    }
}
