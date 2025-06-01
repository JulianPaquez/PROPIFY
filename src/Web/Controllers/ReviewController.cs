using application.DTOs;
using application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // GET: api/review
        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAll()
        {
            var reviews = _service.GetAll();
            return Ok(reviews);
        }

        // GET: api/review/{id}
        [HttpGet("{id}")]
        public ActionResult<ReviewDto> GetById(int id)
        {
            try
            {
                var review = _service.GetById(id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/review
        [HttpPost]
        public IActionResult Create([FromBody] ReviewCreateRequest request)
        {
            try
            {
                _service.Create(request);
                return Ok("Reseña creada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/review/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReviewUpdateRequest request)
        {
            try
            {
                _service.Update(id, request);
                return Ok("Reseña actualizada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/review/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Reseña eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
