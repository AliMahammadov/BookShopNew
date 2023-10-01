using BookShopDto.Dtos.AppUserDtos;
using FluentValidation;

namespace BookShopService.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad sahəsi tələb olunur.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad sahəsi tələb olunur.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adı sahəsi tələb olunur.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email sahəsi tələb olunur.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə sahəsi tələb olunur.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifrə təkrar sahəsi tələb olunur.");

            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifrələr uyğun gəlmir.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Düzgün email adress daxil edin.");
        }
    }
}
