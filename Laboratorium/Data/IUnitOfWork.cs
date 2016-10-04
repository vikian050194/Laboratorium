using System;
using System.Security.Claims;
using Laboratorium.Models.DataModels;

namespace Laboratorium.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AspNetUser> AspNetUserRepository { get; }
        IRepository<AspNetRole> AspNetRoleRepository { get; }
        IRepository<Claim> ClaimRepository { get; }

        void Save();
    }
}