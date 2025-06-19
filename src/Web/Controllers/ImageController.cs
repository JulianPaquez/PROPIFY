using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly string _pathImage = Path.Combine(
        Directory.GetCurrentDirectory(), "uploadImages");

    private readonly IImageService _imageService;
    private static readonly Random _random = new();
    private const string _chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    private static string RandomName(int length)
    {
        Span<char> random = stackalloc char[length];
        for (var i = 0; i < length; i++)
            random[i] = _chars[_random.Next(_chars.Length)];
        return new string(random);
    }


    [HttpGet("{name}")]

    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<ActionResult<ImageDto>> GetByName(string name)
    {
        try
        {
            var dto = await _imageService.GetByNameAsync(name);

            return dto is not null
                ? Ok(dto)
                : NotFound("Imagen no encontrada");
        }
        catch (Exception)
        {
            return StatusCode(500, "Error inesperado al recuperar la imagen");
        }
    }

    [HttpPost("upload-image")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("No se especificó la imagen");

        if (file.Length > 2000000)
            return BadRequest("El tamaño máximo permitido es de 2 MB");

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        if (!allowed.Contains(extension))
            return BadRequest("Formato de imagen no permitido");

        Directory.CreateDirectory(_pathImage);

        var fileName = $"img_{RandomName(4)}{extension}";
        var path = Path.Combine(_pathImage, fileName);

        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        return Ok(new { Name = fileName, Message = "La imagen se guardó con éxito" });
    }

    [HttpPost]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Create(ImageCreateRequest request)
    {
        var existsLocally = System.IO.File.Exists(Path.Combine(_pathImage, request.Name));
        if (!existsLocally)
            return BadRequest("La imagen que ingresó no existe en el servidor");

        try
        {
            await _imageService.CreateAsync(request);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "La imagen no se pudo registrar en la base de datos");
        }
    }

    [HttpDelete("{name}")]
    [Authorize(Roles = "sysAdmin, owner")]
    public async Task<IActionResult> Delete(string name)
    {
        try
        {
            await _imageService.DeleteAsync(name);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Imagen no se encontro o no se pudo eliminar");
        }
    }
}
