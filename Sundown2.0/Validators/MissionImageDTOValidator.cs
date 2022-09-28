using FluentValidation;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //RuleFor(x => x.Email)
            //    .Must(SomeMethod);


        }

        //public bool SomeMethod()
        //{
        //    var isDupe = dbcontect.users.singleOrDefault(x => x.email == email);

        //    if isDupe != null => return false;
        //}
    }
}
