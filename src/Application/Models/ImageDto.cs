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
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public static ImageDto Create(Image image)
        {
            return new ImageDto
            {
                Name = image.Name,
                CreatedDate = DateTime.Now
            };
        }




    }


}