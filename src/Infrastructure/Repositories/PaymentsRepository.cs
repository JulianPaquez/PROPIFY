using infrastructure.Repositories;
using Infrastructure.Repositories;

public class PaymentsRepository : BaseRepository<Payments>, IPaymentsRepository
{
    public PaymentsRepository(ApplicationContext context) : base(context)
    {
    }
}