using domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ImageDto
    {
        public int Id { get; set; }
        public int UuidProperty { get; set; }
        public string Url { get; set; }

        public  static ImageDto Create(Image image)
        {
            return new ImageDto
            {
                Id = image.Id,
                UuidProperty = image.UuidProperty,
                Url = image.Url
            };
        }


    }

    
}
