using System;
using System.Linq;
using Laboratorium.DAL;
using Laboratorium.Models.DataModels;

namespace Laboratorium.Helpers
{
    public class DefaultDataHelper
    {
        private readonly IUnitOfWork _uow;

        public DefaultDataHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddData()
        {
            AddRoles();
            AddUsers();
        }

        private void AddRoles()
        {
            if (_uow.AspNetRoleRepository.GetAll().Any())
            {
                return;
            }

            foreach (var role in Enum.GetNames(typeof(Role)))
            {
                _uow.AspNetRoleRepository.Insert(new AspNetRole
                {
                    Id = role,
                    Name = role
                });
            }

            _uow.Save();
        }

        public void AddUsers()
        {
            if (_uow.AspNetUserRepository.GetAll().Any())
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
            admin.AspNetRoles.Add(_uow.AspNetRoleRepository.GetAll().First(r=>r.Name == Role.Admin.ToString()));
            _uow.AspNetUserRepository.Insert(admin);

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
            user1.AspNetRoles.Add(_uow.AspNetRoleRepository.GetAll().First(r => r.Name == Role.User.ToString()));
            _uow.AspNetUserRepository.Insert(user1);

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
            user2.AspNetRoles.Add(_uow.AspNetRoleRepository.GetAll().First(r => r.Name == Role.User.ToString()));
            _uow.AspNetUserRepository.Insert(user2);

            _uow.Save();
        }
    }
}