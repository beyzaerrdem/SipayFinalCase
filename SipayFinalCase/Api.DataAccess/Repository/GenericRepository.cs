using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly SipayApiDbContext _dbContext;
        public GenericRepository(SipayApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);

        }

        public void DeleteById(int id)
        {
            var entityId = _dbContext.Set<Entity>().Find(id);
            Delete(entityId);
        }

        public List<Entity> GetAll()
        {
            return _dbContext.Set<Entity>().ToList();
        }

        public IQueryable<Entity> GetAllAsQueryable()
        {
            return _dbContext.Set<Entity>().AsQueryable();
        }

        public Entity GetById(int id)
        {
            var entityId = _dbContext.Set<Entity>().Find(id);
            return entityId;
        }

        public void Insert(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity); 
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
