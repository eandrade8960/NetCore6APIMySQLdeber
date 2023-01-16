using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controllermensajes : ControllerBase
    {
        private readonly rmensajes _mensajesrep;
        public Controllermensajes(rmensajes mensajesrep)
        {
            _mensajesrep = mensajesrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMensajes()
        {
            return Ok(await _mensajesrep.GetAllMensajes());
        }

        [HttpGet("{idmensaje}")]
        public async Task<IActionResult> GetDetails(int idmensaje)
        {
            return Ok(await _mensajesrep.GetDetails(idmensaje));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertMensajes([FromBody]mensajes mensajes)
        {
            if (mensajes == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _mensajesrep.InsertMensajes(mensajes);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMensajes([FromBody] mensajes mensajes)
        {
            if (mensajes == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mensajesrep.UpdateMensajes(mensajes);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMensajes(int id)
        {
            await _mensajesrep.DeleteMensajes(new mensajes {id = id });

            return NoContent();
        }

    }
}
