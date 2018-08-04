using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPM.Core.Interfaces;
using SPM.Core.Models;

namespace SPM.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAsyncRepository<ProductCategory> _categoryRepository;

        public CategoryController(IAsyncRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get api/category
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return Ok(category);
        }

    }
}