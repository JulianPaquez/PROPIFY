using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly ChekOutDate { get; set; }

        public ApprovalState state { get; set; } = ApprovalState.pending; 
    }
}
