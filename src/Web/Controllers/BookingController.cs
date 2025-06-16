using Application.Models;
using Application.Models.Request;
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
    public async Task<ActionResult<List<BookingDTO>>> GetAll()
    {
        var booking = await _bookingService.GetAllBookings();
        return Ok(booking);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDTO>> GetById([FromRoute] int id)
    {
        var booking = await _bookingService.GetBookingById(id);
        return Ok(booking);

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingCreateRquest rEquest)
    {
        var newBooking = await _bookingService.AddBooking(rEquest);
        return Ok(newBooking);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookingUpdateRequest request)
    {
        var updateBook = await _bookingService.UpdateBooking(id, request);
        return Ok(updateBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _bookingService.DeleteBooking(id);
        return NoContent();
    }
}