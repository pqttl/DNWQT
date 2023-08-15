using System.Collections.Generic;

namespace DNQT.ViewModels.Admin.Order
{
    public class DetailOrder_VMDataTable
    {

        public DetailOrder_VMDataTable()
        {
            MDisplay.LstStringNameColumn = new List<string>() {
            COL00.STR,
            COL01.STR,
            COL02.STR,
            COL03.STR,
            COL04.STR,
            COL05.STR,
            COL06.STR
        };
            MDisplay.LstStringColumnRight = new List<string>(){
            COL02.STR,
            COL04.STR,
            COL05.STR
        };
            MDisplay.LstStringColumnCenter = new List<string>(){
            COL00.STR
        };
            MDisplay.LstStringColumnCollapse = new List<string>(){
            COL06.STR
        };

            MDisplay.StrNameColumnIdMain = COL06.STR;
        }

        public class COL00
        {
            public const string STR = "STT";
        }
        public class COL01
        {
            public const string STR = "Tên vị thuốc";
        }
        public class COL02
        {
            public const string STR = "Số lượng";
        }
        public class COL03
        {
            public const string STR = "Đơn vị";
        }
        public class COL04
        {
            public const string STR = "Đơn giá";
        }
        public class COL05
        {
            public const string STR = "Thành tiền";
        }
        public class COL06
        {
            public const string STR = "Id detail order";
        }

        public DisplayColumn_VMDataTable MDisplay { get; set; } = new DisplayColumn_VMDataTable();

    }
}
