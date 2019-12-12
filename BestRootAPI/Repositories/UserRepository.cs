using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;

namespace Repositories
{
    public class UserRepository : GenericRepository<Entities.User>, IUserRepository
    {
        public UserRepository(BaseDataContext databaseContext) : base(databaseContext)
        {
            
        }
    }
}
