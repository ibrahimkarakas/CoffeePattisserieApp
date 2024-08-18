using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.Helpers.Abstract;
using CoffeePattisserie.Shared.ResponseDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Helpers.Concrete
{
     public class ImageHelper : IImageHelper
    {
        private string _imagesFolder;
        private readonly string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };
        private readonly string[] permittedMimeTypes = { "image/png", "image/jpg", "image/jpeg" };

        public ImageHelper(IWebHostEnvironment env)
        {
            if (env == null)
            {
                throw new ArgumentNullException(nameof(env), "IWebHostEnvironment instance is null.");
            }

            if (string.IsNullOrEmpty(env.WebRootPath))
            {
                throw new ArgumentNullException(nameof(env.WebRootPath), "WebRootPath is null or empty.");
            }

            _imagesFolder = Path.Combine(env.WebRootPath, "images");
        }

        public async Task<Response<ImageDto>> Upload(IFormFile file, string directoryName)
        {
            if (file == null || file.Length == 0)
            {
                return Response<ImageDto>.Fail("Resim dosyasında sorun var!", 401);
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (String.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return Response<ImageDto>.Fail("Resim formatı hatalı. png, jpg ya da jpeg gönderiniz.", 401);
            }

            _imagesFolder = Path.Combine(_imagesFolder, directoryName);
            if (!Directory.Exists(_imagesFolder))
            {
                Directory.CreateDirectory(_imagesFolder);
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var fullPath = Path.Combine(_imagesFolder, fileName);

            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var result = new ImageDto { ImageUrl = $"images/{directoryName}/{fileName}" };
            return Response<ImageDto>.Success(result, 201);
        }
    }
}
