using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    [Authorize(Roles = "sysAdmin")]

    public async Task<ActionResult<List<ClientDTO>>> GetAll()
    {
        var client = await _clientService.GetAll();
        return Ok(client);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin")]
    public async Task<ActionResult<ClientDTO>> GetById(int id)
    {
        try
        {
            var client = await _clientService.GetById(id);
            return Ok(client);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "No se pudo crear el cliente");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientCreateRequest request)
    {
        var newClient = await _clientService.Create(request);
        return Ok(newClient);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, client")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClientUpdateRequest request)
    {
        try
        {
            await _clientService.Update(id, request);
            return StatusCode(200, "Se actualizó correctamente");
        }
        catch (System.Exception)
        {

            return StatusCode(500, " No se pudieron actualizar los datos");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _clientService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

            return StatusCode(500, " No se encontro al cliente con ese id");
        }
    }
    
}