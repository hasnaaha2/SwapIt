﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapIt.Models;
using SwapIt.ModelViews.users;
using SwapIt.Repository.Admin;

namespace SwapIt.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _repo.GetUsers();
            if (users == null)
            {
                return null;
            }
            return users;
        }


        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUsersModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repo.AddUserAsync(model);
                if (user != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _repo.GetUserAsync(id);
            if (user != null)
            {
                return user;
            }
            return BadRequest();
        }


        [Route("EditUser")]
        [HttpPut]
        public async Task<ActionResult<User>> EditUser(EditUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _repo.EditUserAsync(model);
            if (user != null)
            {
                return user;
            }
            return BadRequest();
        }



        [Route("DeleteUsers")]
        [HttpPost]
        public async Task <IActionResult> DeleteUsers(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }
            var result= await _repo.DeleteUserAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }


        [Route("GetUserRole")]
        [HttpGet]
        public async Task<IEnumerable<UserRoleModel>> GetUserRole()
        {
            var userRoles = await _repo.GetUserRoleAsync();
            if (userRoles == null)
            {
                return null;
            }
            return userRoles;
        }

        [Route("GetAllRoles")]
        [HttpGet]
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await _repo.GetRolesAsync();
            if (roles == null)
            {
                return null;
            }
            return roles;
        }


        [Route("EditUserRole")]
        [HttpPut]
        public async Task<IActionResult> EditUserRole(EditUserRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var x = await _repo.EditUserRoleAsync(model);
                if (x)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }


        [Route("GetCategories")]
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repo.GetCategoriesAsync();
        }


        [Route("AddCategory")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var cat = await _repo.AddCategoryAsync(model);
            if (cat != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        [Route("EditCategory")]
        [HttpPut]
        public async Task<IActionResult> EditCategory(Category model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var cat = await _repo.EditCategoryAsync(model);
            if (cat != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        [Route("DeleteCategory")]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }
            var result = await _repo.DeleteCategoriesAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
