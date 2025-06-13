using domain.Interfaces;

public interface ITaxesRepository : IBaseRepository<Taxes>
{
    Task<Taxes?> GetByIdWithUsersAsync(int id);
    Task<List<Taxes>> GetAllWithUsersAsync();
}