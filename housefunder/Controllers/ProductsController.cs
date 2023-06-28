using housefunder.Helper;
using housefunder.Models;
using housefunder.Services;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {// GET: Products
        [HttpGet]
        public Products[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.products.ToArray();
            }
        }
        // GET api/<ProductsController>/5
        [HttpGet("{product_id}")]
        public Products Get(int product_id)
        {
            using (var db = new DbHelper())
            {
                if (db.products.Find(product_id) != null)
                {
                    return db.products.Find(product_id);
                }
                return null;
            }
        }

        private readonly IFileService _fileService;
        public ProductsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<bool> Post([FromForm] Files file, [FromForm] ProductsAdd product_add)
        {
            await _fileService.UploadProduct(file);
            Products product = new Products(product_add.title, product_add.description, product_add.price, file.image_file.FileName, product_add.value);
            using (var db = new DbHelper())
            {
                db.products.Add(product);
                db.SaveChanges();   
            }
            return true;
        }

        [HttpPost("{product_id}")]
        public async Task<IActionResult> UpdateProduct([FromForm] Files file, [FromForm] ProductsAdd product_add, int product_id)
        {
            await _fileService.UploadProduct(file);
            Products updatedProduct;
            using (var db = new DbHelper())
            {
                updatedProduct = db.products.Find(product_id);
                updatedProduct.title = product_add.title;
                updatedProduct.description = product_add.description;
                updatedProduct.price = product_add.price;
                updatedProduct.value = product_add.value;
                await _fileService.RemoveProduct(updatedProduct.image);
                updatedProduct.image = file.image_file.FileName;
                db.SaveChanges();
            }
            return Ok(file);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{product_id}")]
        public void Put(int product_id, [FromBody] Products value)
        {
            Products updateproducts;
            using (var db = new DbHelper())
            {
                if (db.products.Find(product_id) != null)
                {
                    updateproducts = db.products.Find(product_id);
                    updateproducts.title = value.title;
                    updateproducts.description = value.description;
                    updateproducts.price = value.price;
                    updateproducts.image = value.image;
                    updateproducts.value = value.value;
                    db.SaveChanges();
                }
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{product_id}")]
        public void Delete(int product_id)
        {
            Products product;
            using (var db = new DbHelper())
            {
                if (db.products.Find(product_id) != null)
                {
                    product = db.products.Find(product_id);
                    product.active = false;
                    db.SaveChanges();
                }
            }
        }
    }
}
