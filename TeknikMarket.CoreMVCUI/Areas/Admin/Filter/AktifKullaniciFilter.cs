using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Filter
{
    public class AktifKullaniciFilter:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //NOT: BURASI bu filtrenin uygulandığı action method çalıştırılmadan önce çalışacak kodların yazılacağı yerdir.

            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);

            if (kullanici==null)
            {
                context.Result = new RedirectResult("/Admin/User/LogIn2");
            }

            base.OnActionExecuting(context);
        }


        // aktifkullanicifilter üzerine bunu yazdığın action ikisinin arasında çalışıyor.

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //NOT : BURASI bu filtrein uygulandığı action method çalıştırıldıktan sonra çalışacak kodların yazılacağı yerdir.
            base.OnActionExecuted(context);
        }
    }
}
