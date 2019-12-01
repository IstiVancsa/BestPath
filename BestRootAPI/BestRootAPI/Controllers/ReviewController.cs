using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.FilterModels;
using Repositories;

namespace BestRootAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : BaseApiController<Models.Review, Entities.Review,ReviewsRepository, ReviewFilter>
    {
        public ReviewController(IReviewRepository entityRepository) : base(entityRepository as ReviewsRepository)
        {
        }
    }
}