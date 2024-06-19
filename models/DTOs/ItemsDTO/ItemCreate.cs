using MikesMoves.Models.DTOs;

namespace MikesMoves.Models
{
    public class ItemCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public int UserProfileId { get; set; }
    }

}