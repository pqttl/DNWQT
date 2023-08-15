using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangKhachHang
    {
        public long IdBangKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public long TienNoHienTai { get; set; }
    }
}
