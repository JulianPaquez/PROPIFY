using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]

public class SysAdminController : ControllerBase
{
    private readonly ISysAdminService _sysAdminService;

    public SysAdminController(ISysAdminService sysAdminService)
    {
        _sysAdminService = sysAdminService;
    }

    [HttpGet]

    public ActionResult<List<SysAdminDto>> GetAll()
    {
        return _sysAdminService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<SysAdminDto> GetById(int id)
    {
        try
        {
            return _sysAdminService.GetById(id);
        }
        catch (System.Exception)
        {

            return StatusCode(500, "No se pudo crear el sysadmin");
        }
    }

    [HttpPost]

    public IActionResult Create([FromBody] SysAdminCreateRequest request)
    {
         return Ok(_sysAdminService.Create(request));
    }

    [HttpPut("{id}")]

    public IActionResult Update(int id, [FromBody] SysAdminUpdateRequest request)
    {
        try
        {
            _sysAdminService.Update(id, request);
            return StatusCode(200, "Se actualizó correctamente");
        }
        catch (System.Exception)
        {

            return StatusCode(500, " No se pudieron actualizar los datos");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _sysAdminService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

             return StatusCode(500, " No se encontro al sysadmin con ese id");;
        }
    }


}