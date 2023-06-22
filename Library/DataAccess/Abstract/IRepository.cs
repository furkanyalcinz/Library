using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        public void Add(Entity entity);
        public void Update(Entity entity);
        public void Delete(Entity entity);
        public Entity Get(Expression<Func<Entity, bool>> predicate);
        public List<Entity> GetAll(Expression<Func<Entity, bool>>? predicate = null);
        public IQueryable<Entity> GetAllIQueryalbe(Expression<Func<Entity, bool>>? predicate = null);

    }
}
