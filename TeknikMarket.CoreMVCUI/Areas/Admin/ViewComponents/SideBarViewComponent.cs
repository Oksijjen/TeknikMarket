using Microsoft.AspNetCore.Mvc;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Kullanici kullanici = HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);
            string aktifkullanici = "";

            if (kullanici != null)
            {
                aktifkullanici = kullanici.Adi + " " + kullanici.Soyadi;
            }

            ViewBag.AktifKullanici = aktifkullanici;


            return View();
        }
    }
}
