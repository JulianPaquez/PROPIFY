public interface IPaymentsService
{
    Task<Payments> CrearPagoAsync(PaymentCreateRequest request);
    Task<PaymentsDto> ObtenerPagoPorIdAsync(int id);
    Task<IEnumerable<PaymentsDto>> ObtenerTodosLosPagosAsync();
    Task<Payments> ActualizarPagoAsync(int id, PaymentUpdateRequest request);
    Task EliminarPagoAsync(int id);
}