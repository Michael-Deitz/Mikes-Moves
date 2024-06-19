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
public class TrailerController : ControllerBase
{
    private MikesMovesDbContext _dbContext;

    public TrailerController(MikesMovesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllTrailers()
    {
        return Ok(_dbContext.Trailers
        .Select(t => new TrailerNoNavDTO
        {
            Id = t.Id,
            Height = t.Height,
            Width = t.Width,
            Length = t.Length,
            Capacity = t.Capacity,
            Location = t.Location,
            BasePrice = t.BasePrice,
            ImageUrl = t.ImageUrl,
            UserProfileId = t.UserProfileId,
            Type = t.Type,
            Description = t.Description,
            PricePerMile = t.PricePerMile
        }));
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetAllTrailersById(int id)
    {
        return Ok(_dbContext.Trailers
            .Where(t => t.Id == id)
            .Select(t => new TrailerNoNavDTO
            {
                Id = t.Id,
                Height = t.Height,
                Width = t.Width,
                Length = t.Length,
                Capacity = t.Capacity,
                Location = t.Location,
                BasePrice = t.BasePrice,
                PricePerMile = t.PricePerMile,
                ImageUrl = t.ImageUrl,
                UserProfileId = t.UserProfileId,
                Type = t.Type,
                Description = t.Description
            }).SingleOrDefault());
            
    }


    [HttpGet("withusers")]
    [Authorize]
    public IActionResult GetAllTrailersWithUsers()
    {
        List<TrailerWithUserDetailsDTO> trailersWithUsers = _dbContext.Trailers
            .Include(t => t.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Select(t => new TrailerWithUserDetailsDTO
            {
                Id = t.Id,
                Height = t.Height,
                Width = t.Width,
                Length = t.Length,
                Capacity = t.Capacity,
                Location = t.Location,
                BasePrice = t.BasePrice,
                PricePerMile = t.PricePerMile,
                ImageUrl = t.ImageUrl,
                UserProfileId = t.UserProfileId,
                UserProfiles = new UserProfileForTrailersOrItemsDTO 
                {
                    FirstName = t.UserProfile.FirstName,
                    LastName = t.UserProfile.LastName,
                    UserName = t.UserProfile.IdentityUser.UserName,
                    PhoneNumber = t.UserProfile.IdentityUser.PhoneNumber,
                    Email = t.UserProfile.IdentityUser.Email
                },
                Type = t.Type,
                Description = t.Description
            })
            .ToList();

        return Ok(trailersWithUsers);
    }

    [HttpGet("withusers/{id}")]
    [Authorize]
    public IActionResult GetAllTrailersWithUsersId(int id)
    {
        List<TrailerWithUserDetailsDTO> trailersWithUsers = _dbContext.Trailers
            .Include(t => t.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Where(t => t.Id == id)
            .Select(t => new TrailerWithUserDetailsDTO
            {
                Id = t.Id,
                Height = t.Height,
                Width = t.Width,
                Length = t.Length,
                Capacity = t.Capacity,
                Location = t.Location,
                BasePrice = t.BasePrice,
                PricePerMile = t.PricePerMile,
                ImageUrl = t.ImageUrl,
                UserProfileId = t.UserProfileId,
                UserProfiles = new UserProfileForTrailersOrItemsDTO 
                {
                    Id = t.UserProfile.Id,
                    FirstName = t.UserProfile.FirstName,
                    LastName = t.UserProfile.LastName,
                    UserName = t.UserProfile.IdentityUser.UserName,
                    PhoneNumber = t.UserProfile.IdentityUser.PhoneNumber,
                    Email = t.UserProfile.IdentityUser.Email
                },
                Type = t.Type,
                Description = t.Description
            })
            .ToList();

        return Ok(trailersWithUsers);
    }

    [HttpPost("create")]
    [Authorize]
    public IActionResult CreateTrailer(TrailerCreateDTO newTrailer)
    {
        UserProfile userProfile = _dbContext.UserProfiles.Find(newTrailer.UserProfileId);

        if (userProfile == null)
        {
            return BadRequest("Invalid UserProfileId");
        }

        Trailer trailerToCreate = new Trailer()
        {
           Type = newTrailer.Type,
           Description = newTrailer.Description,
           Height = newTrailer.Height,
           Width = newTrailer.Width,
           Length = newTrailer.Length,
           Capacity = newTrailer.Capacity,
           Location = newTrailer.Location,
           BasePrice = newTrailer.BasePrice,
           PricePerMile = newTrailer.PricePerMile,
           ImageUrl = newTrailer.ImageUrl,
           UserProfileId = newTrailer.UserProfileId
        };

        _dbContext.Trailers.Add(trailerToCreate);
        _dbContext.SaveChanges();

        return Created($"/api/trailer/{trailerToCreate.Id}", trailerToCreate);
    }

    [HttpPut("{id}/edit")]
    [Authorize]
    public IActionResult TrailerUpdate(int id, TrailerUpdateDTO updatedTrailer)
    {
        Trailer trailer = _dbContext.Trailers.SingleOrDefault(t => t.Id == id);

        if (trailer == null)
        {
            return NotFound();
        }

        trailer.Type = updatedTrailer.Type;
        trailer.Description = updatedTrailer.Description;
        trailer.Height = updatedTrailer.Height;
        trailer.Width = updatedTrailer.Width;
        trailer.Length = updatedTrailer.Length;
        trailer.Capacity = updatedTrailer.Capacity;
        trailer.Location = updatedTrailer.Location;
        trailer.BasePrice = updatedTrailer.BasePrice;
        trailer.PricePerMile = updatedTrailer.PricePerMile;
        trailer.ImageUrl = updatedTrailer.ImageUrl;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
   [Authorize]
   public IActionResult TrailerDelete(int id)
   {
        Trailer trailer = _dbContext.Trailers.SingleOrDefault(i => i.Id == id);

        _dbContext.Trailers.Remove(trailer);
        _dbContext.SaveChanges();

        if(trailer == null)
        {
            return NotFound();
        }

        return NoContent();
   }
}
