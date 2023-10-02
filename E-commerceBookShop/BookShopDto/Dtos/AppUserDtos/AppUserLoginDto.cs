using System.ComponentModel.DataAnnotations;

namespace BookShopDto.Dtos.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
