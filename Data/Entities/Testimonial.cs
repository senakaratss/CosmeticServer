using CosmeticServer.API.Data.Entities.Common;

namespace CosmeticServer.API.Data.Entities
{
    public class Testimonial: BaseEntity
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Visibility { get; set; }
    }
}
