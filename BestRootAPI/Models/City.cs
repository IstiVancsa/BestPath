using Entities;
using System;

namespace Models
{
    public class City : BaseModel
    {
        public string CityName { get; set; }
        public bool DestinationPoint { get; set; }
        public bool StartPoint { get; set; }
        public bool NeedsHotel { get; set; }
        public bool NeedsRestaurant { get; set; }
        public string RestaurantType { get; set; }
        public bool NeedsMuseum { get; set; }
        public string MuseumType { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid UserId { get; set; }
        public LocationDTO Location { get; set; }
        public int CityOrder { get; set; }

        public override BaseEntity GetEntity()
        {
            return new Entities.City
            {
                Id = this.Id,
                CityName = this.CityName,
                DestinationPoint = this.DestinationPoint,
                MuseumType = this.MuseumType,
                NeedsHotel = this.NeedsHotel,
                NeedsMuseum = this.NeedsMuseum,
                NeedsRestaurant = this.NeedsRestaurant,
                RestaurantType = this.RestaurantType,
                StartPoint = this.StartPoint,
                Latitude = this.Location.lat,
                Longitude = this.Location.lng,
                UserId = this.UserId,
                CityOrder = this.CityOrder
            };
        }

        public static implicit operator City(Entities.City v)
        {
            throw new NotImplementedException();
        }
    }
}
