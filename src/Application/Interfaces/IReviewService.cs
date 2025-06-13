using application.DTOs;

public interface IReviewService
{
    Task<List<ReviewDto>> GetAllAsync();
    Task<ReviewDto> GetByIdAsync(int id);
    Task CreateAsync(ReviewCreateRequest request, int userId);
    Task UpdateAsync(int id, ReviewUpdateRequest request);
    Task DeleteAsync(int id);
}