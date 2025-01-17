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


        [Route("GetSubCategories")]
        [HttpGet]
        public async Task<IEnumerable<CategoryDepartment>> GetSubCategories()
        {
            return await _repo.GetSubCategoriesAsync();
        }

        [Route("AddSubCategory")]
        [HttpPost]
        public async Task<IActionResult> AddSubCategory(CategoryDepartment model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var cat = await _repo.AddSubCategoryAsync(model);
            if (cat != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        [Route("EditSubCategory")]
        [HttpPut]
        public async Task<IActionResult> EditSubCategory(CategoryDepartment model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var cat = await _repo.EditSubCategoryAsync(model);
            if (cat != null)
            {
                return Ok();
            }
            return BadRequest();
        }


        [Route("DeleteSubCategory")]
        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }
            var result = await _repo.DeleteSubCategoryAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            var products = await _repo.GetAllProductsAsync();
            
            if(products!=null)
            {
               return products;
            }
           return null;
        }


        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct()
        {

            var departmentId = HttpContext.Request.Form["departmentId"].ToString();
            var productName = HttpContext.Request.Form["productName"].ToString();
            var productDescription = HttpContext.Request.Form["productDescription"].ToString();
            var productPrice = HttpContext.Request.Form["productPrice"].ToString();
            var productQuantity = HttpContext.Request.Form["productQuantity"].ToString();



            if (!string.IsNullOrEmpty(departmentId)&& 
                !string.IsNullOrEmpty(productName) &&
                !string.IsNullOrEmpty(productDescription) &&
                !string.IsNullOrEmpty(productPrice) &&
                !string.IsNullOrEmpty(productQuantity))
            {
                var result = await _repo.AddProductAsync(departmentId, productName, productDescription, productPrice, productQuantity);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }



        [Route("GetProduct/{id}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            if (id > 0)
            {
                var movie = await _repo.GetProductAsync(id);
                if (movie != null)
                {
                    return movie;
                }
            }
            return BadRequest();
        }

        [Route("EditProduct")]
        [HttpPut]
        public async Task<IActionResult> EditProduct()
        {
            var departmentId = HttpContext.Request.Form["departmentId"].ToString();
            var productName = HttpContext.Request.Form["productName"].ToString();
            var productDescription = HttpContext.Request.Form["productDescription"].ToString();
            var productPrice = HttpContext.Request.Form["productPrice"].ToString();
            var productQuantity = HttpContext.Request.Form["productQuantity"].ToString();


            if (!string.IsNullOrEmpty(departmentId) &&
                !string.IsNullOrEmpty(productName) &&
                !string.IsNullOrEmpty(productDescription) &&
                !string.IsNullOrEmpty(productPrice) &&
                !string.IsNullOrEmpty(productQuantity))
            {
                var product = new Product
                {
                    DepartmentId=int.Parse(departmentId),
                    ProductName = productName,
                    ProductDescription = productDescription,
                    ProductPrice = short.Parse(productPrice),
                    ProductQuantity = short.Parse(productQuantity),
                };
                var result = await _repo.EditProductAsync(product);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }


        [Route("SearchProducts/{search}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct(string search)
        {
            if (search == null || string.IsNullOrEmpty(search))
            {
                return null;
            }

            return await _repo.SearchProductsAsync(search);
        }

        [Route("DeleteAllProducts")]
        [HttpPost]
        public async Task<IActionResult> DeleteAllProducts(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }

            var result = await _repo.DeleteProductsAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }


        // Added

        [Route("GetHomeProducts")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetHomeProducts()
        {
            var products = await _repo.GetHomeProducts();
            if (products == null)
            {
                return null;
            }
            return products;

        }

        [Route("GetProfileProductsByEmail/{email}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProfileProductsByEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            var products = await _repo.GetProfileProductsByEmailAsync(email);
            if (products != null)
            {
                return products;
            }
            return null;
        }

        [Route("GetFavProductsByEmail/{email}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetFavProductsByEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            var products = await _repo.GetFavProductsByEmailAsync(email);
            if (products != null)
            {
                return products;
            }
            return null;
        }

        [Route("GetCartProductsByEmail/{email}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetCartProductsByEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            var products = await _repo.GetCartProductsByEmailAsync(email);
            if (products != null)
            {
                return products;
            }
            return null;
        }

        [Route("GetHomeCategories")]
        [HttpGet]
        public async Task<IEnumerable<Category>> GetHomeCategories()
        {
            var categories = await _repo.GetCategoriesHomeAsync();
            if (categories == null)
            {
                return null;
            }
            return categories;

        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<bool> AddToCart(Product product)
        {
            if (ModelState.IsValid)
            {
                var p = await _repo.AddToCartAsync(product);
                if (p != false)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("AddToFav")]
        [HttpPost]
        public async Task<bool> AddToFav(Product product)
        {
            if (ModelState.IsValid)
            {
                var p = await _repo.AddToFavAsync(product);
                if (p != false)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("RemoveFromCart/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var product = await _repo.RemoveFromCartAsync(id);
            if (product != null)
            {
                return Ok();
            }
            return BadRequest();

        }

        [Route("RemoveFromFav/{id}")]
        [HttpGet]
        public async Task<IActionResult> RemoveFromFav(int id)
        {
            var product = await _repo.RemoveFromFavAsync(id);
            if (product != null)
            {
                return Ok();
            }
            return BadRequest();

        }

        [Route("RemoveProductFromAllFiles/{productName}")]
        [HttpGet]
        public async Task<IActionResult> RemoveProductFromAllFiles(string productName)
        {
            var product = await _repo.RemoveProductFromAllFilesAsync(productName);
            if (product != null)
            {
                return Ok();
            }
            return BadRequest();

        }


        [Route("GetAllContacts")]
        [HttpGet]
        public async Task<IEnumerable<Chat>> GetAllContacts()
        {

            var contacts = await _repo.GetAllContactsAsync();

            if (contacts != null)
            {
                return contacts;
            }
            return null;
        }


        [Route("GetDepartmentsById/{id}")]
        [HttpGet]
        public async Task<IEnumerable<CategoryDepartment>> GetDepartmentsById(int id)
        {

            var departments = await _repo.GetDepartmentsByIdAsync(id);
            if (departments != null)
            {
                return departments;
            }
            return null;
        }

        [Route("GetHomeProductsByDepartmentId/{id}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetHomeProductsByDepartmentId(int id)
        {

            var products = await _repo.GetHomeProductsByDepartmentIdAsync(id);
            if (products != null)
            {
                return products;
            }
            return null;
        }
        [Route("GetProductsByTwoIds/{idEncrypted}")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProfileProductsByEmail(int idEncrypted)
        {

            var products = await _repo.GetProfileProductsByEmailAsync(idEncrypted);
            if (products != null)
            {
                return products;
            }
            return null;
        }





    }
}

