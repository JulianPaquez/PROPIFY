using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<ImageDto> GetByNameAsync(string name)
        {
            var image = await _imageRepository.GetByNameAsync(name);
            if (image == null)
            {
                throw new Exception("Imagen no encontrada");
            }

            return ImageDto.Create(image);
        }

        public async Task CreateAsync(ImageCreateRequest dto)
        {
            var image = new Image
            {
                Name = dto.Name,
                CreatedDate = DateTime.Now
            };
            await _imageRepository.CreateAsync(image);
        }

        public async Task DeleteAsync(string name)
        {
            var image = await _imageRepository.GetByNameAsync(name);
            if (image == null)
            {
                throw new Exception("Imagen no encontrada");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploadImages", name);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            await _imageRepository.DeleteAsync(image);
        }
    }
}