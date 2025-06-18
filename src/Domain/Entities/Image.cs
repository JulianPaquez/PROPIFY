using domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UuidProperty { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public Image() { }

        public Image(int id, int uuidProperty, string name,  DateTime createdDate)
        {
            Id = id;
            UuidProperty = uuidProperty;
            Name = name;
            CreatedDate = createdDate;
        }
    }
}
