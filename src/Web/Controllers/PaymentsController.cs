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
    public async Task<ActionResult> GetAll()
    {
        var pagos = await _paymentsService.ObtenerTodosLosPagosAsync();
        return Ok(pagos);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var pagos = await _paymentsService.ObtenerPagoPorIdAsync(id);
        return Ok(pagos);
    }

[HttpPost]
public async Task<IActionResult> Create([FromBody] PaymentCreateRequest request)
{
    var pago = await _paymentsService.CrearPagoAsync(request);
    if (pago == null)
        return NotFound($"No existe ninguna reserva con ID {request.ReservaId}.");

    return Ok(pago);
}

    [HttpPut("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaymentUpdateRequest request)
    {
        var actualizado = await _paymentsService.ActualizarPagoAsync(id, request);
        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _paymentsService.EliminarPagoAsync(id);
        return NoContent();
    }
}