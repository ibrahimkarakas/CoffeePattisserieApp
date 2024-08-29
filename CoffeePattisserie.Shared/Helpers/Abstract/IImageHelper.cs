using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Helpers.Abstract
{
    public interface IImageHelper
    {
         Task<Response<ImageDto>> Upload(IFormFile file, string directoryName);

    }
}
