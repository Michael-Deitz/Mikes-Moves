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
public class ReserveController : ControllerBase
{
    private MikesMovesDbContext _dbContext;

    public ReserveController(MikesMovesDbContext context)
    {
        _dbContext = context;
    }

[HttpGet("{trailerId}")]
[Authorize]
public IActionResult ReservedTrailers(int trailerId)
{
    return Ok(_dbContext.Reservations
        .Where(r => r.TrailerId == trailerId)
        .Select(r => new ReserveTrailerDTO
        {
            Id = r.Id,
            TrailerId = r.TrailerId,
            UserId = r.UserId,
            DateReserved = r.DateReserved,
            
        }));
}

[HttpPost]
[Authorize]
public IActionResult ReserveTrailer(ReserveTrailerDTO reserveATrailer)
{
    if (reserveATrailer == null)
    {
        return BadRequest("Invalid reservation data");
    }

    Reservation existingReservation = _dbContext.Reservations
        .FirstOrDefault(r => r.UserId == reserveATrailer.UserId
                           && r.TrailerId == reserveATrailer.TrailerId
                           && r.DateReserved.Date == reserveATrailer.DateReserved.Date);

    if (existingReservation != null)
    {
        return BadRequest("This trailer is already reserved for this date");
    }

    Reservation reservation = new Reservation
    {
        UserId = reserveATrailer.UserId,
        TrailerId = reserveATrailer.TrailerId,
        DateReserved = reserveATrailer.DateReserved
    };

        _dbContext.Reservations.Add(reservation);
        _dbContext.SaveChanges();
        return Ok(new { message = "Reservation created successfully!" });
 
}






}