using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entities
{
    public class User : BaseEntity
    {
        public Guid Token { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required] 
        public int Age { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        //public override List<BaseEntity> CreateSeeds(int numberOfSeeds)
        //{
        //    var rng = new Random();
        //    string[] usernames = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //    };
        //    string[] passwords = new[]
        //    {
        //    "123", "234", "345", "456", "567", "678", "789", "890"
        //    };

        //    List<BaseEntity> users = new List<BaseEntity>();
        //    users.Add((BaseEntity)new User
        //    {
        //        Id = new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
        //        Username = usernames[rng.Next(usernames.Length)],
        //        Password = passwords[rng.Next(passwords.Length)],
        //        Token = Guid.NewGuid()
        //    });

        //    users.Add((BaseEntity)new User
        //    {
        //        Id = new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
        //        Username = usernames[rng.Next(usernames.Length)],
        //        Password = passwords[rng.Next(passwords.Length)],
        //        Token = Guid.NewGuid()
        //    });

        //    users.Add((BaseEntity)new User
        //    {
        //        Id = new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
        //        Username = usernames[rng.Next(usernames.Length)],
        //        Password = passwords[rng.Next(passwords.Length)],
        //        Token = Guid.NewGuid()
        //    });

        //    users.Add((BaseEntity)new User
        //    {
        //        Id = new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
        //        Username = usernames[rng.Next(usernames.Length)],
        //        Password = passwords[rng.Next(passwords.Length)],
        //        Token = Guid.NewGuid()
        //    });

        //    users.Add((BaseEntity)new User
        //    {
        //        Id = new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
        //        Username = usernames[rng.Next(usernames.Length)],
        //        Password = passwords[rng.Next(passwords.Length)],
        //        Token = Guid.NewGuid()
        //    });

        //    return users;
        //}
    }
}
