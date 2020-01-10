using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.FilterModels;
using Repositories;
using System;
using System.Linq;

namespace BestRootAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController<Models.User, Entities.User, UserRepository, UserFilter>
    {

        private static readonly string[] Usernames = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] Passwords = new[]
        {
            "123", "234", "345", "456", "567", "678", "789", "890"
        };

        public UserController(IUserRepository entityRepository) : base(entityRepository as UserRepository)
        {
            GetByFilterSelector = x => new User
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

        [HttpGet]
        [Route("GetRandomUsers")]
        public IActionResult Get()
        {
            var rng = new Random();
            return new JsonResult(Enumerable.Range(1, 5).Select(index => new User
            {
                Id = new Guid(),
                Username = Usernames[rng.Next(Usernames.Length)],
                Password = Passwords[rng.Next(Passwords.Length)]
            })
                .ToArray());
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.GenericRepository.AddItem(user.GetEntity() as Entities.User);
                    return Created(@"https://localhost:44344/user/AddUser", user);
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
        public IActionResult EditUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.GenericRepository.UpdateItem(user.GetEntity() as Entities.User);
                    return Created(@"https://localhost:44344/user/EditUser", user);
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