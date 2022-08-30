using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Data.Config
{
    public class AstronautConfig : IEntityTypeConfiguration<Astronaut>
    {
        public void Configure(EntityTypeBuilder<Astronaut> builder)
        {
            builder.HasData(
                    new Astronaut
                    {
                        Id = 1,
                        FirstName = "Yuri",
                        LastName = "Gagarin",
                        CodeName = "First Man",
                        Username = "yuga",
                        Email = "yuga@mtr.moon",
                        Password = "poleposition1",
                        Avatar = ""
                    },
                     new Astronaut
                     {
                         Id = 2,
                         FirstName = "Alan",
                         LastName = "Shepard",
                         CodeName = "Shepard",
                         Username = "alsh",
                         Email = "alsh@mtr.moon",
                         Password = "secret",
                         Avatar = ""

                     },
                     new Astronaut
                     {
                         Id = 3,
                         FirstName = "Valentina",
                         LastName = "Tereshkova",
                         CodeName = "Valentine",
                         Username = "vate",
                         Email = "vate@mtr.moon",
                         Password = "DQ!cnRVYzQ64@Fwha!XB_kYn",
                         Avatar = ""

                     },
                     new Astronaut
                     {
                         Id = 4,
                         FirstName = "Guion",
                         LastName = "Bluford",
                         CodeName = "bluey",
                         Username = "gubi",
                         Email = "gubi@mtr.moon",
                         Password = "STS-8!Challenger1983",
                         Avatar = ""

                     },
                     new Astronaut
                     {
                         Id = 5,
                         FirstName = "Andreas",
                         LastName = "Mogensen",
                         CodeName = "Great Dane",
                         Username = "anmo",
                         Email = "anmo@mtr.moon",
                         Password = "rødgrødmedfløde",
                         Avatar = ""

                     },
                     new Astronaut
                     {
                         Id = 6,
                         FirstName = "Yi",
                         LastName = "So-Yeon",
                         CodeName = "Neon",
                         Username = "yiso",
                         Email = "yiso@mtr.moon",
                         Password = "K2t@dACRkGCd3-UQQmCZJbTj",
                         Avatar = ""

                     }
                     );
        }
    }
}
