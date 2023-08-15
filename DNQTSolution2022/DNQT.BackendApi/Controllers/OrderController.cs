using DNQT.BackendApi.Services;
using DNQT.ToolCommon.ListStringApi;
using DNQT.ViewModels.Admin.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DNQT.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _iService;

        public OrderController(IOrderService iService)
        {
            _iService = iService;
        }

        //Link api: api/Order/TARGetOrderPaging?IntPageIndex=1&IntPageSize=10&keyword=
        [HttpGet(STR_URI_Order.TARGetOrderPaging.STR)]
        public IActionResult TARGetOrderPaging([FromQuery] GetOrderPaging_VMQuery mRequest)
        {
            var mResult = _iService.GetOrderPaging(mRequest);
            return Ok(mResult);
        }

        //Link api: api/Order/TARGetDetailOrderById?IntPageIndex=1&IntPageSize=10&keyword=
        [HttpGet(STR_URI_Order.TARGetDetailOrderById.STR)]
        public IActionResult TARGetDetailOrderById([FromQuery] int intId)
        {
            var mResult = _iService.GetDetailOrderById(intId);
            return Ok(mResult);
        }

        [HttpPost(STR_URI_Order.TARDeleteDetailOrderById.STR)]
        public IActionResult TARDeleteDetailOrderById([FromBody] int intId)
        {
            var mResult = _iService.DeleteDetailOrderById(intId);
            return Ok(mResult);
        }

        //Link api: api/Order/TARGetDetailOrderById?IntPageIndex=1&IntPageSize=10&keyword=
        [HttpGet(STR_URI_Order.TARGetAllProductLeftJoinDepot.STR)]
        public IActionResult TARGetAllProductLeftJoinDepot()
        {
            var mResult = _iService.GetAllProductLeftJoinDepot();
            return Ok(mResult);
        }

        //Link api: api/Order/TARGetAllProductByListName?arrayString=a&arrayString=b...
        [HttpGet(STR_URI_Order.TARGetAllProductByListName.STR)]
        public IActionResult TARGetAllProductByListName([FromQuery] string[] arrayString)
        {
            var lstString = new List<string>(arrayString);
            var mResult = _iService.GetAllProductByListName(lstString);
            return Ok(mResult);
        }

        //Link api: api/Order/TARGetDTIdNewByInsertNameProduct?strInputName=strInputName
        [HttpGet(STR_URI_Order.TARGetDTIdNewByInsertNameProduct.STR)]
        public IActionResult TARGetDTIdNewByInsertNameProduct([FromQuery] string strInputName)
        {
            var mResult = _iService.GetDTIdNewByInsertNameProduct(strInputName);
            return Ok(mResult);
        }

        //Link api: api/Order/TARAddProductToOrder?StrNameProduct=1&StrQuantity=10&StrPrice=
        [HttpPost(STR_URI_Order.TARAddProductToOrder.STR)]
        public IActionResult TARAddProductToOrder([FromBody] AddProductToOrder_VMQuery mRequest)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.AddProductToOrder(mRequest);
            return Ok(mResult);
        }

        //Link api: api/Order/TARUpdateProductInOrder?StrQuantity=1&StrPrice=10&IntIdDetailOrder=
        [HttpPost(STR_URI_Order.TARUpdateProductInOrder.STR)]
        public IActionResult TARUpdateProductInOrder([FromBody] UpdateProductInOrder_VMQuery mRequest)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.UpdateProductInOrder(mRequest);
            return Ok(mResult);
        }

        //Link api: api/Order/TARGetOrderPagingByDictionary?...
        [HttpPost(STR_URI_Order.TARGetOrderPagingByDictionary.STR)]
        public IActionResult TARGetOrderPagingByDictionary([FromBody] Dictionary<string, object> dicInput)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.GetOrderPagingByDictionary(dicInput);
            return Ok(mResult);
        }
        
        //Link api: api/Order/TARGetOrderPagingByDictionary?...
        [HttpPost(STR_URI_Order.TARGetStatisticOrderByDictionary.STR)]
        public IActionResult TARGetStatisticOrderByDictionary([FromBody] Dictionary<string, object> dicInput)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var mResult = _iService.GetStatisticOrderByDictionary(dicInput);
            return Ok(mResult);
        }

        //Link api: api/Order/TARAddOrder?...
        [HttpPost(STR_URI_Order.TARAddOrder.STR)]
        public IActionResult TARAddOrder([FromBody] Dictionary<string, object> dicInput)
        {
            var mResult = _iService.AddOrder(dicInput);
            return Ok(mResult);
        }

    }
}
