namespace Laboratorium.Models.DataModels
{
    public class Script
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public bool IsPrivate { get; set; }

        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}