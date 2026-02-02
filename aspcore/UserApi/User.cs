using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi
{
    public class User(string username, string email, string password)
    {
        public int Id { get; set; }
        public string Username { get; set; } = username;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;

    }
}