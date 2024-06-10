namespace MikesMoves.Models;
public class Trailer
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public decimal BasePrice { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }