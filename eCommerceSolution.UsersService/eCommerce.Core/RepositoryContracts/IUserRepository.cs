
using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;


public interface IUserRepository
{
    /// <summary>
    /// Medthod to add a user to the data  store  and return  the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    /// <summary>
    /// Method to retrieve the existing user by their email and password 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password); 
   
}
