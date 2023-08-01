using Api.DataAccess.Models;
using Api.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Api.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SipayApiDbContext _context;
        public UnitOfWork(SipayApiDbContext context)
        {
            _context = context;

            UserRepository = new GenericRepository<User>(_context);
            ApartmentRepository = new GenericRepository<Apartment>(_context);
            VehicleRepository = new GenericRepository<Vehicle>(_context);
            InvoiceRepository = new GenericRepository<Invoice>(_context);
        }

        public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class
        {
            return new GenericRepository<Entity>(_context);
        }

        public void Saved()
        {
            _context.SaveChanges();
        }

        public IGenericRepository<User> UserRepository { get; private set; }

        public IGenericRepository<Apartment> ApartmentRepository { get; private set; }

        public IGenericRepository<Vehicle> VehicleRepository { get; private set; }

        public IGenericRepository<Invoice> InvoiceRepository { get; private set; }


    }
}
