using Microsoft.EntityFrameworkCore;
using Sundown2._0.Data.Config;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Data
{
    public class ApplicationDbContext :DbContext
    {   
        public DbSet<Astronaut> Astronauts { get; set; }
        public DbSet<LandingFacility> LandingFacilities { get; set; }
        public DbSet<SpaceStation> SpaceStations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {




        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AstronautConfig());
            builder.ApplyConfiguration(new LandingFacilityConfig());
            base.OnModelCreating(builder);
        }
        



    }
}
