using System.ComponentModel.DataAnnotations;

namespace Laboratorium.Models.ViewModels
{
    public class AccountsListItem
    {
        public string Id { get; set; }

        [Display(Name = @"Имя")]
        public string FirstName { get; set; }

        [Display(Name = @"Фамилия")]
        public string LastName { get; set; }

        [Display(Name = @"Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = @"Роль")]
        public string Role { get; set; }
    }

    public class SetAccountPassword
    {
        public string Id { get; set; }

        [Display(Name = @"Имя")]
        public string FirstName { get; set; }

        [Display(Name = @"Фамилия")]
        public string LastName { get; set; }

        [Display(Name = @"Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = @"{0} должен быть не меньше {2} символов.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Повторите пароль")]
        [Compare("Password", ErrorMessage = @"Пароль и повторный пароль не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}