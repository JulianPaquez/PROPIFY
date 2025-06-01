using domain.Entities;

namespace application.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Clasification { get; set; }
        public int IdUser { get; set; }
        public int IdProp { get; set; }
        public string Comment { get; set; }

        public static ReviewDto Create(Review review)
        {
            return new ReviewDto
            {
                Id = review.Id,
                Clasification = review.Clasification,
                IdUser = review.IdUser,
                IdProp = review.IdProp,
                Comment = review.Comment
            };
        }

        public static List<ReviewDto> CreateList(IEnumerable<Review> reviews)
        {
            if (reviews == null || !reviews.Any())
            {
                return null;
            }

            return reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Clasification = r.Clasification,
                IdUser = r.IdUser,
                IdProp = r.IdProp,
                Comment = r.Comment
            }).ToList();
        }
    }
}