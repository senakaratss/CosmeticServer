namespace CosmeticServer.API.Dtos.ContactMessageDtos
{
    public class CreateContactMessageDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
