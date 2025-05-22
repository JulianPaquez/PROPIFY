using domain.Entities;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;

    public OwnerService(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    public Owner Create(OwnerCreateRquest request)
    {
        var newOwner = new Owner(request.Name, request.Surname, request.Email, request.Password, request.NumberPhone, request.DocumentType, request.Dni, request.Cvu);
        _ownerRepository.Create(newOwner);
        return newOwner;
    }


    public void Update(int id, OwnerUpdateRequest request)
    {
        var owner = _ownerRepository.GetById(id);
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

        _ownerRepository.Update(owner);
    }

    public OwnerDTO GetById(int id)
    {
        var owner = _ownerRepository.GetById(id);
        if (owner == null)
        {
            throw new Exception("Propietario no encontrado");
        }

        return new OwnerDTO
        {
            Id = owner.Id,
            Name = owner.Name,
            Surname = owner.Surname,
            Email = owner.Email,
            Password = owner.Password,
            NumberPhone = owner.NumberPhone,
            DocumentType = owner.DocumentType,
            Dni = owner.Dni,
            Cvu = owner.Cvu,
        };
    }

    public List<OwnerDTO> GetAll()
    {
        var list = _ownerRepository.GetAll();
        return OwnerDTO.CreateList(list);
    }

    public void Delete(int id)
    {
        var owner = _ownerRepository.GetById(id);
        if (owner == null)
        {
            throw new Exception("Propietario no encontrado");
        }

        _ownerRepository.Delete(owner);
    }

}