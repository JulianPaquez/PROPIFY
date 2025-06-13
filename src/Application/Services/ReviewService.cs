using application.DTOs;
using domain.Entities;
using domain.Interfaces;
public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IPropertyRepository _propertyRepository;

    public ReviewService(IReviewRepository repository, IOwnerRepository ownerRepository, IPropertyRepository propertyRepository)
    {
        _repository = repository;
        _ownerRepository = ownerRepository;
        _propertyRepository = propertyRepository;
    }

    public async Task<List<ReviewDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return ReviewDto.CreateList(list);
    }

    public async Task<ReviewDto> GetByIdAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        if (review == null)
            throw new Exception("Reseña no encontrada");

        return ReviewDto.Create(review);
    }

    public async Task CreateAsync(ReviewCreateRequest request, int userId)
{
    var owner = await _ownerRepository.GetByIdAsync(userId);
    if (owner == null)
        throw new Exception("El owner no existe.");

    var property = await _propertyRepository.GetByIdAsync(request.IdProp);
    if (property == null)
        throw new Exception("La propiedad no existe.");

    if (request.Clasification < 1 || request.Clasification > 5)
        throw new Exception("La clasificación debe ser entre 1 y 5.");

    var newReview = new Review(
        request.Clasification,
        userId, // <-- uso userId desde el token, no request.IdUser
        request.IdProp,
        request.Comment
    );

    await _repository.CreateAsync(newReview);
}

    public async Task UpdateAsync(int id, ReviewUpdateRequest request)
    {
        var review = await _repository.GetByIdAsync(id);
        if (review == null)
            throw new Exception("Reseña no encontrada");

        review.Clasification = request.Clasification;
        review.Comment = request.Comment;

        await _repository.UpdateAsync(review);
    }

    public async Task DeleteAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        if (review == null)
            throw new Exception("Reseña no encontrada");

        await _repository.DeleteAsync(review);
    }
}