using Sundown2._0.Data;
using Sundown2._0.Models;
using System.IO;
using Microsoft.Extensions.Options;
using Sundown2._0.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Sundown2._0.Services
{

    public interface IMissionReportService
    {
        MissionReport Create(MissionReportDTO model, int userId);
        List<MissionReport> GetAll();
        MissionReport GetById(int id);
        MissionReport Update(MissionReportDTO model, int id);
        MissionReport Delete(int id);        
    }


    public class MissionReportService : IMissionReportService
    {

        
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public MissionReportService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            
            _context = applicationDbContext;
            _mapper = mapper;
        }

        
        public MissionReport Create(MissionReportDTO model, int userId)
        {

            
            var missionReport = _mapper.Map<MissionReport>(model);
            missionReport.CreatedAt = DateTime.UtcNow;
            missionReport.UpdatedAt = DateTime.UtcNow;
            missionReport.AstronautId = userId;

            _context.MissionReports.Add(missionReport);
            _context.SaveChanges();
            
            return missionReport;
        }


        public List<MissionReport> GetAll()
        {
            return _context.MissionReports.ToList();
        }


        public MissionReport GetById(int id)
        {
            var missionreport = _context.MissionReports.FirstOrDefault(x => x.MissionReportId == id);
            missionreport.MissionImages = _context.MissionImages.Where(x => x.MissionReportId == id).ToList();
            return missionreport;
        }


        public MissionReport Update(MissionReportDTO model, int id)
        {
            var reportToUpdate = _context.MissionReports.FirstOrDefault(x => x.MissionReportId == id);
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


        public MissionReport Delete(int id)
        {

            var reportToDelete = _context.MissionReports.Find(id);
            _context.MissionReports.Remove(reportToDelete);
            _context.SaveChanges();
            
            return reportToDelete;
        }
    }
}
