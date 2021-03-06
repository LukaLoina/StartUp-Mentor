﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;

namespace StartUpMentor.UI.Controllers
{
    public class UserController : Controller
    {
        protected IUserService Service { get; private set; }
        protected IFieldService FieldService { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        protected UserManager<ApplicationUser> UserManager { get; private set; }

        public UserController(IUserService service, RoleManager<IdentityRole> roleManager)
        {
            Service = service;
            RoleManager = roleManager;
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new StartUpMentor.DAL.ApplicationDbContext()));
        }

        // GET: User
        public async Task<ActionResult> Index(ApplicationUser user, int? id)
        {
            try
            {
                //Get all users from database
                return View(await UserManager.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Register()
        {
            //Get all fields for display in view
            ViewBag.Field = await FieldService.GetRangeAsync(null);
            //Get all roles
            ViewBag.Roles = await RoleManager.Roles.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model, UserViewModel user, string roleId)
        {
            if (ModelState.IsValid)
            {
                user.Info = new InfoViewModel { FirstName = model.FirstName, LastName = model.LastName, Contact = model.Contact };

                bool adminResult = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.Common.IApplicationUser>(user), model.Password);

                if (adminResult)
                {
                    if (!String.IsNullOrEmpty(roleId))
                    {
                        var role = await RoleManager.FindByIdAsync(roleId);
                        var result = await UserManager.AddToRoleAsync(user.Id, role.Name);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            //Get all fields for display in view
                            ViewBag.Field = await FieldService.GetRangeAsync(null);
                            //Get all roles
                            ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                            return View();
                        }
                    }
                }
                else
                {
                    //Get all fields for display in view
                    ViewBag.Field = await FieldService.GetRangeAsync(null);
                    //Get all roles
                    ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                //Get all fields for display in view
                ViewBag.Field = await FieldService.GetRangeAsync(null);
                //Get all roles
                ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                return View();
            }
        }
    }
}