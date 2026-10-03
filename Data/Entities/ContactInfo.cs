using CosmeticServer.API.Data.Entities.Common;

namespace CosmeticServer.API.Data.Entities
{
    public class ContactInfo:BaseEntity
    {
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}
