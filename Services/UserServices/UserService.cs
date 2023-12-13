using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.User;
using Microsoft.EntityFrameworkCore;
using LayoutBuilder.Utils;

namespace LayoutBuilder.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

         public UserService(DataContext context)
        {
            _context = context;
        }


        // ! __________ SIGN UP USER __________
        public async Task<UserResponse<User>> SignUpUser(SignUpUserDto newUser)
        {
            var userResponse = new UserResponse<User>();
            var user = new User();

             var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email || u.Username == newUser.Username);

            if (existingUser is null) {
                user.Username = newUser.Username;
                user.Email = newUser.Email;
                user.Password = newUser.Password;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                userResponse.Token = new JWTGenerator().GenerateJwtToken(user.Id.ToString());
                userResponse.Message = "User registered successfully";
                userResponse.Data = user;

                return userResponse;   
            } else {
                userResponse.Message = "User is exist";
                userResponse.Success = false;
                return userResponse;   
            }
        }

        // ! __________ SIGN IN USER __________
        public async  Task<UserResponse<User>> SignInUser(SignInUserDto someUser)
        {
            var userResponse = new UserResponse<User>();

             var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == someUser.Email && u.Password == someUser.Password);
            if (user is not null)
            {
                userResponse.Data = user;
                    userResponse.Token = new JWTGenerator().GenerateJwtToken(user.Id.ToString());
                userResponse.Message = "User logged successfully";
                return userResponse;
            } 

            userResponse.Success = false;
            userResponse.Message = "Email or Password is incorrect";
            return userResponse;
        }

        // ! __________ SHOW USER __________
          public async  Task<UserResponse<User>> GetUserByUsername(string username)
        {
            var userResponse = new UserResponse<User>();

             var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "Project Not Found";
            return userResponse;
        }

        // ! __________ DELETE USER __________
        public async  Task<UserResponse<User>> DeleteUserByUsername(string username)
        {
            var userResponse = new UserResponse<User>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "Project Not Found";
            return userResponse;
        }

        // ! __________ UPDATE USER __________
        public async  Task<UserResponse<User>> UpdateUserByUsername(string username, UpdateUserDto updateUser)
        {
            var userResponse = new UserResponse<User>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                user.ImageLink = updateUser.ImageLink;  
                user.About = updateUser.About;

                await _context.SaveChangesAsync();

                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "Project Not Found";
            return userResponse;
        }
    }
}