using System.ComponentModel.DataAnnotations;

namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class CreateAccountModel
    {
        [Required(ErrorMessage = "Введіть ім'я")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Довжина імені повинна бути від 2 до 20 символів")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введіть прізвище")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Довжина прізвища повинна бути від 2 до 20 символів")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть email")]
        [EmailAddress(ErrorMessage = "Введіть коректний email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Довжина пароля повинна бути від 6 символів")]
        public string Password { get; set; }
    }
}
