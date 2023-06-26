using Business.Abstract;
using Business.ReturnTypes;
using Business.Schema.User;
using Business.Validator;
using DataAccess;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        IUserValidator validator;
        IUserRepository userRepository;

        public UserService(IUserValidator validator, IUserRepository userRepository)
        {
            this.validator = validator;
            this.userRepository = userRepository;
        }

        private string _hashPassword(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes("ECS_USER_PRIVATE_KEY");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }

        private string GenerateJwtToken(string name, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email)
                // Diğer talepleri buraya ekleyebilirsiniz.
            }),
                Expires = DateTime.UtcNow.AddMinutes(Configuration.ExpirationMinutes),
                Issuer = Configuration.Issurer,
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IResult Login(LoginSchema loginSchema)
        {
            var hashedPassword = _hashPassword(loginSchema.Password);
            var user = userRepository.Get(u => u.Email == loginSchema.Email & u.Password == hashedPassword);
            if (user == null)
            {
                return new Result(false, "Email or password is wrond");
            }
            else
            {
                string name = user.Name + " " + user.Surname;
                string token = GenerateJwtToken(name, user.Email);
                var response = new
                {
                    Token = token
                };
                return new DataResult<object>(true, null, response); 
            }
            
        }

        public IResult Register(User user)
        {
            var is_email_exist = userRepository.Get(x => x.Email == user.Email);
            if(is_email_exist == null)
            {
                var isValid = validator.Validate(user);
                if (isValid.IsValid)
                {
                    var hashedPassword = _hashPassword(user.Password);
                    user.Password = hashedPassword;
                    userRepository.Add(user);
                    return new Result(true,null);
                }
                else
                {
                    List<string> errors = new List<string>(); // Initialize the errors list
                    foreach (var err in isValid.Errors)
                    {
                        errors.Add(err.ErrorMessage);
                    }
                    return new DataResult<List<string>>(false, null, errors);

                }
            }
            return new Result(false, "This email is used.");
        }
    }
}
