using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserApi
{
    public class UserDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDb(DbContextOptions<UserDb> options) : base(options) { }

    }

}