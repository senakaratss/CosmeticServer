using CosmeticServer.API.Dtos.CategoryDtos;

namespace CosmeticServer.API.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }


    }
}
