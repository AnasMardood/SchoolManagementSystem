using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                if (userDto.PictureFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await userDto.PictureFile.CopyToAsync(memoryStream);
                        userDto.Picture = memoryStream.ToArray();
                    }
                }
                var result = await _userService.UpdateUserAsync(userDto);
                if (result) return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", "Failed to update user.");
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
            }
            return View(userDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to delete user.");
            return RedirectToAction(nameof(Index));
        }
    }
}