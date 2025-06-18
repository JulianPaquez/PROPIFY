using Application.Models.Request;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAll();
        Task<Booking?> GetById(int id);
        Task<Booking?> Create(AddBookingRequest dto);
        Task Update(int id, AddBookingRequest request);
        Task Delete(Booking booking);
    }
}
