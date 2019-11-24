using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Models;

namespace Repositories
{
    public class UserRepository : GenericRepository<UserDataContext, User>, IUserRepository
    {
    }
}
