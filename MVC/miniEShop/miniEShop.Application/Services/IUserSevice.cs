using miniEShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Application.Services
{
    public interface IUserSevice
    {
        User VerifyUser(string username, string password);
    }
}
