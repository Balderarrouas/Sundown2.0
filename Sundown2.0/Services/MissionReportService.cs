using Sundown2._0.Data;
using Sundown2._0.Models;
using Sundown2._0.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Sundown2._0.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{

    public interface IMissionReportService
    {
        MissionReport Create(MissionReportDTO model, HttpContext httpContext1);
        Task<List<MissionReport>> GetAll();
        MissionReport GetById(Guid id);
        MissionReport Update(MissionReportDTO model, Guid id);
        MissionReport Delete(Guid id);        
    }


    public class MissionReportService : IMissionReportService
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private IValidator<MissionReportDTO> _validator;


        

        public MissionReportService(ApplicationDbContext applicationDbContext, 
            IMapper mapper, IValidator<MissionReportDTO> validator)
        {            
            _context = applicationDbContext;
            _mapper = mapper;
            _validator = validator;
        }

       

        public MissionReport Create(MissionReportDTO model, HttpContext userHttpContext)
        {
            ValidationResult result = _validator.Validate(model); 
            
            if (!result.IsValid)
            {
                throw new CustomValidationException("Request body did not fulfill the neccesary validation requirements");
            }
            
            var httpContext = userHttpContext;
            var jwt = httpContext.Request.Headers["Authorization"];
            var userIdString = httpContext.User?.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
            var userId = int.Parse(userIdString);


            var missionReport = _mapper.Map<MissionReport>(model);
            missionReport.CreatedAt = DateTime.UtcNow;
            missionReport.UpdatedAt = DateTime.UtcNow;
            missionReport.AstronautId = userId;

            _context.MissionReports.Add(missionReport);
            _context.SaveChanges();
            
            return missionReport;
        }


        public async Task<List<MissionReport>> GetAll()
        {          
            
            return _context.MissionReports.ToList();
        }


        public MissionReport GetById(Guid id)
        {
            var missionreport = _context.MissionReports.SingleOrDefault(x => x.MissionReportId == id);

            if (missionreport == null)
            {
                throw new CustomNotFoundException($"missionreport with {id} could not be found");
            }
            missionreport.MissionImages = _context.MissionImages.Where(x => x.MissionReportId == id).ToList();
            return missionreport;
        }


        public MissionReport Update(MissionReportDTO model, Guid id)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                throw new CustomValidationException("Request body did not fulfill the neccesary validation requirements");
            }

            var reportToUpdate = _context.MissionReports.SingleOrDefault(x => x.MissionReportId == id);

            if (reportToUpdate == null)
            {
                throw new CustomNotFoundException($"missionreport with {id} could not be found");
            }
            reportToUpdate.Name = model.Name;
            reportToUpdate.Description = model.Description;
            reportToUpdate.Latitude = model.Latitude;
            reportToUpdate.Longitude = model.Longitude;
            reportToUpdate.MissionDate = model.MissionDate;
            reportToUpdate.FinalisationDate = model.FinalisationDate;
            reportToUpdate.UpdatedAt = DateTime.UtcNow;

            _context.MissionReports.Update(reportToUpdate);
            _context.SaveChanges();
                        
            return reportToUpdate;
        }


        public MissionReport Delete(Guid id)
        {

            var reportToDelete = _context.MissionReports.Find(id);

            if (reportToDelete == null)
            {
                throw new CustomNotFoundException($"missionreport with {id} could not be found");
            }
            reportToDelete.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
            
            return reportToDelete;
        }
    }
}
