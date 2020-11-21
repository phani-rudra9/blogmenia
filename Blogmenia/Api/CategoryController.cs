using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blogmenia.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly BlogmeniaDbContext _context;
        private readonly IRepositoryData repositoryData;

        public CategoryController(BlogmeniaDbContext context, IRepositoryData repositoryData)
        {
            _context = context;
            this.repositoryData = repositoryData;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            return repositoryData.GetAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            return repositoryData.GetCategories_ById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
