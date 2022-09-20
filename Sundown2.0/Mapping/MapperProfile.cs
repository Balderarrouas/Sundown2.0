using AutoMapper;
using Sundown2._0.Entities;
using Sundown2._0.Models;

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
            CreateMap<ClosestLandingFacility, ClosestLandingDTO>();            
        }


    }
}
