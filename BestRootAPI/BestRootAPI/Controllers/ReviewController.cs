using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.DTO;
using Models.FilterModels;
using Repositories;
using System;
using Utils;

namespace BestRootAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseApiController<Models.Review, Entities.Review, ReviewsRepository, ReviewFilter>
    {
        public ReviewController(IReviewRepository entityRepository, IConfiguration configuration, UserManager<IdentityUser> userManager) : base(entityRepository as ReviewsRepository, configuration, userManager)
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
                    var result = new BaseTokenizedDTO();
                    result.AddToken(this.HttpContext);
                    return Created(APIPath + "review/AddReview", result);
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