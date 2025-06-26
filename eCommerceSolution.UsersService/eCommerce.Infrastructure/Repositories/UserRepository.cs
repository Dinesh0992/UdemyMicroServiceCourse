using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public  async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            
            user.UserID =Guid.NewGuid();

            string query = "INSERT INTO" +
                " public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";

            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            
            //SQL query to select  a user  by Email and Password 

            string query = "SELECT * From public.\"Users\" WHERE \"Email\"=@Email AND \"Password\" =@Password";

            var parameters = new { Email = email, Password = password };
          ApplicationUser? user=  await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            /*
            return new ApplicationUser
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName="Person Name",
                Gender=GenderOptions.Male.ToString(),

            };
            */
            return user;

        }
    }
}
