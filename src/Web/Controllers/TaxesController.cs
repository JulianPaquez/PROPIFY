using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TaxesController : ControllerBase
{
    private readonly ITaxesService _taxesService;
    public TaxesController(ITaxesService taxesService)
    {
        _taxesService = taxesService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaxesDto>>> GetAll()
    {
        var taxes = await _taxesService.GetAll();
        return Ok(taxes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaxesDto>> GetById([FromRoute] int id)
    {
        var taxes = await _taxesService.GetById(id);
        return Ok(taxes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaxesCreateRequest request)
    {
        var newTaxes = await _taxesService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = newTaxes.Id }, newTaxes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TaxesUpdateRequest request)
    {
        var updateTax = await _taxesService.Update(id, request);
        return Ok(updateTax);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _taxesService.Delete(id);
        return NoContent();
    }
}