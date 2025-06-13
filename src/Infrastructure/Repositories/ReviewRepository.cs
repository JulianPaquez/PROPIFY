using domain.Entities;
using domain.Interfaces;
using Infrastructure.Repositories;

namespace infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext context) : base(context)
        {
        }


    }
}