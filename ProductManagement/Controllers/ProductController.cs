using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Context;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext dbContext;

        public ProductController(ProductContext context)
        {
            this.dbContext = context?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> get()
        {
            var product = await this.dbContext.Products.ToListAsync();
            return Ok(product);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> get(int id)
        {
            try
            {
                var product = await this.dbContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> addProduct(Product product)
        {
            try
            {
                await this.dbContext.Products.AddAsync(product);

                await this.dbContext.SaveChangesAsync();

                var products = await this.dbContext.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} Inner Exception: {ex?.InnerException}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> updateProduct(Product productUpdate)
        {
            try
            {
                var product = dbContext.Products.Find(productUpdate.Id);

                if (product == null)
                {
                    return NotFound();
                }

                product.Description = productUpdate.Description;
                product.Name = productUpdate.Name;
                product.Price = productUpdate.Price;

                await dbContext.SaveChangesAsync();

                var products = await this.dbContext.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> deleteProduct(int id)
        {

            try
            {
                var product = await this.dbContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                dbContext.Products.Remove(product);
                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
