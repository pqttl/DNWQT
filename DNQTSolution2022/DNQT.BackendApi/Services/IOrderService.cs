using DNQT.ViewModels.Admin.Order;
using DNQT.ViewModels.Common;
using System.Collections.Generic;
using System.Data;

namespace DNQT.BackendApi.Services
{
    public interface IOrderService
    {

        ApiResult<PagedResult<DataTable>> GetOrderPaging(GetOrderPaging_VMQuery mRequest);
        ApiResult<PagedResult<DataTable>> GetDetailOrderById(int intId);
        ApiResult<bool> DeleteDetailOrderById(int intId);
        ApiResult<PagedResult<DataTable>> GetAllProductLeftJoinDepot();
        ApiResult<PagedResult<DataTable>> GetAllProductByListName(List<string> lstString);
        ApiResult<PagedResult<DataTable>> GetDTIdNewByInsertNameProduct(string strInputName);
        ApiResult<bool> AddProductToOrder(AddProductToOrder_VMQuery mRequest);
        ApiResult<bool> UpdateProductInOrder(UpdateProductInOrder_VMQuery mRequest);
        ApiResult<PagedResult<DataTable>> GetOrderPagingByDictionary(Dictionary<string, object> dicInput);
        ApiResult<bool> GetStatisticOrderByDictionary(Dictionary<string, object> dicInput);
        ApiResult<bool> AddOrder(Dictionary<string, object> dicInput);
    }
}
