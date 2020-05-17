using Domain.DTO.Plano;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    //[Authorize("Bearer")]
    [Route("api/[controller]")] // ele pega o nome do arquivo através do controllerbase
    [ApiController]
    public class PlanoController: ControllerBase
    {
        private IPlanoService _service;

        public PlanoController(IPlanoService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlanoCreateEditDTO model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try
            {
                var result = await _service.Post(model);
                if (result == null) return BadRequest();

                return Ok(result);
                //return Created(new Uri(Url.Link("GetWithId", new { id = result. })), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
