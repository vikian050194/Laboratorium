using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium.Models.ViewModels
{
    public class PacketViewModel
    {
        public PacketViewModel()
        {
            Result = new List<string>();
            Errors = new List<string>();
            Input = new List<string>();
        }

        [Display(Name = "Скрипт")]
        public string Script { get; set; }

        //[Required]
        [Display(Name = "Имя скрипта")]
        public string ScriptName { get; set; }
        public List<string> Result { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Input { get; set; }

        [Display(Name = "Показывать полный скрипт")]
        public bool ShowEntireScript { get; set; }
    }
}