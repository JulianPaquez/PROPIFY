using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<ActionResult<List<BookingDTO>>> GetAll()
    {
        var booking = await _bookingService.GetAllBookings();
        return Ok(booking);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<ActionResult<BookingDTO>> GetById([FromRoute] int id)
    {
        var booking = await _bookingService.GetBookingById(id);
        return Ok(booking);

    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Create([FromBody] BookingCreateRquest rEquest)
    {
        var newBooking = await _bookingService.AddBooking(rEquest);
        return Ok(newBooking);

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookingUpdateRequest request)
    {
        var updateBook = await _bookingService.UpdateBooking(id, request);
        return Ok(updateBook);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _bookingService.DeleteBooking(id);
        return NoContent();
    }
}