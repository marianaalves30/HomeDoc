using HomeDoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Services.Interfaces
{
    public interface IUserService
    {
        User Login(string email, string pass);
    }
}

