using Api.DataAccess.Models;
using Api.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Saved();

        IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class;

        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Apartment> ApartmentRepository { get; }
        IGenericRepository<Vehicle> VehicleRepository { get; }
        IGenericRepository<Invoice> InvoiceRepository { get; }
    }
}
