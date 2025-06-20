using System.Threading.Tasks;
using domain.Entities;
using domain.Interfaces;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _repository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IBookingRepository _bookingRepository;

    public PropertyService(IPropertyRepository repository, IOwnerRepository ownerRepository, IBookingRepository bookingRepository)
    {
        _repository = repository;
        _ownerRepository = ownerRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<IEnumerable<PropertyDto>> GetAll()
    {
        var list = await _repository.GetAllAsync();
        return PropertyDto.CreateList(list);
    }

    public async Task<PropertyDto> GetById(int id)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list == null)
        {
            throw new Exception("Propiedad no encontrada");

        }
        return PropertyDto.Create(list);

    }

    public async Task<Property> Create(PropertyCreateRequest request)
    {

        var owner = await _ownerRepository.GetByEmail(request.OwnerEmail);
        if (owner == null)
            throw new Exception("El owner con ese email no existe.");

        var newProperty = new Property(
            request.Type,
            request.SquareMeters,
            request.PricePerNight,
            request.Country,
            request.Province,
            request.City,
            request.Street,
            owner.Id,
            owner,
            request.MaxTenants,
            request.Description,
            request.StateProperty,
            request.Bathroom,
            request.Room,
            request.StreammingPlatform,
            request.Pool
        );

        await _repository.CreateAsync(newProperty);
        return newProperty;
    }

    public async Task<Property> Update(int id, PropertyUpdateRequest request)
    {
        var property = await _repository.GetByIdAsync(id);
        if (property == null)
        {
            throw new Exception("El owner con ese email no existe.");
        }
        property.Type = request.Type;
        property.SquareMeters = request.SquareMeters;
        property.PricePerNight = request.PricePerNight;
        property.Country = request.Country;
        property.Province = request.Province;
        property.City = request.City;
        property.Street = request.Street;
        property.MaxTenants = request.MaxTenants;
        property.Description = request.Description;
        property.StateProperty = request.StateProperty;
        property.Bathroom = request.Bathroom;
        property.Room = request.Room;
        property.StreammingPlatform = request.StreammingPlatform;
        property.Pool = request.Pool;

        await _repository.UpdateAsync(property);
        return property;


    }

    public async Task Delete(int id)
    {
        var property = await _repository.GetByIdAsync(id);
        if (property == null)
        {
            throw new Exception("Propiedad no encontrada");
        }
        await _repository.DeleteAsync(property);
    }
    
    public async Task<List<PropertyDto>> GetAvailableProperties(string province, DateOnly checkIn, DateOnly checkOut, int maxPeople)
{
    var allProperties = await _repository.GetAllAsync(); // Incluye Owner

    // Traer todas las reservas con PropertyId (para filtrar las fechas)
    var allBookings = await _bookingRepository.GetAllAsync();

    // Filtrar propiedades disponibles
    var available = allProperties.Where(prop =>
        prop.Province.ToLower() == province.ToLower() &&
        prop.MaxTenants >= maxPeople &&
        !allBookings.Any(b =>
            b.PropertyId == prop.Id &&
            checkIn < b.CheckOutDate &&
            checkOut > b.CheckInDate // conflicto de fechas
        )
    ).ToList();

    return available.Select(p => PropertyDto.Create(p)).ToList();
}
}