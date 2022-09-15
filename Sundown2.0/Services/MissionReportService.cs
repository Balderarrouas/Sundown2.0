using Sundown2._0.Data;
using Sundown2._0.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;
using Sundown2._0.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Sundown2._0.Services
{

    public interface IMissionReportService
    {
        MissionReport CreateMissionReport(MissionReportRequestModel model);
        void UploadMissionImage(MissionImageRequestModel model);
    }


    public class MissionReportService : IMissionReportService
    {

        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;


        public MissionReportService(IOptions<AppSettings> appSettings, ApplicationDbContext applicationDbContext)
        {
            _appSettings = appSettings.Value;
            _context = applicationDbContext;
        }


        public MissionReport CreateMissionReport(MissionReportRequestModel model)
        {

            var missionReport = new MissionReport(model);
            missionReport.CreatedAt = DateTime.UtcNow;
            missionReport.AstronautId = 1;


            _context.MissionReports.Add(missionReport);
            _context.SaveChanges();

            


            
           
           
            return missionReport;
        }

        public void UploadMissionImage(MissionImageRequestModel model)
        {
            
            var filePath = Path.Combine(_appSettings.MediaFolder, model.MissionImage.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.MissionImage.CopyTo(stream);
            }

            return;
        }



    }
}
