using GymHubAPI.Entities;
using GymHubAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace GymHubAPI.Services
{

    public interface IUserService
    {
        public void RegisterUser(RegisterUserDto dto); 
    }
    public class UserService : IUserService
    {
        private readonly GymHubDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(GymHubDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;

        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
