using Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.DTO;
using Models.FilterModels;
using Models.IFilterModels;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Utils;

namespace BestRootAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseApiController<Models.City, Entities.City, Repositories.CitiesRepository, CityFilter>
    {
        public CitiesController(ICityRepository entityRepository, IConfiguration configuration, UserManager<IdentityUser> userManager) : base(entityRepository as CitiesRepository, configuration, userManager)
        {
            GetByFilterSelector = x => new Models.City
            {
                Id = x.Id,
                CityName = x.CityName,
                DestinationPoint = x.DestinationPoint,
                StartPoint = x.StartPoint,
                NeedsHotel = x.NeedsHotel,
                NeedsRestaurant = x.NeedsRestaurant,
                RestaurantType = x.RestaurantType,
                NeedsMuseum = x.NeedsMuseum,
                MuseumType = x.MuseumType,
                Location = new Models.LocationDTO { lat = x.Latitude, lng = x.Longitude},
                RequestDate = x.RequestDate,
                UserId = x.UserId
            };
        }

        [HttpPost]
        [Route("SaveCities")]
        public IActionResult SaveCities([FromBody] List<Models.City> cities)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500);
                }
                var currentDate = DateTime.Now;
                foreach (Models.City city in cities)
                {
                    City newCity = city.GetEntity() as City;
                    newCity.RequestDate = currentDate;
                    GenericRepository.AddItem(newCity);
                }
                var result = new BaseTokenizedDTO();
                result.AddToken(this.HttpContext);
                return Created(APIPath + "cities/SaveCities", result);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("GetRoutes")]
        public IActionResult GetRoutes([FromQuery] CityFilter cityFilter)
        {
            Expression<Func<City, bool>> predicate = x => true;
            if (cityFilter != null)
                predicate = cityFilter.GetFilter();

            var allRoutes = GenericRepository
                        .GetItems(predicate)
                        .Select(GetByFilterSelector)
                        .ToList();
            var cities = allRoutes.GroupBy(x => x.RequestDate).OrderByDescending(x => x.Key);
            var finalCities = new List<Tuple<DateTime, List<Models.City>>>();
            foreach (var cityGroup in cities)
            {
                finalCities.Add(new Tuple<DateTime, List<Models.City>>(cityGroup.Key, cityGroup.ToList()));
            }
            GetLastRouteResult result = new GetLastRouteResult { Cities = finalCities };
            result.AddToken(this.HttpContext);
            return new JsonResult(result);
        }
    }
}