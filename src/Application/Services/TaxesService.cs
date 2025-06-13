using Domain.Exceptions;
using Domain.Interfaces;

public class TaxesService : ITaxesService
{
    private readonly ITaxesRepository _taxesRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentsRepository _paymentRepository;
    public TaxesService(ITaxesRepository taxesRepository, IUserRepository userRepository, IPaymentsRepository paymentsRepository)
    {
        _taxesRepository = taxesRepository;
        _userRepository = userRepository;
        _paymentRepository = paymentsRepository;
    }

    public async Task<Taxes> Create(TaxesCreateRequest request)
    {
        var payer = await _userRepository.GetByEmail(request.PayerEmail);
        if (payer == null) throw new NotFoundException("El usuario que paga no encontrado.");

        var receiver = await _userRepository.GetByEmail(request.ReceiverEmail);
        if (receiver == null)
            throw new NotFoundException("El usuario que recibe no fue encontrado.");

        var payment = await _paymentRepository.GetByIdAsync(request.PaymentId);
        if (payment == null) throw new NotFoundException("Pago no encontrado.");

        var taxes = new Taxes
        {
            PaymentId = request.PaymentId,
            Payments = payment,
            PaidByUserId = payer.Id,
            PaidByUser = payer,
            ReceiveByUserId = receiver.Id,
            ReceivedByUser = receiver,
            IssueDate = request.IssueData,
            TotalTaxes = request.TotalTaxes,
            DescriptionTaxes = request.DescriptionTaxes,
            PathPDF = request.PathPDF
        };

        await _taxesRepository.CreateAsync(taxes);
        return taxes;
    }

    public async Task<TaxesDto> GetById(int id)
    {
        var tax = await _taxesRepository.GetByIdWithUsersAsync(id);
        if (tax == null)
        {
            throw new NotFoundException("Impuesto no encontrado");
        }

        return TaxesDto.Create(tax);
    }

    public async Task<IEnumerable<TaxesDto>> GetAll()
    {
        var tax = await _taxesRepository.GetAllWithUsersAsync();
        return TaxesDto.CreateList(tax);
    }

    public async Task<Taxes> Update(int id, TaxesUpdateRequest request)
    {
        var taxes = await _taxesRepository.GetByIdWithUsersAsync(id);
        if (taxes == null)
        {
            throw new NotFoundException("No se encontró el registro de impuestos a actualizar.");
        }

        taxes.TotalTaxes = request.TotalTaxes;
        taxes.DescriptionTaxes = request.DescriptionTaxes;
        taxes.PathPDF = request.PathPDF;

        await _taxesRepository.UpdateAsync(taxes);
        return taxes;
    }

    public async Task Delete(int id)
    {
        var tax = await _taxesRepository.GetByIdAsync(id);
        if (tax == null)
        {
            throw new NotFoundException("Impuesto no encontrado.");
        }

        await _taxesRepository.DeleteAsync(tax);
    }
}