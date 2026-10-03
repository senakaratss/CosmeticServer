namespace CosmeticServer.API.Dtos.TestimonialsDtos
{
    public class UpdateTestimonialDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Visibility { get; set; }

    }
}
