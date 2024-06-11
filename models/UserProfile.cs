using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MikesMoves.Models

{
    public class UserProfile
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        public string ImageLocation { get; set; }
        [NotMapped]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public byte[]? ImageBlob { get; set; }
        public string FullName
        {
            get
            {
                return$"{FirstName} {LastName}";
            }
        }
    }

}