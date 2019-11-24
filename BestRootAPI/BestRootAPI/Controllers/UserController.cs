using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.FilterModels;
using Repositories;

namespace BestRootAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : BaseApiController<User, UserRepository, UserFilter>
    {
        public UserController(UserRepository entityRepository) : base(entityRepository)
        {
        }

        private static readonly string[] Usernames = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] Passwords = new[]
        {
            "123", "234", "345", "456", "567", "678", "789", "890"
        };
        private readonly ILogger<User> _logger;

        public UserController(UserRepository currentRepository, ILogger<User> logger) : base(currentRepository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
                {
                    Id = new Guid(),
                    Username = Usernames[rng.Next(Usernames.Length)],
                    Password = Passwords[rng.Next(Passwords.Length)]
                })
                .ToArray();
        }
    }
}