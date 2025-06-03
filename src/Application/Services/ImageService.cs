using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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


        public ImageDto GetById(int id)
        {
            var list = _imageRepository.GetById(id);
            if (list == null) 
            {
                throw new Exception("Imagen no encontrada");
            }

            return ImageDto.Create(list);
        }

        



        public void Create(ImageCreateRequest dto)
        {
            var image = new Image
            {
                UuidProperty = dto.UuidProperty,
                Url = dto.Url
            };
            _imageRepository.Create(image);
        }


        public void Delete(int id)
        {
            var image = _imageRepository.GetById(id);
            if (image == null)
            {
                throw new Exception("Imagen no encontrada");
            }

            _imageRepository.Delete(image);
        }


    }
}
