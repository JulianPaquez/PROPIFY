using domain.Entities;
using infrastructure.Repositories;
using Infrastructure.Repositories;

public class SysAdminRepository : BaseRepository<SysAdmin>, ISysAdminRepository
{
     public SysAdminRepository(ApplicationContext context) : base(context)
    {
    }
}