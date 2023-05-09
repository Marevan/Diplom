using System.ComponentModel.DataAnnotations;

namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class LoginAccountModel
    {
        [Required(ErrorMessage = "Введіть email")]
        [EmailAddress(ErrorMessage = "Така пошта не зареєстрована.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Невірний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}