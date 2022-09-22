using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sundown2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Data.Config
{
    public class MissionImageConfig : IEntityTypeConfiguration<MissionImage>
    {
        public void Configure(EntityTypeBuilder<MissionImage> builder)
        {
            builder.HasKey(missionImage => missionImage.MissionImageId);
        }
    }
}
