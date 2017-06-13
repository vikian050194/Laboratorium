using System;
using System.Data.Entity;
using System.Security.Claims;
using Laboratorium.DAL.Contexts;
using Laboratorium.Models.DataModels;

namespace Laboratorium.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly DbContext _context;

        private IRepository<AspNetRole> _aspNetRoleRepository;
        private IRepository<AspNetUser> _aspNetUserRepository;
        private IRepository<Claim> _claimRepository;
        
        public UnitOfWork()
        {
            _context = new LaboratoriumContext();
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<AspNetUser> AspNetUserRepository
        {
            get
            {
                if (_aspNetUserRepository == null)
                {
                    _aspNetUserRepository = new GenericRepository<AspNetUser>(_context);
                }
                return _aspNetUserRepository;
            }
        }

        public IRepository<AspNetRole> AspNetRoleRepository
        {
            get
            {
                if (_aspNetRoleRepository == null)
                {
                    _aspNetRoleRepository = new GenericRepository<AspNetRole>(_context);
                }
                return _aspNetRoleRepository;
            }
        }

        public IRepository<Claim> ClaimRepository
        {
            get
            {
                if (_claimRepository == null)
                {
                    _claimRepository = new GenericRepository<Claim>(_context);
                }
                return _claimRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Database.Connection.Dispose();
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}