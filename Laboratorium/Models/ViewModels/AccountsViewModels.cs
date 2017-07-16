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
}