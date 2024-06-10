namespace MikesMoves.Models
{
public class Reservation
    {
        public int UserId { get; set; }
        public int TrailerId { get; set; }
        public DateTime DateReserved { get; set; }
        public User User { get; set; }
        public Trailer Trailer { get; set; }
    }

}