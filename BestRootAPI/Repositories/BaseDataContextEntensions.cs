using Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public static class BaseDataContextEntensions
    {
        public static void EnsureSeedDataForContext(this BaseDataContext baseDataContext)
        {
            if (baseDataContext.Cities.Any())
            {
                return;
            }
            var rng = new Random();

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

            baseDataContext.Reviews.AddRange(reviewsList);
            baseDataContext.SaveChanges();
        }
    }
}
