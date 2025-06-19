using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class OwnerController : ControllerBase
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    

    public async Task<ActionResult<List<OwnerDTO>>> GetAll()
    {
        var owner = await _ownerService.GetAll();
        return Ok(owner);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<OwnerDTO>> GetById(int id)
    {
        try
        {
            var owner = await _ownerService.GetById(id);
            return Ok(owner);
        }
        catch (System.Exception)
        {

            return StatusCode(500, "propietario no encontrado");
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] OwnerCreateRquest request)
    {
        var newOwner = await _ownerService.Create(request);
        return Ok(newOwner);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Update([FromRoute] int id, OwnerUpdateRequest request)
    {
        try
        {
            await _ownerService.Update(id, request);
            return Ok();
        }
        catch (System.Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _ownerService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpPost("login")]
    [Authorize(Roles = "sysAdmin, owner")]
public async Task<ActionResult<OwnerDTO>> Login([FromBody] LoginRequest request)
    {
        var owners = await _ownerService.GetAll();
        var owner = owners.FirstOrDefault(o => o.Email == request.Email && o.Password == request.Password);

        if (owner == null)
        {
            return Unauthorized("Email o contraseña incorrectos.");
        }

        return Ok(owner);
    }


}