namespace MikesMoves.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int TrailerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Trailer Trailer { get; set; }
        public string ImageUrl { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public int UserProfileId { get; set; }
    }

}