using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAhmet.Business.Abstract;
using BlogAhmet.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAhmet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.Get(id);
        }


        [HttpGet]
        [Route("header/{categoryname}")]
        public IEnumerable<Category> GetByArticle(string categoryname)
        {
            return _categoryService.GetCategoriesByName(categoryname);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

            }

            return BadRequest();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            try
            {
                category.CategoryId = id;
                _categoryService.Update(category);
                return Ok(category);
            }
            catch (Exception)
            {

            }

            return BadRequest();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(new Category { CategoryId = id });
                return Ok();
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }


    }
}