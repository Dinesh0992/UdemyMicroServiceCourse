using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public  async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            await Task.Delay(1);
            user.UserID =Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            await Task.Delay(1);
            return new ApplicationUser
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName="Person Name",
                Gender=GenderOptions.Male.ToString(),

            };

        }
    }
}
