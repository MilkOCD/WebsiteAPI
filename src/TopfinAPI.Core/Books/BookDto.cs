using Abp.Application.Services.Dto;

namespace TopfinAPI.Books
{
    public class BookDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
