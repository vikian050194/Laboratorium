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

        public string Script { get; set; }

        public List<string> Result { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Input { get; set; }

        [Display(Name = "Показывать полный скрипт")]
        public bool ShowEntireScript { get; set; }
    }
}