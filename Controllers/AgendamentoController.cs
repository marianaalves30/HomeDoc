using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDoc.Models;
using HomeDoc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        ISchedulingService _schedulingService;

        public AgendamentoController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;

        }

        [HttpGet("lista")]
        [AllowAnonymous]
        [EnableCors("CorsPolicy")]
        [Produces("application/json")]
        public IActionResult Lista(int? idPacient)
        {
            try
            {
                var retorno = _schedulingService.GetScheduling(idPacient);
          
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(204, ex.Message);
            }
        }


        [HttpPost("cadastro")]
        [AllowAnonymous]
        [EnableCors("CorsPolicy")]
        [Produces("application/json")]
        public IActionResult Cadastro([FromBody] SchedulingRequest request)
        {
            try
            {
                var retorno = _schedulingService.AddScheduling(request);

                var response = new { Id = retorno };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(204, ex.Message);
            }
        }
    }
}