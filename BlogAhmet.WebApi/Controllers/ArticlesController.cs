using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAhmet.Business.Abstract;
using BlogAhmet.Business.Utilities;
using BlogAhmet.Entities.Concrete;
using BlogAhmet.WebApi.Dtos;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlogAhmet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private IArticleService _articleService;
        private IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public ArticlesController(IArticleService articleService, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _articleService = articleService;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(_cloudinaryConfig.Value.CloudName, _cloudinaryConfig.Value.ApiKey, cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _articleService.GetAll();
        }

        [HttpGet("{id}")]
        public Article Get(int id)
        {
            return _articleService.Get(id);
        }


        [HttpGet]
        [Route("header/{articleheader}")]
        public IEnumerable<Article> GetByArticle(string articleheader)
        {
            
            return _articleService.GetArticlesByArticleName(articleheader);
        }

        [HttpGet]
        [Route("category/{categoryid}")]
        public IEnumerable<Article> GetByCategory(int categoryid)
        {

            return _articleService.GetArticlesByCategory(categoryid);
        }




        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Article article)
        {
            try
            {
                

                _articleService.Add(article);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {
                
            }

            return BadRequest();
        }



        [HttpPost("photo/{articleid}")]
        public IActionResult UploadPhoto(int articleid, [FromBody] PhotoForCreationDto photoForCreationDto)
        {
            try
            {
                var file = photoForCreationDto.File;

                var uploadResult = new ImageUploadResult();

                if (file.Length > 0)
                {

                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name, stream)
                        };

                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }


                photoForCreationDto.Url = uploadResult.Uri.ToString();
                photoForCreationDto.PublicId = uploadResult.PublicId;

                return Ok(photoForCreationDto.Url);
            }
            catch (Exception)
            {

            }

            return BadRequest();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Article article)
        {
            try
            {
                article.ArticleId = id;
                _articleService.Update(article);
                return Ok(article);
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
                _articleService.Delete(new Article { ArticleId = id });
                return Ok();
            }
            catch (Exception)
            {
                
            }
            return BadRequest();
        }





    }
}