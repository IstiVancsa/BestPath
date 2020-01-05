using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Repositories
{
    public static class BaseDataContextEntensions
    {
        public static void EnsureSeedDataForContext(this BaseDataContext baseDataContext)
        {
            if (baseDataContext.Users.Any())
            {
                return;
            }

            var rng = new Random();
            string[] usernames = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            string[] passwords = new[]
            {
            "123", "234", "345", "456", "567", "678", "789", "890"
            };

            var users = new List<User>();
            users.Add(new User
            {
                Id = new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                Username = usernames[rng.Next(usernames.Length)],
                Password = passwords[rng.Next(passwords.Length)],
                Token = Guid.NewGuid(),
                Age = rng.Next(100)
            });

            users.Add(new User
            {
                Id = new Guid("7e665add-6dda-4e36-b813-ecbd534dfffa"),
                Username = usernames[rng.Next(usernames.Length)],
                Password = passwords[rng.Next(passwords.Length)],
                Token = Guid.NewGuid(),
                Age = rng.Next(100)
            });

            users.Add(new User
            {
                Id = new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                Username = usernames[rng.Next(usernames.Length)],
                Password = passwords[rng.Next(passwords.Length)],
                Token = Guid.NewGuid(),
                Age = rng.Next(100)
            });

            users.Add(new User
            {
                Id = new Guid("744b602b-e8a7-4083-ac81-6ed65eebb56a"),
                Username = usernames[rng.Next(usernames.Length)],
                Password = passwords[rng.Next(passwords.Length)],
                Token = Guid.NewGuid(),
                Age = rng.Next(100)
            });

            users.Add(new User
            {
                Id = new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                Username = usernames[rng.Next(usernames.Length)],
                Password = passwords[rng.Next(passwords.Length)],
                Token = Guid.NewGuid(),
                Age = rng.Next(100)
            });

            baseDataContext.Users.AddRange(users);
            baseDataContext.SaveChanges();

            int[] stars = new[]
           {
                1,2,3,4,5
            };
            string[] reviews = new[]
            {
                "Perfect place for students but otherways it.s not that good",
                "Locație bună, preturi ok, personal amabil. Big like",
                "College Bar este un loc aparte , nu am mai vazut bar ca acesta.Cu mancare foarte buna si bauturile deasemenea !",
                "Burger făcut la rapid,ars pe o parte, pe cealaltă roz, în interior era între nefăcut și nefăcut :)  cartofii fără nici un gust. Sosul picant este excelent în schimb. Restul adus fără 10 lei. Am fost client fidel pe timpul anului, mergeam în fiecare zi,dar de ceva timp e cam bătaie de joc. Nu e frumos.",
                "O afacere studențească, fără un program clar și cu activități diverse. Personalul e binevoitor, dar fără experiență. Toată lumea face de toate...",
                "E aproape ca in vama..nu-i un loc pt printi și prințese :))"
            };

            var reviewsList = new List<Review>();
            reviewsList.Add(new Review
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                Stars = stars[rng.Next(stars.Length)],
                ReviewComment = reviews[rng.Next(reviews.Length)],
            });

            reviewsList.Add(new Review
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("42001e55-c6ec-4b56-8008-0d5930895867"),
                Stars = stars[rng.Next(stars.Length)],
                ReviewComment = reviews[rng.Next(reviews.Length)],
            });

            reviewsList.Add(new Review
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                Stars = stars[rng.Next(stars.Length)],
                ReviewComment = reviews[rng.Next(reviews.Length)],
            });

            reviewsList.Add(new Review
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("b8d4eb47-b8d1-4eb4-8b09-2133226ad4c6"),
                Stars = stars[rng.Next(stars.Length)],
                ReviewComment = reviews[rng.Next(reviews.Length)],
            });

            reviewsList.Add(new Review
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("f463cd1e-42b9-412b-b294-5880080e0883"),
                Stars = stars[rng.Next(stars.Length)],
                ReviewComment = reviews[rng.Next(reviews.Length)],
            });

            //baseDataContext.Cities.Add(new City());
            baseDataContext.Reviews.AddRange(reviewsList);
            baseDataContext.SaveChanges();
        }
    }
}
