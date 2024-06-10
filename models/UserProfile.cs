using Microsoft.AspNetCore.Identity;

namespace MikesMoves.Models

{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser identityUser { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
    }

}