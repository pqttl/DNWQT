using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.Order;
using DNQT.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Services
{
    public class StatisticApiClient : BaseApiClient, IStatisticApiClient
    {

        public StatisticApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetOrderPaging(GetOrderPaging_VMQuery mRequest)
        {
            string strRequestUri = $"{STR_URI_Order.STR_URI_ORDERPAGING.STR}" 
                + $"?{nameof(mRequest.IntPageIndex)}={mRequest.IntPageIndex}" 
                + $"&{nameof(mRequest.IntPageSize)}={mRequest.IntPageSize}" 
                + $"&{nameof(mRequest.StrTypeDevice)}={mRequest.StrTypeDevice}" 
                + $"&{nameof(mRequest.Keyword)}={mRequest.Keyword}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetDetailOrderById(int intId)
        {
            string strRequestUri = $"{STR_URI_Order.STR_URI_DETAILORDER_BYID.STR}"
                + $"?{nameof(intId)}={intId}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<bool>> TApiUpdateProductInOrder(UpdateProductInOrder_VMQuery mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Order.STR_URI_UPDATE_PRODUCT_IN_ORDER.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        #region POST METHOD

        public async Task<ApiResult<bool>> TApiGetStatisticOrderByDictionary(Dictionary<string, object> dicInput)
        {
            string strJsonInput = JsonConvert.SerializeObject(dicInput);
            string strRequestUri = STR_URI_Order.STR_URI_GET_STATISTIC_ORDER_BY_DICTIONARY.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }
        
        public async Task<ApiResult<bool>> TApiAddOrder(Dictionary<string, object> dicInput)
        {
            string strJsonInput = JsonConvert.SerializeObject(dicInput);
            string strRequestUri = STR_URI_Order.STR_URI_ADD_ORDER.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetOrderPagingByDictionary(Dictionary<string, object> dicInput)
        {
            string strJsonInput = JsonConvert.SerializeObject(dicInput);
            string strRequestUri = STR_URI_Order.STR_URI_GET_ORDER_PAGING_BY_DICTIONARY.STR;

            var mApiResult = await TPostAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        public async Task<ApiResult<bool>> TApiAddProductToOrder(AddProductToOrder_VMQuery mRequest)
        {
            string strJsonInput = JsonConvert.SerializeObject(mRequest);
            string strRequestUri = STR_URI_Order.STR_URI_ADD_PRODUCT_TO_ORDER.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        } 

        #endregion

        //public async Task<ApiResult<bool>> TApiDeleteDetailById(int intId)
        //{
        //    string strRequestUri = $"{STR_URI_Order.STR_URI_DELETE_DETAILORDER_BYID.STR}"
        //        + $"/{intId}";

        //    var mApiResult = await TDeleteAsync<ApiResult<bool>>(strRequestUri);
        //    return mApiResult;
        //}
        
        public async Task<ApiResult<bool>> TApiDeleteDetailById(int intId)
        {
            string strJsonInput = JsonConvert.SerializeObject(intId);
            string strRequestUri = STR_URI_Order.STR_URI_DELETE_DETAILORDER_BYID.STR;

            var mApiResult = await TPostAsync<ApiResult<bool>>(strRequestUri, strJsonInput);
            return mApiResult;
        }

        #region GET METHOD

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetAllProductLeftJoinDepot()
        {
            string strRequestUri = $"{STR_URI_Order.STR_URI_GETALL_PRODUCT_JOIN_DEPOT.STR}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiGetAllProductByListName(List<string> lstString)
        {
            string strRequestUri = $"{STR_URI_Order.STR_URI_GETALL_PRODUCT_BY_LISTNAME.STR}";
            if (lstString.Count > 0)
            {
                string strParamNameInUri = "arrayString";
                for (int i = 0; i < lstString.Count; i++)
                {
                    string strTemp = $"{strParamNameInUri}={lstString[i]}";
                    if (i == 0)
                    {
                        strRequestUri += $"?" + strTemp;
                        continue;
                    }

                    strRequestUri += $"&" + strTemp;
                }
            }

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        public async Task<ApiResult<PagedResult<DataTable>>> TApiDTIdNewByInsertNameProduct(string strInputName)
        {
            string strRequestUri = $"{STR_URI_Order.STR_URI_GET_DT_IDNEW_BY_INSERT_NAMEPRODUCT.STR}"
                + $"?{nameof(strInputName)}={strInputName}";

            var mApiResult = await TGetAsync<ApiResult<PagedResult<DataTable>>>(strRequestUri);
            return mApiResult;
        }

        #endregion

    }
}
