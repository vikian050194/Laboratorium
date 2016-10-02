using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
    public class Item
    {
        public Item()
        {
            Result = new List<string>();
        }
        public string Query { get; set; }
        public List<string> Result { get; set; }
    }
}