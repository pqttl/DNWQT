using DNQT.DataAccessSQLite.DALSQLite;
using DNQT.ToolCommon;
using DNQT.ToolCommon.ListTableDatabase;
using DNQT.ViewModels.Admin.Order;
using DNQT.ViewModels.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace DNQT.BackendApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly DALLiteOrder DAL_Order = new DALLiteOrder();
        private readonly DALLiteProduct DAL_Product = new DALLiteProduct();
        private readonly BLLProject _bllPlugin = new BLLProject();
        private readonly IConfiguration _iConfig;

        public OrderService(IConfiguration config)
        {
            _iConfig = config;
        }

        public ApiResult<PagedResult<DataTable>> GetOrderPaging(GetOrderPaging_VMQuery mRequest)
        {
            Exception exOutput = null;
            DataTable DT_AllIdOrder = null;
            DAL_Order.GetDTAllIdOrder(ref DT_AllIdOrder, ref exOutput);

            var apiError = new ApiErrorResult<PagedResult<DataTable>>();
            var dicOutput = new Dictionary<string, object>();

            if (exOutput != null)
            {
                dicOutput["Exception"] = exOutput;
                //strJsonDictionary = JsonConvert.SerializeObject(dicOutput
                //  , Formatting.Indented);
                return apiError.MHaveMessage(exOutput.Message,exOutput.StackTrace);
            }

            //int intPageSize = Convert.ToInt32(_iConfig[KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_ORDER.STR]);
            var lstStringId = new List<string>();
            BLLTools.GetListStringIdInDataTable(ref lstStringId
              , mRequest.IntPageIndex, mRequest.IntPageSize, DT_AllIdOrder, "MaDonHang");
            if (lstStringId.Count == 0)
            {
                //QTMessageBox.ShowNotify(
                //  "Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                //  , "(lstStringId.Count==0)");
                return apiError.MHaveMessage("Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                    , "(lstStringId.Count==0)");
            }

            //Exception exOutput = null;
            DataTable DT_AllDetailOrderByListIdOrder = null;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput, lstStringId);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (DT_AllDetailOrderByListIdOrder == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_AllDetailOrderByListIdOrder==null)");
            }

            DataTable dtByPage = null;
            _bllPlugin.CloneAndCopyRowDataTableByPage(ref dtByPage, mRequest, DT_AllIdOrder);

            var dtOutput = new DataTable();
            if (mRequest.StrTypeDevice=="pc")
            {
                _bllPlugin.GetDataTableOrderPagingByPcView(ref dtOutput, dtByPage, DT_AllDetailOrderByListIdOrder); 
            }
            if (mRequest.StrTypeDevice=="mobile")
            {
                _bllPlugin.GetDataTableOrderPaging(ref dtOutput, dtByPage, DT_AllDetailOrderByListIdOrder); 
            }

            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = DT_AllIdOrder.Rows.Count,
                IntPageIndex = mRequest.IntPageIndex,
                IntPageSize = mRequest.IntPageSize,
                TOneItem= dtOutput
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
        }

        public ApiResult<PagedResult<DataTable>> GetAllProductLeftJoinDepot()
        {
            //var lstStringId = new List<string>(); 
            //lstStringId.Add(intId.ToString());

            var apiError = new ApiErrorResult<PagedResult<DataTable>>();

            Exception exOutput = null;
            DataTable DT_AllIdNameProduct = null;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Product.GetDTAllIdProductLeftJoinDepot(ref DT_AllIdNameProduct, ref exOutput);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (DT_AllIdNameProduct == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_AllIdNameProduct==null)");
            }

            //Tuple<string, string> tupleSumSoLuong1GiaTri2 = null;
            //float floatSumSoLuong = 0;
            //decimal decimalSumGiaTri = 0;
            //var dtOutput = new DataTable();
            //_bllPlugin.GetDataTableDetailOrder(ref tupleSumSoLuong1GiaTri2, ref floatSumSoLuong,ref decimalSumGiaTri
            //    , ref dtOutput, DT_AllIdNameProduct);

            //var dicOutput = new Dictionary<string,object>();
            //dicOutput["Tuple<string, string>"] = tupleSumSoLuong1GiaTri2;
            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = DT_AllIdNameProduct.Rows.Count,
                IntPageIndex = 0,
                IntPageSize = 9999,
                TOneItem = DT_AllIdNameProduct
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
        }
        
        public ApiResult<PagedResult<DataTable>> GetAllProductByListName(List<string> lstStringName)
        {
            var apiError = new ApiErrorResult<PagedResult<DataTable>>();

            Exception exOutput = null;
            DataTable DT_Output = null;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Product.GetDTAllIdProduct(ref DT_Output, ref exOutput, lstStringName);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (DT_Output == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_AllIdProduct==null)");
            }

            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = DT_Output.Rows.Count,
                IntPageIndex = 0,
                IntPageSize = 99999,
                TOneItem = DT_Output
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
        }
        
        public ApiResult<PagedResult<DataTable>> GetDTIdNewByInsertNameProduct(string strInputName)
        {
            var apiError = new ApiErrorResult<PagedResult<DataTable>>();

            Exception exOutput = null;
            DataTable DT_Output = null;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Product.GetDTIdNewByInsertNameProduct(ref DT_Output, ref exOutput, strInputName);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (DT_Output == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_Output==null)");
            }

            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = DT_Output.Rows.Count,
                IntPageIndex = 0,
                IntPageSize = 99999,
                TOneItem = DT_Output
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
        }

        public ApiResult<PagedResult<DataTable>> GetDetailOrderById(int intId)
        {
            var lstStringId = new List<string>(); 
            lstStringId.Add(intId.ToString());

            var apiError = new ApiErrorResult<PagedResult<DataTable>>();

            Exception exOutput = null;
            DataTable DT_AllDetailOrderByListIdOrder = null;
            //DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
            DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput, lstStringId);
            if (exOutput != null)
            {
                //Log4Net.Error(exOutput.Message);
                //Log4Net.Error(exOutput.StackTrace);
                //ShowException(exOutput);
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (DT_AllDetailOrderByListIdOrder == null)
            {
                //QTMessageBox.ShowNotify(
                //  "Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                //  , "(DT_AllDetailOrderByListIdOrder==null)");
                return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                    , "(DT_AllDetailOrderByListIdOrder==null)");
            }

            Tuple<string, string> tupleSumSoLuong1GiaTri2 = null;
            float floatSumSoLuong = 0;
            decimal decimalSumGiaTri = 0;
            var dtOutput = new DataTable();
            _bllPlugin.GetDataTableDetailOrder(ref tupleSumSoLuong1GiaTri2, ref floatSumSoLuong, ref decimalSumGiaTri
                    , ref dtOutput, DT_AllDetailOrderByListIdOrder);

            var dtOutputMobile = new DataTable();
            _bllPlugin.GetDataTableDetailOrderMobile(ref dtOutputMobile, dtOutput);

            var dicOutput = new Dictionary<string,object>();
            dicOutput["Tuple<string, string>"] = tupleSumSoLuong1GiaTri2;
            var mPagedResult = new PagedResult<DataTable>()
            {
                IntTotalRecords = dtOutputMobile.Rows.Count,
                IntPageIndex = 0,
                IntPageSize = 9999,
                TOneItem = dtOutputMobile
            };
            return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult, dicOutput);
        }

        public ApiResult<bool> DeleteDetailOrderById(int intId)
        {
            var lstStringId = new List<string>();
            lstStringId.Add(intId.ToString());

            var apiError = new ApiErrorResult<bool>();

            string strError = "";
            Exception exOutput = null;
            bool blnSuccess = false;
            DAL_Order.DeleteOrderDetailByListId(ref blnSuccess, ref strError, ref exOutput, lstStringId);
            if (exOutput != null)
            {
                return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
            }

            if (blnSuccess == false)
            {
                return apiError.MHaveMessage("Thao tác không thành công, bạn vui lòng kiểm tra lại!"
                    , strError);
            }

            return new ApiSuccessResult<bool>();
        }

        public ApiResult<bool> AddProductToOrder(AddProductToOrder_VMQuery mRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<bool>();
                var dicOutput = new Dictionary<string, object>();

                string strInputName = mRequest.StrNameProduct;
                if (strInputName == null || strInputName.ToString().Trim().Length < 2)
                {
                    string strMess = "Tên vị thuốc phải từ 2 ký tự chữ trở lên, bạn vui lòng kiểm tra lại!";
                    dicOutput["strIdFocus"] = nameof(strInputName);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                string strSpanKg = mRequest.StrQuantity;
                decimal decSoLuong = 0;
                BLLTools.GetDecimalFromString(ref decSoLuong, strSpanKg);
                if (decSoLuong <= 0)
                {
                    string strMess = "Số lượng phải lớn hơn 0, bạn vui lòng kiểm tra lại!";
                    dicOutput["strIdFocus"] = nameof(strSpanKg);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                string strSpanDonGia = mRequest.StrPrice;
                decimal decDonGia = 0;
                BLLTools.GetDecimalFromString(ref decDonGia, strSpanDonGia);
                if (decDonGia <= 1000)
                {
                    string strMess = "Đơn giá phải lớn hơn 1000, bạn vui lòng kiểm tra lại!";
                    dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                int intIdOrder = mRequest.IntIdOrder;
                {
                    //var mApi = GetDetailOrderById(intIdOrder);

                    var lstStringId = new List<string>();
                    lstStringId.Add(intIdOrder.ToString());

                    Exception exOutput = null;
                    DataTable DT_AllDetailOrderByListIdOrder = null;
                    DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput, lstStringId);
                    if (exOutput != null)
                    {
                        dicOutput["strIdFocus"] = nameof(strInputName);
                        return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput, exOutput.StackTrace);
                    }

                    if (DT_AllDetailOrderByListIdOrder == null)
                    {
                        dicOutput["strIdFocus"] = nameof(strInputName);
                        return apiError.MHaveMessageWithDictionary("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!", dicOutput
                            , "(DT_AllDetailOrderByListIdOrder==null)");
                    }

                    Tuple<string, string> tupleSumSoLuong1GiaTri2 = null;
                    float floatSumSoLuong = 0;
                    decimal decimalSumGiaTri = 0;
                    var dtOutput = new DataTable();
                    _bllPlugin.GetDataTableDetailOrder(ref tupleSumSoLuong1GiaTri2, ref floatSumSoLuong, ref decimalSumGiaTri
                            , ref dtOutput, DT_AllDetailOrderByListIdOrder);

                    bool blnExistNameInOrder = true;
                    var mVMDataTable = new DetailOrder_VMDataTable();
                    BLLTools.CheckStringExistInDataTable(ref blnExistNameInOrder, strInputName
                        , dtOutput, mVMDataTable.MDisplay.LstStringNameColumn[1]);
                    if (blnExistNameInOrder == true)
                    {
                        string strTemp = "Tên vị thuốc này đã có trong đơn hàng rồi, bạn vui lòng kiểm tra lại!";
                        strTemp += "\nNếu bạn muốn thay đổi số lượng hoặc đơn giá, vui lòng bấm 'Sửa' ở bảng!";
                        string strMess = strTemp;
                        dicOutput["strIdFocus"] = nameof(strInputName);
                        return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                    }
                }


                string strIdProduct = "";
                {
                    var lstString = new List<string>();
                    lstString.Add(strInputName);
                    var mApi = GetAllProductByListName(lstString);
                    if (mApi.TResultObj.IntTotalRecords > 0)
                    {
                        lstString = new List<string>();
                        BLLTools.GetListStringInColumnDataTable(ref lstString, mApi.TResultObj.TOneItem, Table_BangViThuoc.Col_MaViThuoc.NAME);
                        strIdProduct = lstString[0];
                    }
                }
                bool blnAddNewProduct = false;
                if (strIdProduct == "")
                {
                    var mApi = GetDTIdNewByInsertNameProduct(strInputName);

                    foreach (DataRow dRow in mApi.TResultObj.TOneItem.Rows)
                    {
                        strIdProduct = "" + dRow[Table_BangViThuoc.Col_MaViThuoc.NAME].ToString().Trim();
                    }

                    blnAddNewProduct = true;
                }

                var dicInput = new Dictionary<string, object>();
                dicInput["string.strIdProduct"] = strIdProduct;
                dicInput["decimal.decSoLuong"] = decSoLuong;
                dicInput["decimal.decDonGia"] = decDonGia;
                dicInput["decimal.decThanhTien"] = decDonGia * decSoLuong;

                dicInput["string.strIdOrder"] = ""+intIdOrder;

                {
                    var dicOutputTemp = new Dictionary<string, object>();
                    Exception exOutput = null;
                    DAL_Order.AddProductExistToOrderDetail(ref dicOutputTemp, ref exOutput, dicInput);
                    if (exOutput != null)
                    {
                        dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                        return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                            , exOutput.StackTrace);
                        //Log4Net.Error(exOutput.Message);
                        //Log4Net.Error(exOutput.StackTrace);
                        //ShowException(exOutput);
                        //return;
                    }

                    string strKeyError = "string";
                    if (dicOutput.ContainsKey(strKeyError))
                    {
                        dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                        return apiError.MHaveMessageWithDictionary(
                            "Thêm tên vị thuốc vào đơn hàng không thành công, bạn vui lòng thử lại!"
                            , dicOutput
                            , dicOutput[strKeyError] as string);
                        //QTMessageBox.ShowNotify(
                        //  "Thêm tên vị thuốc vào đơn hàng không thành công, bạn vui lòng thử lại!"
                        //  , dicOutput[strKeyError] as string);
                        //return;
                    }
                }

                string strMessage = "THÊM VÀO ĐƠN HÀNG THÀNH CÔNG!";
                if (blnAddNewProduct == false)
                {
                    strMessage += $"\n'{strInputName}' đã có trong danh sách vị thuốc của phần mềm.";
                }
                else
                {
                    strMessage += $"\n'{strInputName}' chưa có trong danh sách vị thuốc của phần mềm.";
                    strMessage += $"\nHệ thống đã tự động thêm tên vị thuốc này vào danh sách vị thuốc.";
                }

                return (new ApiSuccessResult<bool>()).MHaveMessage(strMessage,"");

            }
            catch (Exception et)
            {
                return (new ApiErrorResult<bool>()).MHaveMessage(et.Message, et.StackTrace);
            }
        }
        
        public ApiResult<bool> UpdateProductInOrder(UpdateProductInOrder_VMQuery mRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<bool>();
                var dicOutput = new Dictionary<string, object>();

                string strSpanKg = mRequest.StrQuantity;
                decimal decSoLuong = 0;
                BLLTools.GetDecimalFromString(ref decSoLuong, strSpanKg);
                if (decSoLuong <= 0)
                {
                    string strMess = "Số lượng phải lớn hơn 0, bạn vui lòng kiểm tra lại!";
                    dicOutput["strIdFocus"] = nameof(strSpanKg);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                string strSpanDonGia = mRequest.StrPrice;
                decimal decDonGia = 0;
                BLLTools.GetDecimalFromString(ref decDonGia, strSpanDonGia);
                if (decDonGia <= 1000)
                {
                    string strMess = "Đơn giá phải lớn hơn 1000, bạn vui lòng kiểm tra lại!";
                    dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                var dicInput = new Dictionary<string, object>();
                dicInput["string.strIdDetailOrder"] = ""+mRequest.IntIdDetailOrder;
                dicInput["decimal.decSoLuong"] = decSoLuong;
                dicInput["decimal.decDonGia"] = decDonGia;
                dicInput["decimal.decThanhTien"] = decDonGia * decSoLuong;

                {
                    //var dicOutput = new Dictionary<string, object>();
                    Exception exOutput = null;
                    //DALOrder.UpdateOrderDetail(ref dicOutput,ref exOutput,dicInput);
                    DAL_Order.UpdateOrderDetail(ref dicOutput, ref exOutput, dicInput);
                    if (exOutput != null)
                    {
                        dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                        return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                            , exOutput.StackTrace);
                    }

                    string strKeyError = "string";
                    if (dicOutput.ContainsKey(strKeyError))
                    {
                        dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                        return apiError.MHaveMessageWithDictionary(
                            "Cập nhật số lượng và đơn giá mới không thành công, bạn vui lòng thử lại!"
                            , dicOutput
                            , dicOutput[strKeyError] as string);
                    }
                }

                string strMessage = "THAO TÁC THÀNH CÔNG!";

                return (new ApiSuccessResult<bool>()).MHaveMessage(strMessage, "");

            }
            catch (Exception et)
            {
                return (new ApiErrorResult<bool>()).MHaveMessage(et.Message, et.StackTrace);
            }
        }

        public ApiResult<PagedResult<DataTable>> GetOrderPagingByDictionary(
            Dictionary<string, object> dicRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<PagedResult<DataTable>>();
                var dicOutput = new Dictionary<string, object>();

                DateTime dtimeStart = DateTime.ParseExact(dicRequest["strStartDate"].ToString()
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                DateTime dtimeEnd = DateTime.ParseExact(dicRequest["strEndDate"].ToString()
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                if (dtimeStart >= dtimeEnd)
                {
                    string strMess = "Thiết lập thời gian kết thúc phải lớn hơn thời gian bắt đầu, bạn vui lòng thao tác lại!";
                    //dicOutput["strIdFocus"] = nameof(strSpanKg);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                Exception exOutput = null;
                DataTable DT_AllIdOrder = null;
                DAL_Order.GetDTAllIdOrderByTime(ref DT_AllIdOrder, ref exOutput, dtimeStart, dtimeEnd);

                if (exOutput != null)
                {
                    //dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                    return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                        , exOutput.StackTrace);
                }

                int intPageIndex = Convert.ToInt32(dicRequest["intPageIndex"].ToString());
                int intPageSize = Convert.ToInt32(dicRequest["intPageSize"].ToString());
                var lstStringId = new List<string>();
                BLLTools.GetListStringIdInDataTable(ref lstStringId
                  , intPageIndex, intPageSize, DT_AllIdOrder, "MaDonHang");
                if (lstStringId.Count == 0)
                {
                    return apiError.MHaveMessage("Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                        , "(lstStringId.Count==0)");
                }

                DataTable DT_AllDetailOrderByListIdOrder = null;
                DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput, lstStringId);
                if (exOutput != null)
                {
                    return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
                }

                if (DT_AllDetailOrderByListIdOrder == null)
                {
                    return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                        , "(DT_AllDetailOrderByListIdOrder==null)");
                }

                DataTable dtByPage = null;
                _bllPlugin.CloneAndCopyRowDataTableByPage(ref dtByPage
                    , new PagingRequestBase() {IntPageIndex= intPageIndex
                    ,IntPageSize=intPageSize}
                , DT_AllIdOrder);

                var dtOutput = new DataTable();
                _bllPlugin.GetDataTableOrderPagingByPcView(ref dtOutput, dtByPage, DT_AllDetailOrderByListIdOrder);

                var mPagedResult = new PagedResult<DataTable>()
                {
                    IntTotalRecords = DT_AllIdOrder.Rows.Count,
                    IntPageIndex = intPageIndex,
                    IntPageSize = intPageSize,
                    TOneItem = dtOutput
                };
                return new ApiSuccessResult<PagedResult<DataTable>>(mPagedResult);
            }
            catch (Exception et)
            {
                return (new ApiErrorResult<PagedResult<DataTable>>()).MHaveMessage(et.Message, et.StackTrace);
            }
        }
        
        public ApiResult<bool> GetStatisticOrderByDictionary(
            Dictionary<string, object> dicRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<bool>();
                var dicOutput = new Dictionary<string, object>();

                DateTime dtimeStart = DateTime.ParseExact(dicRequest["strStartDate"].ToString()
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                DateTime dtimeEnd = DateTime.ParseExact(dicRequest["strEndDate"].ToString()
            , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
                if (dtimeStart > dtimeEnd)
                {
                    string strMess = "Thiết lập thời gian kết thúc phải lớn hơn thời gian bắt đầu, bạn vui lòng thao tác lại!";
                    //dicOutput["strIdFocus"] = nameof(strSpanKg);
                    return apiError.MHaveMessageWithDictionary(strMess, dicOutput, "");
                }

                Exception exOutput = null;
                DataTable DT_AllIdOrder = null;
                DAL_Order.GetDTAllIdOrderByTime(ref DT_AllIdOrder, ref exOutput, dtimeStart, dtimeEnd);

                if (exOutput != null)
                {
                    //dicOutput["strIdFocus"] = nameof(strSpanDonGia);
                    return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                        , exOutput.StackTrace);
                }

                int intPageIndex = Convert.ToInt32(dicRequest["intPageIndex"].ToString());
                int intPageSize = Convert.ToInt32(dicRequest["intPageSize"].ToString());
                var lstStringId = new List<string>();
                BLLTools.GetListStringIdInDataTable(ref lstStringId
                  , intPageIndex, intPageSize, DT_AllIdOrder, "MaDonHang");
                if (lstStringId.Count == 0)
                {
                    return apiError.MHaveMessage("Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
                        , "(lstStringId.Count==0)");
                }

                DataTable DT_AllDetailOrderByListIdOrder = null;
                DAL_Order.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder, ref exOutput, lstStringId);
                if (exOutput != null)
                {
                    return apiError.MHaveMessage(exOutput.Message, exOutput.StackTrace);
                }

                if (DT_AllDetailOrderByListIdOrder == null)
                {
                    return apiError.MHaveMessage("Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
                        , "(DT_AllDetailOrderByListIdOrder==null)");
                }

                dicOutput = new Dictionary<string, object>();
                dicOutput["DT_AllIdOrder"] = DT_AllIdOrder;
                dicOutput["DT_AllDetailOrderByListIdOrder"] = DT_AllDetailOrderByListIdOrder;
                return new ApiSuccessResult<bool>(true, dicOutput);

            }
            catch (Exception et)
            {
                return (new ApiErrorResult<bool>()).MHaveMessage(et.Message, et.StackTrace);
            }
        }
        
        public ApiResult<bool> AddOrder(Dictionary<string, object> dicRequest)
        {
            try
            {
                var apiError = new ApiErrorResult<bool>();

                var dicInput = new Dictionary<string, object>();
                Exception exOutput = null;
                var dicOutput = new Dictionary<string, object>();
                DAL_Order.AddNewOrder(ref dicOutput, ref exOutput, dicInput);

                if (exOutput != null)
                {
                    return apiError.MHaveMessageWithDictionary(exOutput.Message, dicOutput
                        , exOutput.StackTrace);
                }

                string strKeyError = "string";
                if (dicOutput.ContainsKey(strKeyError))
                {
                    return apiError.MHaveMessageWithDictionary("Thao tác không thành công, bạn vui lòng thử lại!", dicOutput
                        , dicOutput[strKeyError] as string);
                }

                return new ApiSuccessResult<bool>(true,dicOutput);
            }
            catch (Exception et)
            {
                return (new ApiErrorResult<bool>()).MHaveMessage(et.Message, et.StackTrace);
            }
        }

    }
}
