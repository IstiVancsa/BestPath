using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.FilterModels;
using Repositories;

namespace BestRootAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : BaseApiController<Review, ReviewsRepository, ReviewFilter>
    {
        public ReviewController(ReviewsRepository entityRepository) : base(entityRepository)
        {
        }
    }
}