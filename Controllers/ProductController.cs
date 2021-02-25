using System.Collections.Generic;
using System.Threading.Tasks;
using EFTest.Models;
using EFTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFTest.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x=>x.Category).ToListAsync();
            return products;
        }
        
        //Recuperando pelo ID
        [HttpGet]
        [Route("{id:int}")] //restrição de rotas
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context,int id)
        {
            var product = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        //Recuperando pela categoria e pelo ID
        [HttpGet]
        [Route("categories/{id:int}")] //restrição de rotas
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context,int id)
        {
            var product = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return product;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
            {
                if (ModelState.IsValid){
                    context.Products.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }

                else{
                    return BadRequest(ModelState);
                }
            }
    }
}