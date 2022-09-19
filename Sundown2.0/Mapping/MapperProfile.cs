using AutoMapper;
using Sundown2._0.Entities;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Mapping
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<MissionReportDTO, MissionReport>();
            CreateMap<MissionReport, MissionReportDTO>();
            CreateMap<MissionImageDTO, MissionImage>();
            CreateMap<MissionImage, MissionImageDTO>();
            
        }


    }
}
