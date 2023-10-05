using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikMarket.Model.ViewModel.Areas.Admin
{
    public class LogInVm
    {
        //--DataAnnotations işlemleri yapıyoruz.
        //[EmailAddress(ErrorMessage ="Lütfen Geçerli Email Giriniz.")]
        //[Required(ErrorMessage ="Lütfen Email Giriniz.")]
        public string Email { get; set; }

        //[Required(ErrorMessage ="Lütfen Şifre Giriniz.")]
        //[MinLength(8,ErrorMessage ="Lütfen 8 karakterden fazla giriniz.")]
        //[MaxLength(16,ErrorMessage ="Lütfen 16 karakterden fazla girmeyiniz.")]
        //[StringLength(16,ErrorMessage = "Lütfen 16 karakterden fazla girmeyiniz.")]
        public string Sifre { get; set; }
        public bool BeniHatırla { get; set; }
    }
}
