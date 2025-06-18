using Domain.Entities;
using Domain.Interfaces;
using infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly ApplicationContext _context;
        public ImageRepository(ApplicationContext context) : base(context)
        {
            _context = context;

        }
        public async Task<Image> GetByNameAsync(string name)
        {
            return _context.Set<Image>().FirstOrDefault(i => i.Name == name);
        }
    }
}
