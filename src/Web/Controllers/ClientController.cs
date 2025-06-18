using application.Interfaces;
using Application.Models;
using Application.Models.Request;
using domain.Entities;
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

    public ActionResult<List<ClientDTO>> GetAll()
    {
        var clients = _clientService.GetAll();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public ActionResult<ClientDTO> GetById(int id)
    {
        var client =  _clientService.GetById(id);
        if (client == null)
        {
            return NotFound("Admin not found");
        }
        return Ok(client);
    }

    [HttpPost]
    public ActionResult Create([FromBody] AddClientRequest request)
    {
        return Ok(_clientService.Create(request));
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, AddClientRequest request)
    {
        try
        {
            _clientService.Update(id, request);
            return Ok();
        }
        catch (Exception)
        {

            return StatusCode(500, "Propietario no encontrado");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        Client client = await _clientService.GetById(id);
        if(client != null)
        {
            _clientService.Delete(client);
            return Ok();
        }
        return StatusCode(500, "Propietario no encontrado");
    }


}