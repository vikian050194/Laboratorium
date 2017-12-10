using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium.Models.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = @"Электронная почта")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = @"Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = @"Запомнить этот браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = @"Электронная почта")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = @"Электронная почта")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [Display(Name = @"Запомнить меня?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = @"{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = @"Имя")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = @"{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = @"Фамилия")]
        public string LastName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = @"{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = @"Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = @"Электронная почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = @"{0} должен быть не менее {2} и не более {1} символов.", MinimumLength = 4)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [Display(Name = @"Повторите пароль")]
        [Compare("Password", ErrorMessage = @"Пароль и повторный пароль не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = @"Электронная почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = @"{0} должен быть не менее {2} и не более {1} символов.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = @"Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Повторите пароль")]
        [Compare("Password", ErrorMessage = @"Пароль и повторный пароль не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = @"Электронная почта")]
        public string Email { get; set; }
    }
}
