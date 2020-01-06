using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CitiesRepository : GenericRepository<Entities.City>, ICityRepository
    {
        public CitiesRepository(BaseDataContext databaseContext) : base(databaseContext)
        {

        }
    }
}
