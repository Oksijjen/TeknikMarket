﻿using Microsoft.AspNetCore.Mvc;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class HomeController : Controller
    {
        [AktifKullaniciFilter]
        public IActionResult Index()
        {
            Kullanici kullanici = HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);

            if (kullanici==null)
            {
                return RedirectToAction("LogIn2", "User");
            }


            return View();
        }
        public IActionResult TehlikeliIslem()
        {



            return View();
        }
    }
}
