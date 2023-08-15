using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangViThuoc
    {
        public long MaViThuoc { get; set; }
        public string TenViThuoc { get; set; }
        public string GhiChuViThuoc { get; set; }
        public long IsDeleted { get; set; }
    }
}
