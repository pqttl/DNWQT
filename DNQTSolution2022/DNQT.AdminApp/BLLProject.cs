using DNQT.ToolCommon;
using DNQT.ToolCommon.ListTableDatabase;
using DNQT.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace DNQT.AdminApp
{
    public class BLLProject
    {
        internal void ToLowerListString(ref List<string> lstStringNameColumn)
        {
            for (int i = 0; i < lstStringNameColumn.Count; i++)
            {
                lstStringNameColumn[i] = lstStringNameColumn[i].ToLower();
            }
        }

        internal void ChangeColumnNameInDataTable(ref DataTable dtInput)
        {
            foreach (DataColumn dc in dtInput.Columns)
            {
                string strColumnName = dc.ColumnName;
                if (strColumnName.Length > 0)
                {
                    strColumnName = strColumnName[0].ToString().ToUpper() + strColumnName.Substring(1);
                }
                if (strColumnName.ToLower()=="stt")
                {
                    strColumnName = "STT";
                }
                dc.ColumnName = strColumnName;
               }
        }
        
        internal void ChangeColumnNameInDataTable(ref ApiResult<PagedResult<DataTable>> mApi)
        {
            foreach (DataColumn dc in mApi.TResultObj.TOneItem.Columns)
            {
                string strColumnName = dc.ColumnName;
                if (strColumnName.Length > 0)
                {
                    strColumnName = strColumnName[0].ToString().ToUpper() + strColumnName.Substring(1);
                }
                if (strColumnName.ToLower()=="stt")
                {
                    strColumnName = "STT";
                }
                dc.ColumnName = strColumnName;
               }
        }

        internal void GetStringListNameQuantityFromDatatable(ref string strListNameProduct
            ,ref string strListQuantity, DataTable dtInput)
        {
            foreach (DataRow dRow in dtInput.Rows)
            {
                {
                    //string strTemp = "Định dạng Float False";
                    string strTemp = "";
                    string strValueCell = dRow["QuantityCurrent"].ToString();
                    if (strValueCell != "")
                    {
                        float objTemp = 0;
                        try
                        {
                            objTemp = Convert.ToSingle(strValueCell);
                            //objTemp=Convert.ToSingle(dRow["QuantityCurrent"]);
                            //strTemp=string.Format("{0:N3}",objTemp);
                            strTemp = string.Format("{0:0.###}", objTemp);
                        }
                        catch (Exception e)
                        {
                            string str = e.Message;
                        }
                        if (strTemp != "")
                        {
                            strTemp = $"    ------> Có {strTemp} Kg";
                        }
                    }

                    if (strListQuantity == "")
                    {
                        strListQuantity += $"\"{strTemp}\"";
                    } else
                    {
                        strListQuantity += $",\"{strTemp}\"";
                    }


                }

                string item = dRow[Table_BangViThuoc.Col_TenViThuoc.NAME].ToString();
                if (strListNameProduct=="")
                {
                    strListNameProduct += $"\"{item}\"";
                }
                else
                {
                    strListNameProduct += $",\"{item}\"";
                }

            }
        }

        internal void GetScriptCodeJsOnly(ref string strJs, string strJsChuaChuan)
        {

            string strStart = "<script";
            string strEnd = "</script>";

            int intMin = -1;
            var lstIntIndexStart = new List<int>();
            for (int intIndexChar = 0; intIndexChar < strJsChuaChuan.Length; intIndexChar++)
            {
                if (lstIntIndexStart.Count > 0)
                {
                    intMin = lstIntIndexStart[lstIntIndexStart.Count - 1];
                }

                if (intIndexChar <= intMin)
                {
                    continue;
                }

                int intIndexOf = strJsChuaChuan.IndexOf(strStart, intIndexChar);
                if (intIndexOf < 0)
                {
                    break;
                }
                lstIntIndexStart.Add(intIndexOf);
            }

            intMin = -1;
            var lstIntIndexEnd = new List<int>();
            for (int intIndexChar = 0; intIndexChar < strJsChuaChuan.Length; intIndexChar++)
            {
                if (lstIntIndexEnd.Count > 0)
                {
                    intMin = lstIntIndexEnd[lstIntIndexEnd.Count - 1];
                }

                if (intIndexChar <= intMin)
                {
                    continue;
                }

                int intIndexOf = strJsChuaChuan.IndexOf(strEnd, intIndexChar);
                if (intIndexOf < 0)
                {
                    break;
                }
                lstIntIndexEnd.Add(intIndexOf);
            }


            if (lstIntIndexStart.Count > 1 && lstIntIndexEnd.Count > 1)
            {
                if (lstIntIndexStart[1] < lstIntIndexEnd[0])
                {
                    string strStartFull = "<script type=\"text/javascript\">";

                    int intStart = lstIntIndexStart[1] + strStartFull.Length;
                    int intLength = lstIntIndexEnd[lstIntIndexEnd.Count - 2] - intStart;
                    strJs = strJsChuaChuan.Substring(intStart, intLength);
                    return;
                }
            }
            
            if (lstIntIndexStart.Count == 1 && lstIntIndexEnd.Count == 1)
            {
                if (lstIntIndexStart[0] < lstIntIndexEnd[0])
                {
                    string strStartFull = "<script type=\"text/javascript\">";

                    int intStart = lstIntIndexStart[0] + strStartFull.Length;
                    int intLength = lstIntIndexEnd[0] - intStart;
                    strJs = strJsChuaChuan.Substring(intStart, intLength);
                    return;
                }
            }

        }

        internal void GetListTupleTimeQuantityOrderFromDatatable(
            ref List<Tuple<string,string, int,int,int,DateTime>> lstTupleTimeLongShortQuantityAllSangChieuOrder, string[] arrayStrStartEndDate
            , DataTable dtInput)
        {
            int intIndexIncrease = -1;
            DateTime dtimeStart = DateTime.ParseExact(arrayStrStartEndDate[++intIndexIncrease]
        , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
            DateTime dtimeEnd = DateTime.ParseExact(arrayStrStartEndDate[++intIndexIncrease]
        , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);

            double doubleDays = (dtimeEnd - dtimeStart).TotalDays;
            if (doubleDays<0)
            {
                return;
            }

            //var culture = new System.Globalization.CultureInfo("vi-VN");
            //var day = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);

            var dateTimeFormats = new System.Globalization.CultureInfo("vi-VN").DateTimeFormat;
            var lstTupleTime = new List<Tuple<string, string,string,DateTime>>();
            lstTupleTime.Add(new Tuple<string, string, string, DateTime>(
                dtimeStart.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR)
                , dtimeStart.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR.Substring(0,5))
                , dtimeStart.ToString("ddd", dateTimeFormats)
                , dtimeStart));
            for (int i = 0; i < doubleDays; i++)
            {
                var dtimeTemp = dtimeStart.AddDays(i + 1);
                lstTupleTime.Add(new Tuple<string, string, string, DateTime>(
                    dtimeTemp.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR)
                    , dtimeTemp.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR.Substring(0, 5))
                    , dtimeTemp.ToString("ddd", dateTimeFormats)
                    , dtimeTemp));
            }

            //bool blnTrungYear = dtimeEnd.Year== dtimeStart.Year;
            var dtTemp = dtInput.Copy();
            foreach (var item in lstTupleTime)
            {
                int intSumCaNgay = 0;
                int intSum0hTo12h = 0;
                int intSum12hTo24h = 0;
                int intSumRow = dtTemp.Rows.Count;
                for (int i = intSumRow - 1; i >= 0; i--)
                {
                    var dRow = dtTemp.Rows[i];
                    var objTemp = Convert.ToDateTime(dRow[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
                    string strValueCell = objTemp.ToString(QTFormat.STR_DATE_DD_MM_YYYY.STR);
                    if (strValueCell== item.Item1)
                    {
                        intSumCaNgay++;
                        if (objTemp.Hour < 12)
                        {
                            intSum0hTo12h++;
                        }
                        else
                        {
                            intSum12hTo24h++;
                        }

                        dtTemp.Rows.Remove(dRow);
                    }
                }

                lstTupleTimeLongShortQuantityAllSangChieuOrder.Add(
                    new Tuple<string, string, int, int, int, DateTime>(item.Item1
                    //, "" + $"({item.Item3}) " + item.Item2
                    , "" + item.Item2
                    , intSumCaNgay, intSum0hTo12h, intSum12hTo24h, item.Item4));

                //if (blnTrungYear == true)
                //{
                //    lstTupleTimeLongShortQuantityAllSangChieuOrder.Add(
                //        new Tuple<string, string, int, int, int>(item.Item1
                //        //, "" + $"({item.Item3}) " + item.Item2
                //        , "" + item.Item2
                //        , intSumCaNgay, intSum0hTo12h, intSum12hTo24h));
                //    continue;
                //}
                //lstTupleTimeLongShortQuantityAllSangChieuOrder.Add(
                //    new Tuple<string, string, int, int, int>(item.Item1
                //    //, "" + $"({item.Item3}) " + item.Item1
                //    , "" + item.Item1
                //    , intSumCaNgay, intSum0hTo12h, intSum12hTo24h));
            }
        }

        internal void GetListTupleIdNameQuantityFromDatatable(
            ref List<Tuple<string, string, int>> lstTupleIdNameQuantity
            , string[] arrayStrStartEndDate, DataTable dtInput)
        {
            int intIndexIncrease = -1;
            DateTime dtimeStart = DateTime.ParseExact(arrayStrStartEndDate[++intIndexIncrease]
        , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);
            DateTime dtimeEnd = DateTime.ParseExact(arrayStrStartEndDate[++intIndexIncrease]
        , QTFormat.STR_DATE_DD_MM_YYYY.STR, null);

            double doubleDays = (dtimeEnd - dtimeStart).TotalDays;
            if (doubleDays < 0)
            {
                return;
            }

            foreach (DataRow dRow in dtInput.Rows)
            {
                var objTemp = Convert.ToDateTime(
                    dRow[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
                if (objTemp< dtimeStart|| objTemp > dtimeEnd)
                {
                    continue;
                }

                string strId = dRow[Table_BangKhachHang.Col_IdBangKhachHang.NAME].ToString().Trim();
                string strName = dRow[Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();
                bool blnTonTai = false;
                for (int i = 0; i < lstTupleIdNameQuantity.Count; i++)
                {
                    var item = lstTupleIdNameQuantity[i];
                    if (item.Item1== strId)
                    {
                        int intQuantityCurrent = item.Item3;
                        lstTupleIdNameQuantity[i] = new Tuple<string, string, int>(
                            strId, strName, intQuantityCurrent+1);
                        blnTonTai = true;
                        break;
                    }
                }

                if (blnTonTai == false)
                {
                    lstTupleIdNameQuantity.Add(new Tuple<string, string, int>(strId, strName, 1));
                }
            }
        }

        internal void GetStringListFromListTupleByCustomer(ref string strListName
            , ref string strListQuantityAll, ref string strListColor
            , List<Tuple<string, string, int,string>> lstTupleMinToMaxTongLoai)
        {
            foreach (var item in lstTupleMinToMaxTongLoai)
            {
                if (strListQuantityAll == "")
                {
                    strListName += $"\"{item.Item2}\"";
                    strListQuantityAll += $"{item.Item3}";
                    strListColor += $"\"{item.Item4}\"";
                    continue;
                }

                strListName += $",\"{item.Item2}\"";
                strListQuantityAll += $",{item.Item3}";
                strListColor += $",\"{item.Item4}\"";

            }
        }
    }
}
