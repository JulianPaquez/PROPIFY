using domain.Interfaces;
using infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;

namespace infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {

        private readonly ApplicationContext _context;
        public BookingRepository(ApplicationContext context) : base(context)
        {

            _context = context;
        }
    }
}
