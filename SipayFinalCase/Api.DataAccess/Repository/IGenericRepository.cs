using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        void DeleteById(int id);
        List<Entity> GetAll();
        Entity GetById(int id);
        IQueryable<Entity> GetAllAsQueryable();
        void Save();
    }
}
