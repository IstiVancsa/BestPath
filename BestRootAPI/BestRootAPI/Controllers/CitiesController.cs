using Entities;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.FilterModels;
using Repositories;
using System;
using System.Collections.Generic;

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
                Latitude = x.Latitude,
                Longitude = x.Longitude,
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
                foreach (Models.City city in cities)
                {
                    City newCity = city.GetEntity() as Entities.City;
                    newCity.Date = DateTime.Now;// DON'T SET VALUE HERE
                    this.GenericRepository.AddItem(newCity);
                }
                return Created(@"https://localhost:44344/cities/AddCities", cities);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }

        }
    }
}