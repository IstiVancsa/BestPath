using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.FilterModels;
using Repositories;
using System;
using System.Linq;

namespace BestRootAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController<Models.UserModel, Entities.User, UserRepository, UserFilter>
    {

        private static readonly string[] Usernames = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] Passwords = new[]
        {
            "123", "234", "345", "456", "567", "678", "789", "890"
        };

        public UserController(IUserRepository entityRepository, IConfiguration configuration, UserManager<IdentityUser> userManager) : base(entityRepository as UserRepository, configuration, userManager)
        {
            GetByFilterSelector = x => new UserModel
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                Token = x.Token,
                Age = x.Age,
                Reviews = x.Reviews.Select(y => new Review
                {
                    Id = y.Id,
                    ReviewComment = y.ReviewComment,
                    Stars = y.Stars
                }).ToList()
            };
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.GenericRepository.AddItem(user.GetEntity() as Entities.User);
                    return Created(APIPath + "user/AddUser", user);
                }
                return StatusCode(500);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("EditUser")]
        public IActionResult EditUser([FromBody] UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.GenericRepository.UpdateItem(user.GetEntity() as Entities.User);
                    return Created(APIPath + "user/EditUser", user);
                }
                return StatusCode(500);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }
        }

    }
}