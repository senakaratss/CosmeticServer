using CosmeticServer.API.Data.Entities.Common;

namespace CosmeticServer.API.Data.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
