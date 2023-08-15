using DNQT.ViewModels.Admin.Order;
using DNQT.ViewModels.Common;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public interface IStatisticApiClient
    {
        Task<ApiResult<PagedResult<DataTable>>> TApiGetOrderPaging(GetOrderPaging_VMQuery mRequest);
        Task<ApiResult<PagedResult<DataTable>>> TApiGetDetailOrderById(int intId);
        Task<ApiResult<bool>> TApiDeleteDetailById(int intId);
        Task<ApiResult<PagedResult<DataTable>>> TApiGetAllProductLeftJoinDepot();
        Task<ApiResult<PagedResult<DataTable>>> TApiGetAllProductByListName(List<string> lstString);
        Task<ApiResult<PagedResult<DataTable>>> TApiDTIdNewByInsertNameProduct(string strInputName);
        Task<ApiResult<bool>> TApiAddProductToOrder(AddProductToOrder_VMQuery mRequest);
        Task<ApiResult<bool>> TApiUpdateProductInOrder(UpdateProductInOrder_VMQuery mRequest);
        Task<ApiResult<PagedResult<DataTable>>> TApiGetOrderPagingByDictionary(Dictionary<string, object> dicInput);
        Task<ApiResult<bool>> TApiGetStatisticOrderByDictionary(Dictionary<string, object> dicInput);
        Task<ApiResult<bool>> TApiAddOrder(Dictionary<string, object> dicInput);
    }
}
