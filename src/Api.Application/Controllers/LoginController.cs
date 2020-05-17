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
    [Route("api/[controller]")] // ele pega o nome do arquivo através do controllerbase
    [ApiController]
    public class LoginController: ControllerBase
    {

        [HttpPost]
        // outra maneira de implementar a interface ILoginService, ao invés de utilizar construtor
        public async Task<object> Login([FromBody] LoginDTO entity, [FromServices] ILoginService service){
            if(!ModelState.IsValid) return BadRequest(ModelState); // validação dos parâmetros enviados
            
            if(entity == null) return BadRequest("Nenhuma entidade foi informada."); // validação dos parâmetros enviados

            try {
                var result = await service.FindByLogin(entity.Email, entity.Senha);
                if(result == null) return NoContent();

                return Ok(result);
            }
            catch (ArgumentException ex){
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        
    }
}