using System.Collections.Generic;

namespace DNQT.ViewModels.Admin.Order
{
    public class OrderPagingMobile_VMDataTable
    {

        public OrderPagingMobile_VMDataTable()
        {
            MDisplay.LstStringNameColumn = new List<string>() {
            COL00.STR,
            COL01.STR,
            COL02.STR,
            COL03.STR
        };
            MDisplay.LstStringColumnRight = new List<string>(){
            COL01.STR
        };
            MDisplay.LstStringColumnCenter = new List<string>(){
            COL00.STR,
            COL02.STR
        };
            MDisplay.LstStringColumnCollapse = new List<string>(){
            COL03.STR
        };

            MDisplay.StrNameColumnIdMain = COL03.STR;
            MDisplay.StrNoteTable = $"* {COL01.STR} : {COL01.STR_LONG}";


            MDisplay.LstStringColumnAddLink = new List<string>(){
            COL01.STR
        };
            
            MDisplay.LstStringHtmlAddToLink = new List<string>(){
            "href='#'"
        };

        }

        public class COL00
        {
            public const string STR = "(STT)<br>Thời gian<br>viết";
        }
        public class COL01
        {
            public const string STR = "Cột 2";
            public const string STR_LONG = "Tổng số vị thuốc - Tổng khối lượng - Tổng giá trị";
        }
        public class COL02
        {
            public const string STR = "Tên khách hàng";
        }
        public class COL03
        {
            public const string STR = "Mã dữ liệu";
        }

        public DisplayColumn_VMDataTable MDisplay { get; set; } = new DisplayColumn_VMDataTable();

    }
}
