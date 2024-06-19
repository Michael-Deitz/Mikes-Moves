namespace MikesMoves.Models
{
public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrailerId { get; set; }
        public DateTime DateReserved { get; set; }
        public UserProfile UserProfile { get; set; }
        public Trailer Trailer { get; set; }
    }

}