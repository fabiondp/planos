using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")] // ele pega o nome do arquivo através do controllerbase
    [ApiController]
    public class PessoasController: ControllerBase  {

        private IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }
      
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name ="GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try {
                return Ok(await _service.GetTask(id));
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDTO model){

            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try {
                var result = await _service.Post(model);
                if(result == null) return BadRequest();
                
                return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PessoaDTO model){
            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try {
                var result = await _service.Put(model);
                if(result == null) return BadRequest();
                
                return Ok(result);
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id){
            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados

            try {
                var result = await _service.Delete(id);
                if(!result) return BadRequest();
                
                return Ok(result);
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}