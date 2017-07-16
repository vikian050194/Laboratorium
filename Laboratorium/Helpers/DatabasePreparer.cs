using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Laboratorium.DAL;
using Laboratorium.Models.DataModels;

namespace Laboratorium.Helpers
{
    public class DatabasePreparer
    {
        private readonly LaboratoriumContext _context;

        public DatabasePreparer(LaboratoriumContext context)
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
            foreach (var role in Enum.GetNames(typeof(Role)))
            {
                _context.AspNetRoles.AddOrUpdate(new AspNetRole
                {
                    Id = role,
                    Name = role
                });
            }

            _context.SaveChanges();
        }

        public void AddUsers()
        {
            var adminId = "bfa0792d-cb6f-42a4-924f-df941811e2c4";
            var admin = new AspNetUser
            {
                Id = adminId,
                Email = "admin@yar.ru",
                PasswordHash = "ANgXldJ7cBUpPOxTw//4XeysXHxhqYUGFC8vxaTzBzOQZJZ3RS6ae5gIIZPntWImlQ==",
                SecurityStamp = "48f7dfc8-3657-4e2c-a729-2383f41ed49a",
                UserName = "admin@yar.ru",
                FirstName = @"Кирилл",
                LastName = @"Виноградов",
                Patronymic = @"Андреевич"
            };
            admin.AspNetRoles.Add(_context.AspNetRoles.First(r=>r.Id == Role.Admin.ToString()));
            _context.AspNetUsers.AddOrUpdate(admin);

            var user1Id = "527dd0f0-d88e-4e55-974d-c0dce2370a7a";
            var user1 = new AspNetUser
            {
                Id = user1Id,
                Email = "user1@yar.ru",
                PasswordHash = "AAY75JMaR7GPi4WcT0iVtH6NTG0clQCEDLEDIRDqxU8/33FXr7FIWgmFphQF9VkXtg==",
                SecurityStamp = "5e7b4e3f-8ff0-4cc1-af31-297375eb9990",
                UserName = "user1@yar.ru",
                FirstName = @"User1",
                LastName = @"User1",
                Patronymic = @"User1"
            };
            user1.AspNetRoles.Add(_context.AspNetRoles.First(r => r.Id == Role.User.ToString()));
            _context.AspNetUsers.AddOrUpdate(user1);

            var user2Id = "2136deaa-41bf-46bd-883b-071e743899be";
            var user2 = new AspNetUser
            {
                Id = user2Id,
                Email = "user2@yar.ru",
                PasswordHash = "AM4cMPUrH40VO4L1XD1FGd+yQaHuRpUfg8aYl/Te2AOzypyx4jw8sZ+1DI7DZ5Z7cA==",
                SecurityStamp = "bc921004-6ab1-42d2-aed3-4744cbe4213f",
                UserName = "user2@yar.ru",
                FirstName = @"User2",
                LastName = @"User2",
                Patronymic = @"User2"
            };
            user2.AspNetRoles.Add(_context.AspNetRoles.First(r => r.Id == Role.User.ToString()));
            _context.AspNetUsers.AddOrUpdate(user2);

            _context.SaveChanges();
        }
    }
}