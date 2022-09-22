//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using FluentValidation;
//using Moq;
//using Sundown2._0.Data;
//using Sundown2._0.Models;
//using Sundown2._0.Services;
//using Xunit;

//namespace UnitTests.Services
//{
//    public class MissionReportServiceTests : IClassFixture<MissionReportService>
//    {


        
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;
//        private IValidator<MissionReportDTO> _validator;


//        public MissionReportServiceTests(ApplicationDbContext applicationDbContext, IMapper mapper, IValidator<MissionReportDTO> validator)
//        {
//            _context = applicationDbContext;
//            _mapper = mapper;
//            _validator = validator;
//        }

//        [Fact]
//        public void testtest()
//        {

//            var x = new MissionReportService(_context, _mapper, _validator);
//            //var id = new Guid();

//            var trooth = true;

//            Assert.True(trooth);

//        }


//    }
//}
