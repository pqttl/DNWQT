using System;
using System.Collections.Generic;
using System.Text;

namespace DNQT.MigrationDb.Entities
{
    public class BangAccount
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long IsDeleted { get; set; }
        public string CreateTime { get; set; }
        public string ModifyTime { get; set; }
    }
}
