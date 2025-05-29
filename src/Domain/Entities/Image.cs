using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int UuidProperty { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Property Property { get; set; }

    }
}
