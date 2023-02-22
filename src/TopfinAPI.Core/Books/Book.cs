using Abp.Domain.Entities;

namespace TopfinAPI.Books
{
    public class Book : Entity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
