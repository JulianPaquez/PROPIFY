using application.Interfaces;
using Application.Models;
using Application.Models.Request;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]

    public ActionResult<List<BookingDTO>> GetAll()
    {
        var bookings = _bookingService.GetAll();
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public ActionResult<BookingDTO> GetById(int id)
    {
        var client = _bookingService.GetById(id);
        if (client == null)
        {
            return NotFound("Admin not found");
        }
        return Ok(client);
    }

    [HttpPost]
    public ActionResult Create([FromBody] AddBookingRequest request)
    {
        return Ok(_bookingService.Create(request));
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, AddBookingRequest request)
    {
        try
        {
            _bookingService.Update(id, request);
            return Ok();
        }
        catch (Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        Booking booking = await _bookingService.GetById(id);
        if (booking != null)
        {
            _bookingService.Delete(booking);
            return Ok();
        }
        return StatusCode(500, "Propietario no encontrado");
    }


}