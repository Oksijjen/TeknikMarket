using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Kullanici : AudiTableEntity, IBaseDomain
    {
        public Kullanici()
        {
            Firmas = new HashSet<Firma>();
            KullaniciRols = new HashSet<KullaniciRol>();
            Siparis = new HashSet<Sipari>();
        }

        public string? Email { get; set; }
        public string? Sifre { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public int? KullaniciTipi { get; set; }
        public int? İlId { get; set; }
        public Guid? UniqueId { get; set; }

        public virtual Il? İl { get; set; }
        public virtual Sehir? İlNavigation { get; set; }
        public virtual ICollection<Firma> Firmas { get; set; }
        public virtual ICollection<KullaniciRol> KullaniciRols { get; set; }
        public virtual ICollection<Sipari> Siparis { get; set; }
    }
}
