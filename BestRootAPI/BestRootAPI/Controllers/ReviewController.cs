using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.FilterModels;
using Repositories;
using System;

namespace BestRootAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseApiController<Models.Review, Entities.Review, ReviewsRepository, ReviewFilter>
    {
        public ReviewController(IReviewRepository entityRepository) : base(entityRepository as ReviewsRepository)
        {
            GetByFilterSelector = x => new Review
            {
                Id = x.Id,
                ReviewComment = x.ReviewComment,
                Stars = x.Stars,
                UserId = x.UserId
            };
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview([FromBody] Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.GenericRepository.AddItem(review.GetEntity() as Entities.Review);
                    return Created(@"https://localhost:44344/user/AddUser", review);
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