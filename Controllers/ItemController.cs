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
public class ItemController : ControllerBase
{
    private MikesMovesDbContext _dbContext;

    public ItemController(MikesMovesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllItems()
    {
        return Ok(_dbContext.Items
        .Select(i => new ItemNoNavDTO
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            ImageUrl = i.ImageUrl,
            Height = i.Height,
            Width = i.Width,
            Length = i.Length,
            Weight = i.Weight,
            UserProfileId = i.UserProfileId
        }));
    }

    [HttpGet("{id}")]
    [Authorize]
   public IActionResult GetAllItemsById(int id)
   {
        return Ok(_dbContext.Items
        .Where(i => i.Id == id)
        .Select(i => new ItemNoNavDTO
            {
                Id = i.Id,
                Height = i.Height,
                Width = i.Width,
                Length = i.Length,
                Weight = i.Weight,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                Description = i.Description,
                UserProfileId = i.UserProfileId,
            }).SingleOrDefault());
            
   }

   [HttpGet("withusers")]
   [Authorize]
   public IActionResult GetAllItemsWithUsers()
   {
        List<ItemWithUserDetailsDTO> itemsWithUsers = _dbContext.Items
            .Include(i => i.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Select(i => new ItemWithUserDetailsDTO
            {
                Id = i.Id,
                Height = i.Height,
                Width = i.Width,
                Length = i.Length,
                Weight = i.Weight,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                Description = i.Description,
                UserProfileId = i.UserProfileId,
                UserProfile = new UserProfileForTrailersOrItemsDTO
                {
                    FirstName = i.UserProfile.FirstName,
                    LastName = i.UserProfile.LastName,
                    UserName = i.UserProfile.IdentityUser.UserName,
                    PhoneNumber = i.UserProfile.IdentityUser.PhoneNumber,
                    Email = i.UserProfile.IdentityUser.Email
                }
            })
            .ToList();

        return Ok(itemsWithUsers);
   }

   [HttpGet("withusers/{id}")]
   [Authorize]
   public IActionResult GetAllItemsWithUsersById(int id)
   {
        List<ItemWithUserDetailsDTO> itemsWithUsers = _dbContext.Items
            .Include(i => i.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Where(i => i.Id == id)
            .Select(i => new ItemWithUserDetailsDTO
            {
                Id = i.Id,
                Height = i.Height,
                Width = i.Width,
                Length = i.Length,
                Weight = i.Weight,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                Description = i.Description,
                UserProfileId = i.UserProfileId,
                UserProfile = new UserProfileForTrailersOrItemsDTO
                {
                    Id = i.UserProfile.Id,
                    FirstName = i.UserProfile.FirstName,
                    LastName = i.UserProfile.LastName,
                    UserName = i.UserProfile.IdentityUser.UserName,
                    PhoneNumber = i.UserProfile.IdentityUser.PhoneNumber,
                    Email = i.UserProfile.IdentityUser.Email
                }
            })
            .ToList();

        return Ok(itemsWithUsers);
   }

   [HttpPost("create")]
   [Authorize]
   public IActionResult CreateItem(ItemCreateDTO newItem)
   {
        UserProfile userProfile = _dbContext.UserProfiles.Find(newItem.UserProfileId);

        if (userProfile == null)
        {
            return BadRequest("Invalid UserProfileId");
        }

        Item itemToCreate = new Item()
        {
            Name = newItem.Name,
            Description = newItem.Description,
            ImageUrl = newItem.ImageUrl,
            Height = newItem.Height,
            Width = newItem.Width,
            Length = newItem.Length,
            Weight = newItem.Weight,
            UserProfileId = newItem.UserProfileId
        };

        _dbContext.Items.Add(itemToCreate);
        _dbContext.SaveChanges();

        return Created($"/api/item/{itemToCreate.Id}", itemToCreate);
   }

   [HttpPut("{id}/edit")]
   [Authorize]
   public IActionResult ItemUpdate(int id, ItemUpdateDTO updatedItem)
   {
    Item item = _dbContext.Items.SingleOrDefault(i => i.Id == id);

    if (item == null)
    {
        return NotFound();
    }

    item.Name = updatedItem.Name;
    item.Description = updatedItem.Description;
    item.ImageUrl = updatedItem.ImageUrl;
    item.Height = updatedItem.Height;
    item.Width = updatedItem.Width;
    item.Length = updatedItem.Length;
    item.Weight = updatedItem.Weight;

    _dbContext.SaveChanges();

    return NoContent();
   }

   [HttpDelete("{id}")]
   [Authorize]
   public IActionResult ItemDelete(int id)
   {
        Item item = _dbContext.Items.SingleOrDefault(i => i.Id == id);

        _dbContext.Items.Remove(item);
        _dbContext.SaveChanges();

        if(item == null)
        {
            return NotFound();
        }

        return NoContent();
   }
}