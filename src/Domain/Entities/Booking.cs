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
        public DateOnly CheckOutDate { get; set; }
        public int NumbersOfTenants { get; set; }
        public Property Property { get; set; }
        public Payments Payments { get; set; }
        [NotMapped]
        public float TotalPrice => CalculateTotalPrice();

        public ApprovalState State { get; set; } = ApprovalState.pending; 


        private float CalculateTotalPrice()
        {
            if (Property == null) return 0;

            int days = CheckOutDate.DayNumber - CheckInDate.DayNumber;
            return days > 0 ? days * Property.PricePerNight : 0;
        }
    }
}