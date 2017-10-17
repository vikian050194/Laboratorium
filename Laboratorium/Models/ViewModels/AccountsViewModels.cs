using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Laboratorium.Models.DataModels;

namespace Laboratorium.Models.ViewModels
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
    }

    public class AccountsFilteringViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Role Role { get; set; }
    }

    public class AccountsInViewModel
    {
        public AccountsInViewModel()
        {
            Filtering = new AccountsFilteringViewModel();
            Sorting = new Sorting();
        }

        public AccountsFilteringViewModel Filtering { get; set; }
        public Sorting Sorting { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFilterChanged { get; set; }
    }

    public class AccountsOutViewModel
    {
        public AccountsOutViewModel()
        {
            Paging = new Paging();
        }

        public List<AccountViewModel> Rows { get; set; }
        public Paging Paging { get; set; }
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