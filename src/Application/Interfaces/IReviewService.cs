using application.DTOs;


namespace application.Interfaces
{
public interface IReviewService
{
    List<ReviewDto> GetAll();
    ReviewDto GetById(int id);
    void Create(ReviewCreateRequest request);
    void Update(int id, ReviewUpdateRequest request);
    void Delete(int id);
}
}