namespace CosmeticServer.API.Dtos.ContactMessageDtos
{
    public class UpdateContactMessageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
