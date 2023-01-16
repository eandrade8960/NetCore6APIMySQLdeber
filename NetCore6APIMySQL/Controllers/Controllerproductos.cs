﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly rproductos _productosrep;
        public productosController(rproductos productosrep)
        {
            _productosrep = productosrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _productosrep.GetAllProductos());
        }

        [HttpGet("{idproducto}")]
        public async Task<IActionResult> GetDetails(int idproducto)
        {
            return Ok(await _productosrep.GetDetails(idproducto));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertProductos([FromBody]productos productos)
        {
            if (productos == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productosrep.InsertProductos(productos);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductos([FromBody] productos productos)
        {
            if (productos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productosrep.UpdateProductos(productos);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            await _productosrep.DeleteProductos(new productos {id = id });

            return NoContent();
        }

    }
}
