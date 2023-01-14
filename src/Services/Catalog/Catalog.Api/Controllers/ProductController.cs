using AutoMapper;
using Data.Entities.Catalog.Products;
using Dto.Catalog.Product;
using Microsoft.AspNetCore.Mvc;
using Repositery.Implemint.Generic;
using static Repositery.Interface.Generic.IMongoRepository;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoRepository<Product> _ProductRepository;
        private readonly IMapper mapper;

        public ProductController(MongoRepository<Product> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            this.mapper = mapper;
        }

        [HttpPost("registerPerson")]
        public async Task<IActionResult> AddPerson(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = mapper.Map<Product>(model);

            await _ProductRepository.InsertOneAsync(result);
            return Ok(result);
        }

        //[HttpGet("getPeopleData")]
        //public IEnumerable<string> GetPeopleData()
        //{
        //    var people = _ProductRepository.FilterBy(
        //        filter => filter.FirstName != "test",
        //        projection => projection.FirstName
        //    );
        //    return people;
        //}
    }
}
