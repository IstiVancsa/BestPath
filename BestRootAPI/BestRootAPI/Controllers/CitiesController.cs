using Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.FilterModels;
using Models.IFilterModels;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BestRootAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseApiController<Models.City, Entities.City, Repositories.CitiesRepository, CityFilter>
    {
        public CitiesController(ICityRepository entityRepository) : base(entityRepository as CitiesRepository)
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
        [Route("AddCities")]
        public IActionResult AddCities([FromBody] List<Models.City> cities)
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
                return Created(@"https://localhost:44344/cities/AddCities", cities);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("GetLastRoute")]
        public IActionResult GetLastRoute([FromQuery] CityFilter cityFilter)
        {
            Expression<Func<City, bool>> predicate = x => true;
            if (cityFilter != null)
                predicate = cityFilter.GetFilter();

            var allRoutes = GenericRepository
                        .GetItems(predicate)
                        .Select(GetByFilterSelector)
                        .ToList();
            var groupedRoutes = allRoutes.GroupBy(x => x.RequestDate).OrderBy(x => x.Key).ToList();
            return new JsonResult(groupedRoutes[groupedRoutes.Count() - 1]);
        }
    }
}