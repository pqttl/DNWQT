﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class TblJsonPrintOrder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
        public string Description { get; set; }
        public long MaDonHang { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public long Status { get; set; }
    }
}
