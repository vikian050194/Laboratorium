namespace Laboratorium.Core.Containers
{
    public class PacketItem
    {
        public int Id { get; set; }
        public string Script { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public bool IsReusable { get; set; }
    }
}