﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangGiaHan
    {
        public long Id { get; set; }
        public long IdAccount { get; set; }
        public string StartTimeUse { get; set; }
        public string EndTimeUse { get; set; }
        public string CreateTime { get; set; }
        public string JsonKeyGiaHanGiaiMa { get; set; }
        public string KeyGiaHanMaHoa { get; set; }
    }
}
