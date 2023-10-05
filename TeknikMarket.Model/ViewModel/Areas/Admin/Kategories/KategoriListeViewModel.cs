using Microsoft.AspNetCore.Mvc.Rendering;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.Model.ViewModel.Areas.Admin.Kategories
{
    public class KategoriListeViewModel
    {
        //Kategori Listeleme İşlemleri
        public List<Kategori> KategoriListesi { get; set; }

        //Kategori Ekleme İşlemleri

        public List<SelectListItem> KategoriSelectList { get; set; }

        public int Id { get; set; }
        public string? KategoriAdi { get; set; }
        public int? UstKategoriId { get; set; }
        public string? KategoriAdiGorunumu { get; set; }
        public int? Sira { get; set; }
        public bool Aktif { get; set; }
    }
}
