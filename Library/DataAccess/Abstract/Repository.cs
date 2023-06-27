using DataAccess.Context;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public abstract class Repository<Entity>:IRepository<Entity> where Entity : BaseEntity
    {
        private readonly LibraryDbContext _dbContext;

        protected Repository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<Entity> Table => _dbContext.Set<Entity>();
        public void Add(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public Entity Get(Expression<Func<Entity, bool>> predicate)
        {
            return _dbContext.Set<Entity>().Where(predicate).FirstOrDefault();
        }

        public List<Entity> GetAll(Expression<Func<Entity, bool>>? predicate = null)
        {
            return predicate == null ? _dbContext.Set<Entity>().ToList() : _dbContext.Set<Entity>().Where(predicate).ToList();
        }
        public IQueryable<Entity> GetAllIQueryalbe(Expression<Func<Entity, bool>>? predicate = null)
        {
            return predicate == null ? _dbContext.Set<Entity>() : _dbContext.Set<Entity>().Where(predicate);
        }

        public void Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Entity> GetAllIncluding(params Expression<Func<Entity, object>>[] includeProperties)
        {
            IQueryable<Entity> query = _dbContext.Set<Entity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }
    }
}
