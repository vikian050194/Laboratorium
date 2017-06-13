using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Laboratorium.DAL.Contexts;
using Laboratorium.Models.DataModels;

namespace Laboratorium.Helpers
{
    public class DefaultDataHelper
    {
        private readonly LaboratoriumContext _context;

        public DefaultDataHelper(LaboratoriumContext context)
        {
            _context = context;
        }

        public void AddData()
        {
            AddRoles();
            AddUsers();
        }

        private void AddRoles()
        {
            if (_context.AspNetRoles.Any())
            {
                return;
            }

            foreach (var role in Enum.GetNames(typeof(Role)))
            {
                _context.AspNetRoles.AddOrUpdate(r => r.Id, new AspNetRole
                {
                    Id = role,
                    Name = role
                });
            }

            _context.SaveChanges();
        }

        public void AddUsers()
        {
            if (_context.AspNetUsers.Any())
            {
                return;
            }

            var adminId = "bfa0792d-cb6f-42a4-924f-df941811e2c4";
            var admin = new AspNetUser
            {
                Id = adminId,
                Email = "admin@yar.ru",
                PasswordHash = "AIV0o6aKwViOX4VK2cY1+jnBvJGRedB/wDc0BRXvUMjMxxztvKqnZHNUO1OEXqdosg==",
                SecurityStamp = "cc66a735-b00b-4ce0-af9d-a64a3d7e37c4",
                UserName = "admin@yar.ru",
                FirstName = @"Кирилл",
                LastName = @"Виноградов",
                Patronymic = @"Андреевич"
            };
            admin.AspNetRoles.Add(_context.AspNetRoles.First(r=>r.Name == Role.Admin.ToString()));
            _context.AspNetUsers.AddOrUpdate(admin);

            _context.SaveChanges();
        }
    }
}