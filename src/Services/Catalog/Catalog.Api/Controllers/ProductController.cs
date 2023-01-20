using AutoMapper;
using Data.Entities.Catalog.Products;
using Dto.Catalog.Product;
using Microsoft.AspNetCore.Mvc;
using Repositery.Implemint.Generic;
using Repositery.Interface.Generic;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoRepository<Products> _ProductRepository;
        private readonly IMapper mapper;

        public ProductController(IMongoRepository<Products> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            this.mapper = mapper;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductDto model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var result = mapper.Map<Products>(model);

            await _ProductRepository.InsertOneAsync(result);
            return Ok(result);
        }

        //[HttpGet("getProductData")]
        //public IEnumerable<string> GetPeopleData()
        //{
        //    var people = _ProductRepository.FilterBy(
        //        filter => filter.Name != "test",
        //        projection => projection.FirstName
        //    );
        //    return people;
        //}

        [HttpGet("GetAllProductData")]
        public async Task<ActionResult> GetAllProductData()
        {
            var product = _ProductRepository.AsQueryable();
            return Ok(product);
        }
    }
}
