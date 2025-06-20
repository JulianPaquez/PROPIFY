
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<ActionResult> GetAll()
    {
        var prop = await _propertyService.GetAll();
        return Ok(prop);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<ActionResult<PropertyDto>> GetById(int id)
    {
        try
        {
            var prop = await _propertyService.GetById(id);
            return Ok(prop);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Propiedad no encontrada");
        }
    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Create([FromBody] PropertyCreateRequest request)
    {
        try
        {
            var crearPropiedad = await _propertyService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = crearPropiedad.Id }, crearPropiedad);

        }
        catch (System.Exception)
        {
            return StatusCode(500, "La propiedad no ha podido ser creada, no existe el propietario");
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PropertyUpdateRequest request)
    {
        try
        {
            var propiedadAct = await _propertyService.Update(id, request);
            return Ok(propiedadAct);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "La propiedad no ha podido ser actualizada");
        }

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _propertyService.Delete(id);
            return Ok("Propiedad eliminada correctamente");
        }
        catch (System.Exception)
        {
            return StatusCode(500, "La propiedad no ha podido ser eliminada");
        }

    }
    

    [HttpGet("available")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAvailable(
        [FromQuery] string province,
        [FromQuery] DateTime checkIn,
        [FromQuery] DateTime checkOut,
        [FromQuery] int people)
    {
        var checkInDate = DateOnly.FromDateTime(checkIn);
        var checkOutDate = DateOnly.FromDateTime(checkOut);

        var available = await _propertyService.GetAvailableProperties(province, checkInDate, checkOutDate, people);
        return Ok(available);
    }
}
