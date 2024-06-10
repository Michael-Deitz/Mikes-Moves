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
    }

}