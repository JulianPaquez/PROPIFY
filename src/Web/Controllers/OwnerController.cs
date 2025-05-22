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

    public ActionResult<List<OwnerDTO>> GetAll()
    {
        return _ownerService.GetAll();
    }

    [HttpGet("{id}")]
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
    public IActionResult Create([FromBody] OwnerCreateRquest request)
    {
        return Ok(_ownerService.Create(request));
    }

    [HttpPut("{id}")]
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


}