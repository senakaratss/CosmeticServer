using CosmeticServer.API.Data.Entities.Common;

namespace CosmeticServer.API.Data.Entities
{
    public class ContactMessage:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
