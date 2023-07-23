﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels.Accounts;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                EmailConfirmed = u.EmailConfirmed,
            }).ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }

            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                SelectedRoles = await _userManager.GetRolesAsync(user),
                Roles = _roleManager.Roles.Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList()
            };
            return View(userUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(userUpdateViewModel.Id);
                if (user == null) { return NotFound(); }
                user.FirstName = userUpdateViewModel.FirstName;
                user.LastName = userUpdateViewModel.LastName;
                user.UserName = userUpdateViewModel.UserName;
                user.Email = userUpdateViewModel.Email;
                user.EmailConfirmed = userUpdateViewModel.EmailConfirmed;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) { return NotFound(); }

                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.AddToRolesAsync(
                    user,
                    userUpdateViewModel.SelectedRoles.Except(userRoles).ToList<string>());

                await _userManager.RemoveFromRolesAsync(
                    user,
                    userRoles.Except(userUpdateViewModel.SelectedRoles).ToList<string>());

                return RedirectToAction("Index", "Users");
            }
            userUpdateViewModel.Roles = _roleManager.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            return View(userUpdateViewModel);
        }
        public async Task<IActionResult> ConfirmEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Users");
        }
        public async Task<IActionResult> Delete(string id)
        {
            User deletedUser = await _userManager.FindByIdAsync(id);
            if (deletedUser != null)
            {
                await _userManager.DeleteAsync(deletedUser);
            }
            return RedirectToAction("Index");
        }
    }
}
