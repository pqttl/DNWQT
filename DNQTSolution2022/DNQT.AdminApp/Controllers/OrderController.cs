using DNQT.AdminApp.Services;
using DNQT.ViewModels.Admin.Order;
using DNQT.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderApiClient _iApiClient;
        private readonly BLLProject _bllPlugin = new BLLProject();
        private const int INT_PAGE_SIZE = 10;
        private string StrNameOfOrderControllerIndex = nameof(OrderController)+nameof(Index);
        private string StrIdToClickWhenLoaded =null;

        public OrderController(IOrderApiClient iApiClient)
        {
            _iApiClient = iApiClient;
        }

        public async Task<IActionResult> Index(int intPageIndex = 0
            , int intPageSize = INT_PAGE_SIZE, int intIdRowHighlight = -1
            , string strTypeDevice = "mobile")
        {
            //Dùng url để truyền giá trị vào biến thì url không cần phân biệt hoa thường
            //pageIndex, pageindex đều được
            var mRequest = new GetOrderPaging_VMQuery()
            {
                IntPageIndex = intPageIndex,
                StrTypeDevice = strTypeDevice,
                IntPageSize = intPageSize
            };
            var mApi = await _iApiClient.TApiGetOrderPaging(mRequest);
            _bllPlugin.ChangeColumnNameInDataTable(ref mApi);

            ViewBag.intPageSize = intPageSize;
            ViewBag.intIdRowHighlight = intIdRowHighlight;

            //var lstTupleButtonChangeView = new List<Tuple<string,string>>();
            //lstTupleButtonChangeView.Add(new Tuple<string, string>("mobile", "Xem trên điện thoại..."));
            //lstTupleButtonChangeView.Add(new Tuple<string, string>("pc", "Xem trên máy tính..."));
            //Tuple<int,  string, string> tupleChangeView = null; 
            //foreach (var item in lstTupleButtonChangeView)
            //{
            //    if (item.Item1!= strTypeDevice)
            //    {
            //        tupleChangeView = new Tuple<int,  string, string>(intPageIndex, item.Item1, item.Item2);
            //        break;
            //    }
            //}
            //ViewBag.tupleChangeView = tupleChangeView;

            HttpContext.Session.SetString(StrNameOfOrderControllerIndex,""+ intPageIndex);

            var mVMDataTable = new OrderPagingMobile_VMDataTable();
            ViewBag.MDisplay = mVMDataTable.MDisplay;

            StrIdToClickWhenLoaded = HttpContext.Session.GetString(nameof(StrIdToClickWhenLoaded));
            if (StrIdToClickWhenLoaded != null && StrIdToClickWhenLoaded.ToString() != "")
            {
                ViewBag.StrIdToClickWhenLoaded = StrIdToClickWhenLoaded;
                HttpContext.Session.SetString(nameof(StrIdToClickWhenLoaded), "");
            }

            return View(mApi.TResultObj);
        }
        
        public async Task<IActionResult> IndexNewest()
        {
            var mApi = await _iApiClient.TApiGetOrderPaging(new GetOrderPaging_VMQuery()
            {
                IntPageIndex = 0,
                IntPageSize = INT_PAGE_SIZE
            });

            string strTemp = nameof(OrderController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            return RedirectToAction(nameof(OrderController.Index), strController
                , new { IntPageIndex = mApi.TResultObj.IntSumPage-1 });
        }

        public async Task<IActionResult> Detail(int intId)
        {
            var mApi = await _iApiClient.TApiGetDetailOrderById(intId);
            _bllPlugin.ChangeColumnNameInDataTable(ref mApi);

            string IntPageIndex = "0";
            {
                var strSession = HttpContext.Session.GetString(StrNameOfOrderControllerIndex);
                if (strSession != null)
                {
                    IntPageIndex = strSession;
                }
            }
            int intTemp = 0;
            int.TryParse(IntPageIndex, out intTemp);
            ViewBag.strBreadcrumbBack = $"Danh sách đơn hàng trang {(intTemp + 1)}";

            Tuple<string, string> tupleSumSoLuong1GiaTri2 = JsonConvert.DeserializeObject<Tuple<string, string>>(
                mApi.DicResult["Tuple<string, string>"].ToString());
            ViewBag.strBreadcrumbCurrent = $"Chi tiết hóa đơn " +
                $"({mApi.TResultObj.IntTotalRecords} vị thuốc " +
                $"- {tupleSumSoLuong1GiaTri2.Item1} Kg - {tupleSumSoLuong1GiaTri2.Item2})";

            string strDivDetailOrder = $"<div class=\"d-flex justify-content-end\">" +
                $"<h3>({tupleSumSoLuong1GiaTri2.Item1} Kg) </h3>" +
                $"<h3 class=\"font-weight-bold text-danger ml-4\">{tupleSumSoLuong1GiaTri2.Item2}</h3></div>";
            ViewBag.strDivDetailOrder = strDivDetailOrder;

            ViewBag.IntPageIndex = IntPageIndex;
            ViewBag.IntIdToBack = intId;

            string strMessage = "Vị thuốc bạn chọn sẽ bị xóa khỏi đơn hàng này!";
            strMessage += "\\n" + "Tổng giá đơn hàng sẽ giảm đi tương ứng!";
            strMessage += "\\n" + "Bạn chắc chắn muốn thực hiện thao tác này?";
            ViewBag.strConfirmJs = $"'{strMessage}'";

            var mVMDataTable = new DetailOrderMobile_VMDataTable();
            ViewBag.MDisplay = mVMDataTable.MDisplay;

            StrIdToClickWhenLoaded = HttpContext.Session.GetString(nameof(StrIdToClickWhenLoaded));
            if (StrIdToClickWhenLoaded != null && StrIdToClickWhenLoaded.ToString()!="")
            {
                ViewBag.StrIdToClickWhenLoaded = StrIdToClickWhenLoaded;
                HttpContext.Session.SetString(nameof(StrIdToClickWhenLoaded), "");
            }

            return View(mApi.TResultObj);
        }

        public async Task<IActionResult> DeleteDetail(ActionRequestBase mRequest)
        {
            string strTemp = nameof(OrderController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            string strAction = nameof(Detail);

            if (!ModelState.IsValid)
                return RedirectToAction(strAction, strController
                , new { intId = mRequest.IntIdToBack });

            var mApi = await _iApiClient.TApiDeleteDetailById(mRequest.IntIdInput);
            if (mApi.BlnIsSuccessed)
            {
                TempData["result"] = "Thao tác xóa thành công!";
                return RedirectToAction(strAction, strController
                , new { intId = mRequest.IntIdToBack });
            }

            //ModelState.AddModelError("", mApi.Message);
            return RedirectToAction(strAction, strController
            , new { intId = mRequest.IntIdToBack });
        }

        #region JsonResult ajax

        public async Task<IActionResult> JsonResultUpdateProductInOrder(
            string strSpanKg, string strSpanDonGia,int intIdDetailOrder)
        {
            try
            {
                {
                    var mApi = await _iApiClient.TApiUpdateProductInOrder(new UpdateProductInOrder_VMQuery()
                    {
                        StrQuantity = strSpanKg
                        ,
                        StrPrice = strSpanDonGia
                        ,
                        IntIdDetailOrder = intIdDetailOrder
                    });

                    if (mApi.BlnIsSuccessed == false)
                    {
                        string strIdFocus = mApi.DicResult[nameof(strIdFocus)].ToString();
                        return Json(new
                        {
                            blnStatusJs = false,
                            strMess = mApi.StrMessage,
                            strIdFocus = strIdFocus
                        });
                    }

                    //HttpContext.Session.SetString(nameof(StrIdToClickWhenLoaded), "idALoadNameProductGoiY");

                    return Json(new
                    {
                        blnStatusJs = mApi.BlnIsSuccessed,
                        strMess = mApi.StrMessage
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strMess = et.Message + "\n"+ et.StackTrace,
                    strIdFocus = nameof(strSpanKg)
                });
            }
        }
        
        public async Task<IActionResult> JsonResultAddProductToOrder(string strInputName
            , string strSpanKg, string strSpanDonGia,int intIdOrder)
        {
            try
            {
                {
                    var mApi = await _iApiClient.TApiAddProductToOrder(new AddProductToOrder_VMQuery()
                    {
                        StrNameProduct = strInputName
                        ,
                        StrQuantity = strSpanKg
                        ,
                        StrPrice = strSpanDonGia
                        ,
                        IntIdOrder = intIdOrder
                    });

                    if (mApi.BlnIsSuccessed == false)
                    {
                        string strIdFocus = mApi.DicResult[nameof(strIdFocus)].ToString();
                        return Json(new
                        {
                            blnStatusJs = false,
                            strMess = mApi.StrMessage,
                            strIdFocus = strIdFocus
                        });
                    }

                    HttpContext.Session.SetString(nameof(StrIdToClickWhenLoaded), "idALoadNameProductGoiY");

                    return Json(new
                    {
                        blnStatusJs = mApi.BlnIsSuccessed,
                        strMess = mApi.StrMessage
                    });
                }
            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strMess = et.Message + "\n"+ et.StackTrace,
                    strIdFocus = nameof(strInputName)
                });
            }
        }
        
        public async Task<IActionResult> JsonResultGetNameProductGoiY(string strTitle)
        {
            var mApi = await _iApiClient.TApiGetAllProductLeftJoinDepot();
            strTitle = "Hiện có " + "" + mApi.TResultObj.IntTotalRecords + " sản phẩm";

            string strListNameProduct = "";
            string strListQuantity = "";
            _bllPlugin.GetStringListNameQuantityFromDatatable(ref strListNameProduct
                ,ref strListQuantity, mApi.TResultObj.TOneItem);

            return Json(new
            {
                blnStatusJs = true,
                strTitle = strTitle,
                strArrayNameJs= $"[{strListNameProduct}]",
                strArrayQuantityJs= $"[{strListQuantity}]"
            });
        }
        
        public async Task<IActionResult> JsonResultDeleteDetailById(int intId)
        {
            var mApi = await _iApiClient.TApiDeleteDetailById(intId);
            if (mApi.BlnIsSuccessed==false)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strMess= (mApi.StrMessage+"\n"+ mApi.StrDetailMessage)
                });
            }

            return Json(new
            {
                blnStatusJs = true,
                strMess = "Thao tác xóa thành công!"
            });
        }

        public async Task<IActionResult> JsonResultAddOrder(string[] arrayStrInput)
        {
            string strNameFunction = nameof(JsonResultAddOrder);
            try
            {
                var dicInput = new Dictionary<string, object>();

                var mApi = await _iApiClient.TApiAddOrder(dicInput);

                if (mApi.BlnIsSuccessed == false)
                {
                    return Json(new
                    {
                        blnStatusJs = false,
                        strMess = mApi.StrMessage
                    });
                }

                HttpContext.Session.SetString(nameof(StrIdToClickWhenLoaded), $"idA{strNameFunction}");

                string strTemp = nameof(OrderController);
                string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
                string strHref = $"/{strController}/{nameof(IndexNewest)}";

                return Json(new
                {
                    blnStatusJs = true,
                    strMess = "suceess",

                    strHref = strHref,

                    strNameVoid = strNameFunction
                });

            }
            catch (Exception et)
            {
                return Json(new
                {
                    blnStatusJs = false,
                    strNameVoid = strNameFunction,
                    strMess = et.Message + "\n" + et.StackTrace
                });
            }
        }

        #endregion

    }
}
