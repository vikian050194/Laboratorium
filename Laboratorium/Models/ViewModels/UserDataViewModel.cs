using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Laboratorium.Models.ViewModels
{
    public class UserDataViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = @"{0} должно быть не меньше {2} символов.", MinimumLength = 2)]
        [Display(Name = @"Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = @"{0} должна быть не меньше {2} символов.", MinimumLength = 2)]
        [Display(Name = @"Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = @"{0} должно быть не меньше {2} символов.", MinimumLength = 2)]
        [Display(Name = @"Отчество")]
        public string Patronymic { get; set; }

        public string GetName()
        {
            var result = new StringBuilder();

            result.Append(LastName);
            result.Append(" ");
            result.Append(FirstName[0]);
            result.Append(".");
            result.Append(Patronymic[0]);
            result.Append(".");

            return result.ToString();
        }
    }
}