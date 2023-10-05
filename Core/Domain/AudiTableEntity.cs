﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class AudiTableEntity
    {
        public int? Id { get; set; }
        public Nullable<int> Olusturan { get; set; }
        public Nullable<DateTime> OlusturmaTarihi { get; set; }
        public Nullable<int> Guncelleyen { get; set; }
        public Nullable<DateTime> GuncellemeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
