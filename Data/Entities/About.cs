using CosmeticServer.API.Data.Entities.Common;

namespace CosmeticServer.API.Data.Entities
{
    public class About: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
    }
}
