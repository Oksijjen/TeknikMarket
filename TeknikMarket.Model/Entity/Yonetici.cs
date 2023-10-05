using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Yonetici : AudiTableEntity, IBaseDomain
    {
        public Yonetici()
        {
            YoneticiRols = new HashSet<YoneticiRol>();
        }

        public string? Email { get; set; }
        public byte[]? Sifre { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? Resim { get; set; }
        public Guid? UniqueId { get; set; }

        public virtual ICollection<YoneticiRol> YoneticiRols { get; set; }
    }
}
