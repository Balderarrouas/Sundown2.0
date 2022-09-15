using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Models
{
    public class ImageResponseModel
    {

        public bool IsImageSaved { get; set; }




        public ImageResponseModel(bool isImageSaved)
        {
            IsImageSaved = isImageSaved;
        }

    }
}
