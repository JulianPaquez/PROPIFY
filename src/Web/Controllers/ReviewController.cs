using System.Security.Claims;
using application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<ActionResult<List<ReviewDto>>> GetAll()
    {
        var reviews = await _service.GetAllAsync();
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<ActionResult<ReviewDto>> GetById(int id)
    {
        try
        {
            var review = await _service.GetByIdAsync(id);
            return Ok(review);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Create([FromBody] ReviewCreateRequest request)
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim);

            await _service.CreateAsync(request, userId);
            return Ok("Reseña creada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Update(int id, [FromBody] ReviewUpdateRequest request)
    {
        try
        {
            await _service.UpdateAsync(id, request);
            return Ok("Reseña actualizada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok("Reseña eliminada correctamente.");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}