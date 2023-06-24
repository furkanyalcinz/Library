using Business.Abstract;
using Business.Schema.User;
using Entity.Concrete;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private string _hashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
        public void Login(LoginSchema loginSchema)
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            
        }
    }
}
