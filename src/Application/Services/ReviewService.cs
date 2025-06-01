using application.DTOs;
using application.Interfaces;
using domain.Entities;
using domain.Interfaces;

namespace application.Services
{
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

        public List<ReviewDto> GetAll()
        {
            var list = _repository.GetAll();
            return ReviewDto.CreateList(list);
        }

        public ReviewDto GetById(int id)
        {
            var review = _repository.GetById(id);
            if (review == null)
                throw new Exception("Reseña no encontrada");

            return ReviewDto.Create(review);
        }

       public void Create(ReviewCreateRequest request)
{
    var owner = _ownerRepository.GetById(request.IdUser);
    if (owner == null)
        throw new Exception("El owner no existe.");

    var property = _propertyRepository.GetById(request.IdProp);
    if (property == null)
        throw new Exception("La propiedad no existe.");

    var newReview = new Review(
        request.Clasification,
        request.IdUser,
        request.IdProp,
        request.Comment
    );

     _repository.Create(newReview); 
}

        public void Update(int id, ReviewUpdateRequest request)
        {
            var review = _repository.GetById(id);
            if (review == null)
                throw new Exception("Reseña no encontrada");

            review.Clasification = request.Clasification;
            review.Comment = request.Comment;

            _repository.Update(review); 
        }

        public void Delete(int id)
        {
            var review = _repository.GetById(id);
            if (review == null)
                throw new Exception("Reseña no encontrada");

            _repository.Delete(review);
        }
    }
}
