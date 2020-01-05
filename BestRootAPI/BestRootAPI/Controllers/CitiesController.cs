using System;
using System.Collections.Generic;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.FilterModels;
using Repositories;

namespace BestRootAPI.Controllers
{
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
                NeedsHotel =x.NeedsHotel,
                NeedsRestaurant=x.NeedsRestaurant,
                RestaurantType =x.RestaurantType,
                NeedsMuseum =x.NeedsMuseum,
                MuseumType = x.MuseumType
            };
        }

        [HttpPost]
        [Route("AddCities")]
        public IActionResult AddCities(Guid userId, [FromBody] List<Models.City> cities)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500);
                }
                foreach (Models.City city in cities){
                    City newCity = city.GetEntity() as Entities.City;
                    newCity.Date = DateTime.Now;
                    this.GenericRepository.AddItem(newCity);
                }
                return Created(@"https://localhost:44344/cities/AddCities", cities);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return StatusCode(500);
            }

        } 
    }
}