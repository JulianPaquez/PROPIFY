using Domain.Exceptions;

public class PaymentsService : IPaymentsService
{
    private readonly IPaymentsRepository _paymentsRepository;

    public PaymentsService(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }

    public async Task<Payments> CrearPagoAsync(PaymentCreateRequest request)
    {
        var pago = new Payments
        {
            // ReservaId = request.ReservaId,
            Amount = request.Amount,
            Taxes = request.Taxes,
            State = PaymentState.Pendiente,
            PaymentMethod = request.PaymentMethod
        };

        await _paymentsRepository.CreateAsync(pago);
        return pago;
    }

     public async Task<PaymentsDto> ObtenerPagoPorIdAsync(int id)
    {
        var pago = await _paymentsRepository.GetByIdAsync(id);
        if (pago == null)
        {
            throw new NotFoundException("Pago no encontrado.");
        }

        return PaymentsDto.Create(pago);
    }

    public async Task<IEnumerable<PaymentsDto>> ObtenerTodosLosPagosAsync()
    {
        var pagos = await _paymentsRepository.GetAllAsync();
        return PaymentsDto.CreateList(pagos);
    }

    public async Task<Payments> ActualizarPagoAsync(int id, PaymentUpdateRequest request)
    {
        var pago = await _paymentsRepository.GetByIdAsync(id);
        if (pago == null)
        {
            throw new NotFoundException("Pago no encontrado.");
        }

        if (!EsEstadoValido(request.State))
        {
            throw new NotAllowedException("Estado inválido.");
        }

        pago.Amount = request.Amount;
        pago.Taxes = request.Taxes;
        pago.State = request.State;
        pago.PaymentMethod = request.PaymentMethod;

        await _paymentsRepository.UpdateAsync(pago);
        return pago;
    }


    public async Task EliminarPagoAsync(int id)
    {
        var pago = await _paymentsRepository.GetByIdAsync(id);
        if (pago == null)
        {
            throw new NotFoundException("Pago no encontrado.");
        }

        await _paymentsRepository.DeleteAsync(pago);
    }
    
    private bool EsEstadoValido(string estado)
    {
        return estado == PaymentState.Pendiente ||
               estado == PaymentState.Pagado ||
               estado == PaymentState.Rechazado;
    }

    
}