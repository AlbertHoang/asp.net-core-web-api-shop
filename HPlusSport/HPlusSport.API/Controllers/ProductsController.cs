using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        [HttpGet]
        //Instead of using ActionResult, we use Asynchronous Actions
        //public ActionResult GetAllProducts()
        //{
        //    return Ok(_context.Products.ToArray());
        //}
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _context.Products.ToArrayAsync()); //Using Entity Framework Core
        }

        [HttpGet("{id}")]
        //public ActionResult GetProduct(int id)
        //{
        //    var product = _context.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
