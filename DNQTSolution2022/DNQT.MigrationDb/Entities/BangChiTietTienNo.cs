﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangChiTietTienNo
    {
        public long IdBangChiTietTienNo { get; set; }
        public long IdBangKhachHang { get; set; }
        public string ThoiGianThayDoiTienNo { get; set; }
        public long TienNoTruocKhiSua { get; set; }
        public string LyDoSuaTienNo { get; set; }
        public long SoTienSuaCuThe { get; set; }
        public long TienNoSauKhiSua { get; set; }
    }
}
