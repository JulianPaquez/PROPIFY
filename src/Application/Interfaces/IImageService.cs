using Application.Models;
using Application.Models.Request;
using domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImageService
    {
        Task<ImageDto?> GetByNameAsync(string name);
        Task CreateAsync(ImageCreateRequest request);
        Task DeleteAsync(string name);
    }

}
