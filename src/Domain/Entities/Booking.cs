using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public User ClientName { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly ChekOutDate { get; set; }

        public ApprovalState State { get; set; } = ApprovalState.pending; 
    }
}