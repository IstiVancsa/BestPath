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
        private readonly ILogger<User> _logger;

        public UserController(IUserRepository entityRepository, ILogger<User> logger) : base(entityRepository as UserRepository)
        {
            _logger = logger;
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