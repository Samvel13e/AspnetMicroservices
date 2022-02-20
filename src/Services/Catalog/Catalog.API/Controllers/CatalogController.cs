using Catalog.API.Entities;
using Catalog.API.Entities.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return products;    
        }
    }
}
