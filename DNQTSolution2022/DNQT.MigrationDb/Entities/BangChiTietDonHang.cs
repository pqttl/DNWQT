﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangChiTietDonHang
    {
        public long MaChiTietDonHang { get; set; }
        public long MaDonHang { get; set; }
        public long MaGiaThuoc { get; set; }
        public double SoLuongViThuoc { get; set; }
        public long ThanhTienTamThoi { get; set; }
    }
}
