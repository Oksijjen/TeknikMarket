using FluentValidation;
using TeknikMarket.Model.ViewModel.Areas.Admin;

namespace TeknikMarket.Business.ValidationRule.Areas.Admin
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordViewModel>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Lütfen Sifre Alanını Boş Bırakmayınız").NotNull().WithMessage("Şifre Alanı Zorunlu").MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz").MaximumLength(15).WithMessage("Lütfen En fazla 15 karakter girin").Equal(x => x.Sifre).WithMessage("Şifreler Eşleşmiyor");


            RuleFor(x => x.SifreTekrar).NotEmpty().WithMessage("Lütfen Sifre Alanını Boş Bırakmayınız").NotNull().WithMessage("Şifre Alanı Zorunlu").MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz").MaximumLength(15).WithMessage("Lütfen En fazla 15 karakter girin").Equal(x => x.Sifre).WithMessage("Şifreler Eşleşmiyor");

        }
    }
}
