using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sundown2._0.Entities;

namespace Sundown2._0.Data.Config
{
    public class AstronautConfig : IEntityTypeConfiguration<Astronaut>
    {        
        
        public void Configure(EntityTypeBuilder<Astronaut> builder)
        {
            //builder.HasKey(astronaut => astronaut.AstronautId);
            // builder.HasQueryFilter(x => x.DeletedAt = null);
            builder.HasData(
                    new Astronaut
                    {
                        AstronautId = 1,
                        FirstName = "Yuri",
                        LastName = "Gagarin",
                        CodeName = "First Man",
                        Username = "yuga",
                        Email = "yuga@mtr.moon",
                        Password = "ucJa3b1m3QCZvHM67PqYNTjKrqm6xJ01C/cXXSlvcRM=:eNJJotJygM5lfRT7VsnM5w==",
                        Avatar = "C:\\Users\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yuga.jpg"                       
                    },
                     new Astronaut
                     {
                         AstronautId = 2,
                         FirstName = "Alan",
                         LastName = "Shepard",
                         CodeName = "Shepard",
                         Username = "alsh",
                         Email = "alsh@mtr.moon",
                         Password = "ITzi4V0MySnXMJA5WJu+p/zrjJ7v8F6JR//bUq7kzTM=:54+4rtMAB8384oiNiNCTDg==",
                         Avatar = "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Alsh.jpg"
                     },
                     new Astronaut
                     {
                         AstronautId = 3,
                         FirstName = "Valentina",
                         LastName = "Tereshkova",
                         CodeName = "Valentine",
                         Username = "vate",
                         Email = "vate@mtr.moon",
                         Password = "F0RxBSmnVern/V/fHx4SNRMeZ+G6y/weNcBI37ONaSg=:/7FYNPQaAzjB+Qv7oTaXVw==",
                         Avatar = "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Vate.jpg"

                     },
                     new Astronaut
                     {
                         AstronautId = 4,
                         FirstName = "Guion",
                         LastName = "Bluford",
                         CodeName = "bluey",
                         Username = "gubl",
                         Email = "gubi@mtr.moon",
                         Password = "VHblRfxl4dZ2pPNtHWih3gAWtQKtRwa4rtvctzafJPo=:/mo5k7OFhrEkp6m+z0PNsA==",
                         Avatar = "C:\\Users\\balde\\source\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Gubl.jpg"

                     },
                     new Astronaut
                     {
                         AstronautId = 5,
                         FirstName = "Andreas",
                         LastName = "Mogensen",
                         CodeName = "Great Dane",
                         Username = "anmo",
                         Email = "anmo@mtr.moon",
                         Password = "K2HIUcKqjvNUUoHSWczlnnSnR4s6gWZ1F4sqGexWQGI=:mlopqmOCKizStvRG3z14PQ==",
                         Avatar = "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Anmo.jpg"

                     },
                     new Astronaut
                     {
                         AstronautId = 6,
                         FirstName = "Yi",
                         LastName = "So-Yeon",
                         CodeName = "Neon",
                         Username = "yiso",
                         Email = "yiso@mtr.moon",
                         Password = "zygdXJKeXaglxCmRv3uF7c7Jhn/KMEIhSdEZqwJRRow=:sdRQ1lQmTJ+3F8N0jnSUCQ==",
                         Avatar = "C:\\Users\\balde\\source\\repos\\Sundown2.0\\Sundown2.0\\Media\\Images\\Yiso.jpeg"

                     }
                     );
        }
    }
}
