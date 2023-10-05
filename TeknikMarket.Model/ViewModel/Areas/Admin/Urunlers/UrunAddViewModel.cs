using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.Model.ViewModel.Areas.Admin.Urunlers
{
    public  class UrunAddViewModel
    {
        //URUN EKLEME SAYFASI

        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int? KategoriId { get; set; }
        public List<SelectListItem> KategoriListesi { get; set; }

        public List<UrunFiyat> UrunFiyatlari { get; set; }
    }
}
