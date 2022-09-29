using FluentValidation;
using Sundown2._0.Models;


namespace Sundown2._0.Validators
{
    public class MissionImageDTOValidator : AbstractValidator<MissionImageDTO>
    {

        public MissionImageDTOValidator()
        {


            RuleFor(x => x.CameraName).NotEmpty();
            RuleFor(x => x.RoverName).NotEmpty();
            RuleFor(x => x.RoverStatus).NotEmpty();
            RuleFor(x => x.Img).NotNull();
            RuleFor(x => x.MissionReportId).NotNull().NotEmpty();
        }

       
    }
}
