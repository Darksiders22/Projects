using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.CustomModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductManager manager;
        public ProductController(ProductManager productManager)
        {
            this.manager = productManager;
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            var all = manager.AllProducts;
            var res = JsonConvert.SerializeObject(all);
            return Ok(res);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            if (id != 0)
            {
                var product = manager.Get(id);
                if (product != null)
                {
                    var res = JsonConvert.SerializeObject(product);
                    return Ok(res);
                }

            }
            return NotFound();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct(ProductModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/products", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteProduct(int id)
        {
            if (id != 0)
            {
                var res = manager.Delete(id);

                if (id != 0)
                {
                    return BadRequest();
                }
            }
            return NoContent();
        }
    }
}
