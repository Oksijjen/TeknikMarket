using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.ViewModel.Areas.Admin;

namespace TeknikMarket.Business.ValidationRule.Areas.Admin
{
    public class LogInVmValidator:AbstractValidator<LogInVm>
    {
        public LogInVmValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email Alanını Boş Bırakmayınız.").NotNull().WithMessage("Email Alanaı Zorunlu").EmailAddress().WithMessage("Lütfen Email Formatında Girin").Equal(x=>x.Email).WithMessage("Email Eşleşmiyor");

            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Lütfen Sifre Alanını Boş Bırakmayınız").NotNull().WithMessage("Şifre Alanı Zorunlu").MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz").MaximumLength(15).WithMessage("Lütfen En fazla 15 karakter girin").Equal(x=>x.Sifre).WithMessage("Şifreler Eşleşmiyor");
        }
    }
}
