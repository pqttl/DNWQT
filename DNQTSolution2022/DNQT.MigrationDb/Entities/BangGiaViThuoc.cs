using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangGiaViThuoc
    {
        public long MaGiaThuoc { get; set; }
        public long MaViThuoc { get; set; }
        public long GiaViThuoc { get; set; }
        public string DonViGiaThuoc { get; set; }
        public string ThoiGianBatDauCoGiaNay { get; set; }
        public string ThoiGianKetThucGiaNay { get; set; }
        public string GhiChuGiaThuoc { get; set; }
    }
}
