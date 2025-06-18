using domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
       protected readonly ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {

            return _context.Set<T>().ToList();
        }


        public T? GetById<TId>(TId id)
        {

            return _context.Set<T>().Find(new object[] { id });
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();


        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;

        }

        public T Create(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;


        }
    }
}
