using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagement.BusinessLogic.Services.UserService;

namespace SchoolManagement.BusinessLogic.Services
{
    public class UserService : IUserService 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<ApplicationUserDTO>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<ApplicationUserDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userDtos.Add(new ApplicationUserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = _userManager.GetRolesAsync(user).Result,
                    Picture = user.Picture
                });
            }

            return userDtos;
        }

        public async Task<ApplicationUserDTO> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new ApplicationUserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = _userManager.GetRolesAsync(user).Result,
                Picture = user.Picture
            };
        }

        public async Task<bool> UpdateUserAsync(ApplicationUserDTO userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user == null) return false;

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            if (userDto.Picture != null && userDto.Picture.Length > 0)
            {
                user.Picture = userDto.Picture;
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
        public interface IUserService
    {
        Task<IEnumerable<ApplicationUserDTO>> GetAllUsersAsync();
        Task<ApplicationUserDTO> GetUserByIdAsync(string id);
        Task<bool> UpdateUserAsync(ApplicationUserDTO userDto);
        Task<bool> DeleteUserAsync(string id);
    }
}
