namespace MikesMoves.Models
{
public class ReservationsByTrailerIdDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrailerId { get; set; }
        public DateTime DateReserved { get; set; }

       
    }

}