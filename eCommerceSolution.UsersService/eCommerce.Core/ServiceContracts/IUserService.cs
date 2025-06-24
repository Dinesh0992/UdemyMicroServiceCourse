using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        /// <summary>
        /// Method to handle user  login use case 
        /// and returns  an Authentication Response object
        /// that contains status of login request.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        /// Method to handle user  register use case 
        /// and returns  an Authentication Response object
        /// that contains status of register request.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
