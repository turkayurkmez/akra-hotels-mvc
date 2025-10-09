using miniEShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Application.Services
{
    public class UserService : IUserSevice
    {
        private List<User> users = new()
        {
            new User{ Id=1, Email="turkay@gmail.com", Password="abc123", UserName="turkay", Role="Editor"},
            new User{ Id=2, Email="cagin@gmail.com", Password="abc123", UserName="cagin", Role="Admin"},
            new User{ Id=3, Email="zenginmusteri@gmail.com", Password="abc123", UserName="musteri", Role="Client"},


        };
        public User VerifyUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
