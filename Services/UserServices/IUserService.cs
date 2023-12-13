using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.User;


namespace LayoutBuilder.Services.UserServices
{
    public interface IUserService
    {
        Task<UserResponse<User>> SignUpUser(SignUpUserDto newUser);
        Task<UserResponse<User>> SignInUser(SignInUserDto someUser);
        Task<UserResponse<User>> GetUserByUsername(string username);
        Task<UserResponse<User>> DeleteUserByUsername(string username);
        Task<UserResponse<User>> UpdateUserByUsername(string username, UpdateUserDto updateUser);
    }
}