using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.User;

namespace LayoutBuilder.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User> {
            new User {Id = 1, Username = "Alex", Email = "alex@gmail.com", Password = "12345678"},
        };

        // ! __________ SIGN UP USER __________
        public async Task<UserResponse<User>> SignUpUser(SignUpUserDto newUser)
        {
            var userResponse = new UserResponse<User>();
            var user = new User();

            var exitsUser = users.FirstOrDefault(p => p.Email == newUser.Email  || p.Username == newUser.Username);

            if (exitsUser is null) {
                user.Id = users.Max(u => u.Id) + 1;

                user.Username = newUser.Username;
                user.Email = newUser.Email;
                user.Password = newUser.Password;

                users.Add(user);

                userResponse.Token = "token";
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

            var user = users.FirstOrDefault(p => p.Email == someUser.Email  && p.Password == someUser.Password);
            if (user is not null)
            {
                userResponse.Data = user;
                userResponse.Token = "token";
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

            var user = users.FirstOrDefault(p => p.Username == username);
            if (user is not null)
            {
                userResponse.Data = user;
                return userResponse;
            } 
            userResponse.Success = false;
            userResponse.Message = "Project Not Found";
            return userResponse;
        }
    }
}