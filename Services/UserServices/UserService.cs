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
            DateTime currentDateAndTime = DateTime.Now;

            if (existingUser is null) {
                user.Username = newUser.Username;
                user.Email = newUser.Email;
                user.Password = newUser.Password;

                user.UpdatedAt = currentDateAndTime;
                user.CreatedAt = currentDateAndTime;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                userResponse.Token = new JWTGenerator().GenerateJwtToken(user.Id.ToString());
                userResponse.Message = "User registered successfully";
                userResponse.Data = user;

                return userResponse;   
            } else {
                userResponse.Message = "User is exist, change your username or email address";
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

            var user =  await _context.Users
                .Include(u => u.Collections)
                .Include(u => u.Projects)
                .Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.Username == username);
                
            if (user is not null)
            {
                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "User Not Found";
            return userResponse;
        }

         // ! __________ SHOW PUBLIC PROJECTS __________
          public async  Task<UserResponse<User>> GetUserPublicProjects(string username)
        {
            var userResponse = new UserResponse<User>();

            var user =  await _context.Users.Include(u => u.Collections).Include(u => u.Projects.Where(p=> p.IsPublic == true)).Include(u => u.Comments).FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "User Not Found";
            return userResponse;
        }

        // ! __________ DELETE USER __________
        public async  Task<UserResponse<User>> DeleteUserByUsername(string username, string userId)
        {
            var userResponse = new UserResponse<User>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                if (user.Id == int.Parse(userId)) {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();

                    userResponse.Data = user;
                    return userResponse;
                }
            } 
            userResponse.Success = false;
            userResponse.Message = "User Not Found";
            return userResponse;
        }

        // ! __________ UPDATE USER __________
        public async  Task<UserResponse<User>> UpdateUserByUsername(string username, string userId, UpdateUserDto updateUser)
        {
            var userResponse = new UserResponse<User>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is not null)
            {
                if (user.Id == int.Parse(userId)) {
                    user.Username = updateUser.Username;
                    user.Email = updateUser.Email;
                    user.ImageLink = updateUser.ImageLink;  
                    user.About = updateUser.About;

                    await _context.SaveChangesAsync();

                    userResponse.Data = user;
                    userResponse.Message = "User updated successfully";
                    return userResponse;
                }
            } 
            userResponse.Success = false;
            userResponse.Message = "Project Not Found";
            return userResponse;
        }
    }
}