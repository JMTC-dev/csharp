using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi
{
    public class Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}