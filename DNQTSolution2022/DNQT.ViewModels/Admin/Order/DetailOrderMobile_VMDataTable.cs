using System.Collections.Generic;

namespace DNQT.ViewModels.Admin.Order
{
    public class DetailOrderMobile_VMDataTable
    {

        public DetailOrderMobile_VMDataTable()
        {
            MDisplay.LstStringNameColumn = new List<string>() {
            COL00.STR,
            COL03.STR,
            COL01.STR,
            COL02.STR
        };
            MDisplay.LstStringColumnRight = new List<string>(){
            COL01.STR,
            COL03.STR
        };
            MDisplay.LstStringColumnCenter = new List<string>(){
            COL00.STR,
            COL02.STR
        };
            MDisplay.LstStringColumnCollapse = new List<string>(){
            COL02.STR
        };

            MDisplay.StrNameColumnIdMain = COL02.STR;
            //MDisplay.StrNoteTable = $"* {COL01.STR} : {COL01.STR_LONG}";


            MDisplay.LstStringColumnAddLink = new List<string>(){
            //COL01.STR
        };
            
            MDisplay.LstStringHtmlAddToLink = new List<string>(){
            "href='#'"
        };

        }

        public class COL00
        {
            public const string STR = "STT";
        }

        public class COL03
        {
            public const string STR = "Tên vị thuốc<br>Số lượng";
        }

        public class COL01
        {
            public const string STR = "Đơn giá<br>Thành tiền";
            //public const string STR_LONG = "Số lượng - Đơn giá - Thành tiền";
        }
        public class COL02
        {
            public const string STR = "Id detail order";
        }
        
        public DisplayColumn_VMDataTable MDisplay { get; set; } = new DisplayColumn_VMDataTable();

    }
}
