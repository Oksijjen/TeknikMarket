using Core.CrossCuttingConcern.Crypto;
using Core.CrossCuttingConcern.MailOp;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TeknikMarket.Business.Abstract;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;
using TeknikMarket.Model.ViewModel.Areas.Admin;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IKullaniciBS _kullaniciBs;
        private readonly ISessionManager sessionManager;

        public UserController(IKullaniciBS kullaniciBs, ISessionManager _sessionManager)
        {
            _kullaniciBs = kullaniciBs;
            sessionManager = _sessionManager;
        }

        public IActionResult LogIn()
        {
            LogInVm model = new LogInVm();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult LogIn(LogInVm vm)
        {
            LogInVm model = new LogInVm();

            if (!ModelState.IsValid) //ModelState.IsValid prop u , Validasyonlardan verinin geçip geçmediği bilgisini bize verir . Bu sayede sunucuda gereksiz kod çalışmaz.
            {
                ViewBag.Mesaj = "İşlemler HATALI";

                return View(model);
            }



            Kullanici kullanici = _kullaniciBs.Get(x => x.Email == vm.Email && x.Sifre == vm.Sifre && x.Aktif == true, "KullanciRol", "KullaniciRol.Rol");
            if (kullanici != null)
            {
                //return RedirectToAction("Index","Home");

                return Redirect("/Admin/Home/Index");
            }
            ViewBag.Mesaj = "Giriş Başarısız";

            return View(model);
        }

        public IActionResult LogIn2()
        {
            LogInVm model = new LogInVm();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LogIn2(LogInVm vm)
        {
            LogInVm model = new LogInVm();

            if (!ModelState.IsValid)
            {
                ViewBag.Mesaj = "İşlemler Hatalı";
                return Json(new { result = false, Mesaj = "Validasyon Hatası Oldu" });
            }

            string sifre = CrytoManager.MD5Encrypt(CrytoManager.SHA1Encrytp(vm.Sifre));

            Kullanici kullanici = _kullaniciBs.Get(x => x.Email == vm.Email && x.Sifre == sifre && x.Aktif == true, "KullaniciRols", "KullaniciRols.Rol");
            if (kullanici != null)
            {

                //HttpContext.Session["asdasd"] = 15515;
                //HttpContext.Session.SetObject("AktifKullanici", kullanici);
                sessionManager.AktifKullanici = kullanici;

                return Json(new { result = true, Mesaj = "Giriş Başarılı" });
            }
            else
            {
                return Json(new { result = false, Mesaj = "Kullanıcı bulunamadı." });
            }
        }
        public IActionResult Logout()
        {
            sessionManager.AktifKullanici = null;

            return RedirectToAction("Login2", "User");
        }

        public IActionResult NonAuthentication()
        {

            return View();
        }

        public IActionResult ForgotPassword()
        {
            ForgotPasswordViewModel model = new ForgotPasswordViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mesaj = "İşlemler Hatalı";
                return Json(new { result = false, Mesaj = "Validasyon Hatası Oldu" });
            }

            Kullanici kullanici = _kullaniciBs.Get(x => x.Email == model.Email && x.Adi.ToLower() == model.Adi.ToLower() && x.Soyadi.ToUpper() == model.Soyadi.ToUpper());

            if (kullanici != null)
            {
                MailManager.Send(kullanici.Email, "Şifre Değiştirme", "Merhaba Sayin : " + kullanici.Adi + " " + kullanici.Soyadi + "<br> Şifrenizi Değiştirmek İçin Lütfen <a href='"+Keys.SITEADDRESS + "Admin/User/UpdatePassword?UniqueID=" + kullanici.UniqueId +"'>Tıklayınız</a>");



                return Json(new { result = true, Mesaj = "Şifre Değiştirme Linki Mail Adresinize Gönderildi. Lütfen Mailinizi Kontrol Ediniz." });
            }
            else
            {
                return Json(new { result = false, Mesaj = "Bilgileriniz Hatalı. Lütfen Yeniden Deneyin" });
            }
        }

        public IActionResult UpdatePassword(string UniqueID)
        {
            UpdatePasswordViewModel model = new UpdatePasswordViewModel();

            model.UniqueID = UniqueID;

            Kullanici kullanici = _kullaniciBs.Get(x=>x.UniqueId.ToString()==model.UniqueID);

            if (kullanici==null)
            {
                return RedirectToAction("TehlikeliIslem", "Home");
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdatePassword(UpdatePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mesaj = "İşlemler Hatalı";
                return Json(new { result = false, mesaj = "Validasyon Hatası" });
            }

            Kullanici kullanici = _kullaniciBs.Get(x => x.UniqueId.ToString()==model.UniqueID);

            if (kullanici != null && model.Sifre== model.SifreTekrar)
            {
                kullanici.UniqueId = Guid.NewGuid();
                kullanici.Sifre = CrytoManager.MD5Encrypt(CrytoManager.SHA1Encrytp(model.Sifre));
                kullanici.GuncellemeTarihi = DateTime.Now;

                _kullaniciBs.Update(kullanici);
                return Json(new { result = true, mesaj = "Şifreniz Başarıyla Değiştirildi. Giriş Yapabilirisiniz" });
            }
            else
            {
                return Json(new { result = true, mesaj = "Ip Adresiniz Kayıt Ediliyor. Lütfen Yetkisiz İşlem Yapmayınız." });
            }
        }


        public IActionResult MyAccount()
        {




            return View();
        }


    }
}
