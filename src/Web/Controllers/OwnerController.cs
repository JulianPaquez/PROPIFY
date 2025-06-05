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
    [Authorize(Roles = "sysAdmin")]

    public ActionResult<List<OwnerDTO>> GetAll()
    {
        return _ownerService.GetAll();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin")]
    public ActionResult<OwnerDTO> GetById(int id)
    {
        try
        {
            return _ownerService.GetById(id);
        }
        catch (System.Exception)
        {

            return StatusCode(500, "propietario no encontrado");
        }
    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, owner")]
    public IActionResult Create([FromBody] OwnerCreateRquest request)
    {
        return Ok(_ownerService.Create(request));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public IActionResult Update([FromRoute] int id, OwnerUpdateRequest request)
    {
        try
        {
            _ownerService.Update(id, request);
            return Ok();
        }
        catch (System.Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public IActionResult Delete(int id)
    {
        try
        {
            _ownerService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpPost("login")]
    [Authorize(Roles = "sysAdmin, owner")]
public ActionResult<OwnerDTO> Login([FromBody] LoginRequest request)
    {
        var owner = _ownerService.GetAll().FirstOrDefault(o => o.Email == request.Email && o.Password == request.Password);

        if (owner == null)
        {
            return Unauthorized("Email o contraseña incorrectos.");
        }

        return Ok(owner);
    }


}