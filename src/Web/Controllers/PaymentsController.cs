using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentsService _paymentsService;

    public PaymentsController(IPaymentsService paymentsService)
    {
        _paymentsService = paymentsService;
    }

    [HttpGet]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<ActionResult> GetAll()
    {
        var pagos = await _paymentsService.ObtenerTodosLosPagosAsync();
        return Ok(pagos);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]

    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var pagos = await _paymentsService.ObtenerPagoPorIdAsync(id);
        return Ok(pagos);
    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Create([FromBody] PaymentCreateRequest request)
    {
        var nuevoPago = await _paymentsService.CrearPagoAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = nuevoPago.Id }, nuevoPago);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaymentUpdateRequest request)
    {
        var actualizado = await _paymentsService.ActualizarPagoAsync(id, request);
        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "sysAdmin, client, owner")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _paymentsService.EliminarPagoAsync(id);
        return NoContent();
    }
}