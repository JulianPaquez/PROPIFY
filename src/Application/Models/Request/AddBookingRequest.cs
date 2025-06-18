using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class AddBookingRequest
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly ChekOutDate { get; set; }

        public ApprovalState state { get; set; }
    }
}
