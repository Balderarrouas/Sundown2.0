using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sundown2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Data.Config
{
    public class MissionReportConfig : IEntityTypeConfiguration<MissionReport>
    {
        public void Configure(EntityTypeBuilder<MissionReport> builder)
        {
            builder.HasKey(missionReport => missionReport.MissionReportId);
        }
    }
}
