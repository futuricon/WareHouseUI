using WareHouse.Models.Repositories;
using System;

namespace WareHouse.Identity
{
    public interface IAuthenticationService
	{
		User AuthenticateUser(string username, string password);
	}

    public class AuthenticationService : IAuthenticationService
    {
        IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User AuthenticateUser(string username, string password)
        {
            var userData = _userRepository.GetUser(username, password);
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return userData;
        }



        //private string CalculateHash(string clearTextPassword, string salt)
        //{
        //    // Convert the salted password to a byte array
        //    byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
        //    // Use the hash algorithm to calculate the hash
        //    HashAlgorithm algorithm = new SHA256Managed();
        //    byte[] hash = algorithm.ComputeHash(saltedHashBytes);
        //    // Return the hash as a base64 encoded string to be compared to the stored password
        //    return Convert.ToBase64String(hash);
        //}


     
    }
}
