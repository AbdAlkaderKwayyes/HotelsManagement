using Domain.Interfaces;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbSet<T> dbSet;
        protected readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            dbSet = context.Set<T>();
            this.context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }
    }
}
