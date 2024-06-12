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

    [HttpGet("withusers")]
    [Authorize]
    public IActionResult GetAllTrailersWithUsers()
    {
        return Ok(_dbContext.Trailers
        .Include(t => t.UserProfile)
            .ThenInclude(t => t.IdentityUser)
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
            
        }));
    }
}