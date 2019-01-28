using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using RolesApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RolesApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"ваша роль: {role}");
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> About( int? select,string color)
        {
            IQueryable<User> users = db.Users.Include(p => p.Role);
            if (select != null && select != 0)
            {
                users = users.Where(p => p.RoleId == select);
            }
            if (!string.IsNullOrEmpty(color))
            {
                users = users.Where(p => p.Color.Contains(color));
            }

            List<Role> roles = db.Roles.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            roles.Insert(0, new Role { Name = "Все", Id = 0 });

            FilterModel viewModel = new FilterModel
            {
                Users = users.ToList(),
                select = new SelectList(roles, "Id", "Name"),
                Color = color
            };
            return View(viewModel);
        

        
        }
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
    }
}