using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public UserDTO(User user) => (Username, Email) = (user.Username, user.Email);
    }
}