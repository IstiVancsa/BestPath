using Models.IFilterModels;
using System;
using System.Linq.Expressions;
using Utils;

namespace Models.FilterModels
{
    public class CityFilter : BaseFilterModel, ICityFilter
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
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Expression<Func<Entities.City, bool>> GetFilter()
        {
            Expression<Func<Entities.City, bool>> filter = x => true;

            if (this.Id.HasValue)
                filter = filter.And(x => x.Id == Id);
            if (this.UserId != null && this.UserId != Guid.Empty)
                filter = filter.And(x => x.UserId == UserId);
            //if (!string.IsNullOrEmpty(this.CityName))
            //    filter = filter.And(x => x.CityName.Trim().ToLower().Contains(CityName.Trim().ToLower()));
            //if (!string.IsNullOrEmpty(this.Password))
            //    filter = filter.And(x => x.Password == Password);
            return filter;
        }
        public CityFilter()
        {

        }
    }
}
