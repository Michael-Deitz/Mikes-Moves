using Microsoft.AspNetCore.Mvc;
using MikesMoves.Models;
using MikesMoves.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MikesMoves.Models.DTOs;

namespace MikesMoves.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private MikesMovesDbContext _dbContext;

    public UserProfileController(MikesMovesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            PhoneNumber = up.IdentityUser.PhoneNumber,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }).OrderBy(up => up.UserName));
    }

    [HttpGet("withroles/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRolesById(int id)
    {
        UserProfileForUserProfileDetailsDTO profileDTO = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Where(up => up.Id == id)
        .Select(up => new UserProfileForUserProfileDetailsDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            DateCreated = up.DateCreated,
            ImageLocation = up.ImageLocation,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }).SingleOrDefault();
        if (profileDTO == null)
        {
            return NotFound();
        }
        return Ok(profileDTO);
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");

        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        UserProfile user = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        user.Email = user.IdentityUser.Email;
        user.UserName = user.IdentityUser.UserName;
        return Ok(user);
    }

    // [HttpPut("{id}/image")]
    // public IActionResult UpdateImg(int id, [FromForm] UserProfileImgUpdateDTO img)
    // {
    //     UserProfile foundUser = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);

    //     if (foundUser == null || img.FormFile.Length == 0)
    //     {
    //         return BadRequest();
    //     }

    //     byte[] file;
    //     using (var memoryStream = new MemoryStream())
    //     {
    //         img.FormFile.CopyTo(memoryStream);
    //         file = memoryStream.ToArray();
    //     }

    //     foundUser.ImageBlob = file;

    //     _dbContext.SaveChanges();

    //     return NoContent();
    // }
}