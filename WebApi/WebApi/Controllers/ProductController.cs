using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProductController(ApiContext context) 
        {
            _context = context;
        }

        //Create 
        [HttpPost]
        public JsonResult CreateClothing(Clothing productdto)
        {
            Product product = new Clothing();

            var productID = _context.Products.Find(productdto.Id);

            if (productID != null)
            {
                return new JsonResult(BadRequest());
            }

            product.Id = productdto.Id;
            product.Name = productdto.Name;
            product.Price = productdto.Price;
            product.Description = productdto.Description;

            if (product is Clothing clothing)
            {
                product.Type = ProductType.Clothing;
                clothing.Lenght = ((Clothing)productdto).Lenght;
                clothing.Diameter = ((Clothing)productdto).Diameter;
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return new JsonResult(Ok(product));
        }

        //Create 
        [HttpPost]
        public JsonResult CreateShoes(Shoes productdto)
        {
            Product product = new Shoes();

            var productID = _context.Products.Find(productdto.Id);

            if (productID != null)
            {
                return new JsonResult(BadRequest());
            }

            product.Id = productdto.Id;
            product.Name = productdto.Name;
            product.Price = productdto.Price;
            product.Description = productdto.Description;

            if (product is Shoes shoes)
            {
                product.Type = ProductType.Shoes;
                shoes.Brand = ((Shoes)productdto).Brand;
                shoes.Size = ((Shoes)productdto).Size;
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return new JsonResult(Ok(product));
        }

        //Edit
        [HttpPut("{id}")]
        public  JsonResult EditClothing(int id, Clothing product)
        {
            var productInDb = _context.Products.Find(id);

            if (productInDb == null)
            {
                return new JsonResult(NotFound());
            }

            if(product.Type != ProductType.Clothing)
            {
                return new JsonResult(NotFound(product.Type));
            }

            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Description = product.Description;

            if (productInDb is Clothing clothing)
            {
                clothing.Lenght = ((Clothing)product).Lenght;
                clothing.Diameter = ((Clothing)product).Diameter;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(productInDb));
        }

        //Edit
        [HttpPut("{id}")]
        public JsonResult EditShoes(int id, Shoes product)
        {
            var productInDb = _context.Products.Find(id);

            if (productInDb == null)
            {
                return new JsonResult(NotFound());
            }

            if (product.Type != ProductType.Shoes)
            {
                return new JsonResult(NotFound(product.Type));
            }

            productInDb.Id = id;
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Description = product.Description;

            if (productInDb is Shoes shoes)
            {
                shoes.Brand = ((Shoes)product).Brand;
                shoes.Size = ((Shoes)product).Size;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(productInDb));
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Products.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Products.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            _context.Products.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get all
        [HttpGet()]
        public JsonResult GetAll() 
        {
            var result = _context.Products.ToList();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };

            var serializedProducts = JsonConvert.SerializeObject(result, settings);

            return new JsonResult(Ok(result));
        }
    }
}
