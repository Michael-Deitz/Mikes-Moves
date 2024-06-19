using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MikesMoves.Models.DTOs;
public class UserProfileUpdateDTO
{
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [NotMapped]
    public string UserName { get; set; }

    [NotMapped]
    public string Email { get; set; }
    [NotMapped]
    public string PhoneNumber { get; set; }
    public string ImageLocation { get; set; }
}