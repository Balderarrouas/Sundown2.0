using Microsoft.EntityFrameworkCore;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Data
{
    public class SundownDbContext :DbContext
    {
        public SundownDbContext(DbContextOptions<SundownDbContext> options) : base(options)
        {
        }

        public DbSet<Astronaut> Astronauts { get; set; }


    }
}
