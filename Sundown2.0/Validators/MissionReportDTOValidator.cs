using FluentValidation;
using Sundown2._0.Models;


namespace Sundown2._0.Validators
{
    public class MissionReportDTOValidator : AbstractValidator<MissionReportDTO>
    {
        public MissionReportDTOValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.Latitude).NotNull().GreaterThan(0);
            RuleFor(x => x.Longitude).NotNull().GreaterThan(0);
            RuleFor(x => x.MissionDate).NotNull();
            RuleFor(x => x.FinalisationDate).NotNull();
        }

    }
}
