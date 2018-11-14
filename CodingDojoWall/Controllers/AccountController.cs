using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingDojoWall.Models;
using CodingDojoWall.Models.Entities;
using CodingDojoWall.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodingDojoWall.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Login cannot be empty");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "How did you do that?");
                return View(model);
            }

            var dbUser = context.Users.FirstOrDefault(u => u.Email.ToUpper() == model.Email.ToUpper());

            if (dbUser == null)
            {
                ModelState.AddModelError("", "Invalid Email/Password");
                return View(model);
            }

            // Hash the user's password
            PasswordHasher<LoginViewModel> Hasher = new PasswordHasher<LoginViewModel>();
            var result = Hasher.VerifyHashedPassword(model, dbUser.Password, model.Password);

            if (result == 0)
            {
                // Failed to login
                ModelState.AddModelError("", "Invalid Email/Password");
                return View(model);
            }

            return RedirectToAction("About", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Registration cannot be empty");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Password = model.Password,
                Email = model.Email
            };

            // Hash the user's password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);

            // Save user to the db
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("About", "Home");
        }
    }
}