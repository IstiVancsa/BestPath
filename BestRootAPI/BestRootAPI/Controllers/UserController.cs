using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.FilterModels;
using Repositories;

namespace BestRootAPI.Controllers
{
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
    }
}