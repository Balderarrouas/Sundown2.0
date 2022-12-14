using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using Sundown2._0.Data;
using Sundown2._0.Entities;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sundown2._0.Services
{

    public interface IMissionImageService
    {
        MissionImage Create(MissionImageDTO model);
        List<MissionImage> GetAll();
        MissionImage GetById(Guid id);
        MissionImage Update(MissionImageDTO model, Guid id);
        MissionImage Delete(Guid id);
    }




    public class MissionImageService : IMissionImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private IValidator<MissionImageDTO> _validator;

        public MissionImageService(ApplicationDbContext applicationDbContext, 
            IMapper mapper, IOptions<AppSettings> appSettings, IValidator<MissionImageDTO> validator)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _validator = validator;
        }




        public MissionImage Create(MissionImageDTO model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                throw new CustomValidationException("Request body did not fulfill the neccesary validation requirements");
            }

            var missionImage = _mapper.Map<MissionImage>(model);

            var filePath = Path.Combine(_appSettings.MediaFolder, model.Img.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Img.CopyTo(stream);
            }

            missionImage.Image = filePath;
            missionImage.CreatedAt = DateTime.UtcNow;
            missionImage.UpdatedAt = DateTime.UtcNow;

            _context.MissionImages.Add(missionImage);
            _context.SaveChanges();

            return missionImage;
        }


        public List<MissionImage> GetAll()
        {
            return _context.MissionImages.ToList();
        }



        public MissionImage GetById(Guid id)
        {
            var missionImage = _context.MissionImages.FirstOrDefault(x => x.MissionImageId == id);

            if (missionImage == null)
            {
                throw new CustomNotFoundException($"missionImage with {id} could not be found");
            }

            return missionImage;
        }


        public MissionImage Update(MissionImageDTO model, Guid id)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                throw new CustomValidationException("Request body did not fulfill the neccesary validation requirements");
            }

            var filePath = Path.Combine(_appSettings.MediaFolder, model.Img.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Img.CopyTo(stream);
            }

            var imageToUpdate = _context.MissionImages.FirstOrDefault(x => x.MissionImageId == id);

            if (imageToUpdate == null)
            {
                throw new CustomNotFoundException($"missionImage with {id} could not be found");
            }
            imageToUpdate.CameraName = model.CameraName;
            imageToUpdate.RoverName = model.RoverName;
            imageToUpdate.RoverStatus = model.RoverStatus;
            imageToUpdate.Image = filePath;
            imageToUpdate.MissionReportId = model.MissionReportId;
            imageToUpdate.UpdatedAt = DateTime.UtcNow;

            _context.MissionImages.Update(imageToUpdate);
            _context.SaveChanges();

            return imageToUpdate;
        }


        public MissionImage Delete(Guid id)
        {
            var imageToDelete = _context.MissionImages.Find(id);

            if (imageToDelete == null)
            {
                throw new CustomNotFoundException($"missionImage with {id} could not be found");
            }
            imageToDelete.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return imageToDelete;
        }
    }
}
