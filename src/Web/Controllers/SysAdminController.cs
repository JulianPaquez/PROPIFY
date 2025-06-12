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

    public async Task<ActionResult<List<SysAdminDto>>> GetAll()
    {
        var sysAdmin = await _sysAdminService.GetAll();
        return Ok(sysAdmin);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SysAdminDto>> GetById(int id)
    {
        try
        {
            var sysAdmin = await _sysAdminService.GetById(id);
            return Ok(sysAdmin);
        }
        catch (System.Exception)
        {

            return StatusCode(500, "No se pudo crear el sysadmin");
        }
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody] SysAdminCreateRequest request)
    {
        var newSysAdmin = await _sysAdminService.Create(request);
        return Ok(newSysAdmin);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, [FromBody] SysAdminUpdateRequest request)
    {
        try
        {
            await _sysAdminService.Update(id, request);
            return StatusCode(200, "Se actualizó correctamente");
        }
        catch (System.Exception)
        {

            return StatusCode(500, " No se pudieron actualizar los datos");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _sysAdminService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

             return StatusCode(500, " No se encontro al sysadmin con ese id");;
        }
    }


}