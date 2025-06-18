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
        public int UuidProperty { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }

        public static ImageDto Create(Image image)
        {
            return new ImageDto
            {
                UuidProperty = image.UuidProperty,
                Name = image.Name,
                Path = image.Path,
                CreatedDate = DateTime.Now
            };
        }




    }


}