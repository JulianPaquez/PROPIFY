using domain.Entities;
using Domain.Exceptions;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;

    public OwnerService(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    public async Task<Owner>Create(OwnerCreateRquest request)
    {
        var newOwner = new Owner(request.Name, request.Surname, request.Email, request.Password, request.NumberPhone, request.DocumentType, request.Dni, request.Cvu);
        await _ownerRepository.CreateAsync(newOwner);
        return newOwner;
    }


    public async Task<Owner> Update(int id, OwnerUpdateRequest request)
    {
        var owner = await _ownerRepository.GetByIdAsync(id);
        if (owner == null)
        {
            throw new Exception("Propietario no encontrado");
        }

        owner.Name = request.Name;
        owner.Surname = request.Surname;
        owner.Email = request.Email;
        owner.Password = request.Password;
        owner.NumberPhone = request.NumberPhone;
        owner.Cvu = request.Cvu;

        await _ownerRepository.UpdateAsync(owner);
        return owner;
    }

    public async Task<OwnerDTO> GetById(int id)
    {
         var owner = await _ownerRepository.GetByIdAsync(id);
        if (owner == null)
        {
            throw new NotFoundException("Propietario no encontrado.");
        }

        return OwnerDTO.Create(owner);
    }

    public async Task<IEnumerable<OwnerDTO>> GetAll()
    {
        var list = await _ownerRepository.GetAllAsync();
        return OwnerDTO.CreateList(list);
    }

    public async Task Delete(int id)
    {
        var owner = await _ownerRepository.GetByIdAsync(id);
        if (owner == null)
        {
            throw new Exception("Propietario no encontrado");
        }

        await _ownerRepository.DeleteAsync(owner);
    }

}