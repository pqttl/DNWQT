using System.Collections.Generic;

namespace DNQT.ViewModels.Admin.Order
{
    public class OrderPaging_VMDataTable
    {

        public OrderPaging_VMDataTable()
        {

        }

        public class COL00
        {
            public const string STR = "STT";
        }
        public class COL01
        {
            public const string STR = "Mã dữ liệu";
        }
        public class COL02
        {
            public const string STR = "Thời gian viết";
        }
        public class COL03
        {
            public const string STR = "Tổng số vị thuốc";
        }
        public class COL04
        {
            public const string STR = "Tổng khối lượng";
        }
        public class COL05
        {
            public const string STR = "Tổng giá trị";
        }
        public class COL06
        {
            public const string STR = "Tên khách hàng";
        }

        public List<string> LstStringNameColumn { get; set; } = new List<string>() {
            COL00.STR,
            COL01.STR,
            COL02.STR,
            COL03.STR,
            COL04.STR,
            COL05.STR,
            COL06.STR
        };

        public List<string> LstStringColumnRight { get; set; } = new List<string>() {
            COL03.STR,
            COL04.STR,
            COL05.STR
        };

        public List<string> LstStringColumnCenter { get; set; } = new List<string>() {
            COL00.STR,
            COL01.STR,
            COL02.STR,
            COL06.STR
        };

    }
}
