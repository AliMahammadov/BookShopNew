using Microsoft.AspNetCore.Identity;

namespace BookShopEntity.Entities
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Şifrə ən azı {length} simvol olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = $"Zəhmət olmasa ən az 1 böyük hərf daxil edin."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = $"Zəhmət olmasa ən az 1 kiçik hərf daxil edin."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = $"Zəhmət olmasa ən az 1 rəqəm daxil edin."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = $"Zəhmət olmasa ən az 1 simvol daxil edin."
            };
        }

        public override IdentityError InvalidUserName(string? userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = $"'{userName}' istifadəçi adı qüvvədə deyil, yalnız hərf və ya rəqəm ola bilər."
            };
        }

    }
}
