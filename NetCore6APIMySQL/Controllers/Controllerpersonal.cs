using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controllerpersonal : ControllerBase
    {
        private readonly rpersonal _personalrep;
        public Controllerpersonal(rpersonal personalrep)
        {
            _personalrep = personalrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersonal()
        {
            return Ok(await _personalrep.GetAllPersonal());
        }

        [HttpGet("{idpersonal}")]
        public async Task<IActionResult> GetDetails(int idpersonal)
        {
            return Ok(await _personalrep.GetDetails(idpersonal));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertPersonal([FromBody]personal personal)
        {
            if (personal == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personalrep.InsertPersonal(personal);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonal([FromBody] personal personal)
        {
            if (personal == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personalrep.UpdatePersonal(personal);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMensajes(int id)
        {
            await _personalrep.DeletePersonal(new personal {id = id });

            return NoContent();
        }

    }
}
