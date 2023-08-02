using Api.DataAccess.Models;
using Api.DataAccess.Repository;

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
        IGenericRepository<UserLogin> UserLoginRepository { get; }
    }
}
