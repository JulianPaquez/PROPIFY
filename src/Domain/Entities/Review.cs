using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace domain.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int Clasification { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        [ForeignKey("Property")]
        public int IdProp { get; set; }

        [Required]
        public string Comment { get; set; }

        // Relaciones
        public virtual User User { get; set; }
        public virtual Property Property { get; set; }

        public Review() { }

        public Review(int clasification, int idUser, int idProp, string comment)
        {
            Clasification = clasification;
            IdUser = idUser;
            IdProp = idProp;
            Comment = comment;
        }
    }
}