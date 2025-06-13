public interface ITaxesService
{
    Task<Taxes> Create(TaxesCreateRequest request);
    Task<TaxesDto> GetById(int id);
    Task<IEnumerable<TaxesDto>> GetAll();
    Task<Taxes> Update(int id, TaxesUpdateRequest request);
    Task Delete(int id);
}