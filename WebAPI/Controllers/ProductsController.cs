using Business.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Context c = new Context();//mvc için denedik
        IProductService _productService;//dependency injection
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //Metotlar için senkron asenkron çağırımlar
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallasync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productService.GetListAsync();
            await Task.Delay(3000);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        //[HttpGet("{Id}")]
        
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyidasync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            await Task.Delay(3000);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addbyasync")]
        public async Task<IActionResult> AddByAsync(Product product)
        {
            var result =await _productService.AddByAsync(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        

        [HttpDelete("deletebyasync")]
        public async Task<IActionResult> DeleteByAsync(Product product)
        {
            var result = await _productService.DeleteByAsync(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("updatebyasync")]
        public async Task<IActionResult> UpdateByAsync(Product product)
        {
            var result = await _productService.UpdateByAsync(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }




        //MVC İÇİN SİLME İŞLEMİ;
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await c.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            c.Products.Remove(product);
            await c.SaveChangesAsync();
            return NoContent();
        }

      

    }
}
