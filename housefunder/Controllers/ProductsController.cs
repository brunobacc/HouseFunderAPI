using housefunder.Helper;
using housefunder.Models;
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

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Products value)
        {
            using (var db = new DbHelper())
            {
                db.products.Add(value);
                db.SaveChanges();
            }
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
