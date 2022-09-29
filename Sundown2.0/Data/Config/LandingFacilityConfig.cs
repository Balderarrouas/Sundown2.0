using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sundown2._0.Entities;

namespace Sundown2._0.Data.Config
{
    public class LandingFacilityConfig : IEntityTypeConfiguration<LandingFacility>
    {
        public void Configure(EntityTypeBuilder<LandingFacility> builder)
        {
            builder.HasKey(landingFacility => landingFacility.Id);
            builder.HasData(
                new LandingFacility
                {
                    
                    Name = "Europe",
                    Latitude = 55.68474022214539,
                    Longitude = 12.50971483525464
                },
                new LandingFacility
                {
                    
                    Name = "China",
                    Latitude = 41.14962602664463,
                    Longitude = 119.33727554032843
                },
                new LandingFacility
                {
                    
                    Name = "America",
                    Latitude = 40.014407426017335,
                    Longitude = -103.68329704730307
                },
                new LandingFacility
                {
                    
                    Name = "Africa",
                    Latitude = -21.02973667221353,
                    Longitude = 23.77076788325546
                },
                new LandingFacility
                {
                    
                    Name = "Australia",
                    Latitude = -33.00702098732439,
                    Longitude = 117.83314818861444
                },
                new LandingFacility
                {
                    
                    Name = "India",
                    Latitude = 19.330540162912126,
                    Longitude = 79.14236662251713
                },
                new LandingFacility
                {
                    
                    Name = "Argentina",
                    Latitude = -34.050351176517886,
                    Longitude = -65.92682965568743
                }




                );
        }
    }
}
