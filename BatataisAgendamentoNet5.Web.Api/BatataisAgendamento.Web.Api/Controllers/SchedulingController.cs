using AutoMapper;
using BatataisAgendamento.Web.Api.DTO;
using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Info;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Api.Controllers
{
    [Route("webapi/agendamento")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private IAgendamentoBll _bll;
        private readonly IMapper _mapper;

        public SchedulingController(IMapper mapper, IAgendamentoBll agendamentoBll)
        {
            _bll = agendamentoBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<AgendamentoListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<AgendamentoListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(AgendamentoListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllScheduling()
        {
            return Ok(_mapper.Map<List<AgendamentoListDTO>>(_bll.GetAllScheduling()));
        }

        [HttpGet]
        [Route("getbyschedulingid/{id}")]
        [Produces(typeof(AgendamentoListDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(AgendamentoListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetBySchedulingId(string id)
        {
            if (_bll.GetByScheduling(id) == null)
                return NotFound();

            return Ok(_mapper.Map<AgendamentoListDTO>(_bll.GetByScheduling(id)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<AgendamentoDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(AgendamentoDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddScheduling([FromBody] AgendamentoDTO schedulingCreateDTO)
        {
            return Ok(await _bll.AddScheduling(_mapper.Map<AgendamentoInfo>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{schedulingid}")]
        [Produces(typeof(IEnumerable<AgendamentoDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(AgendamentoDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditScheduling(string id, [FromBody] AgendamentoDTO schedulingUpdateDTO)
        {
            if (schedulingUpdateDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<AgendamentoListDTO>(await _bll.EditScheduling(id, _mapper.Map<AgendamentoInfo>(schedulingUpdateDTO))));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(string id)
        {
            if (_bll.GetByScheduling(id) == null)
                return NotFound();

            _bll.DeleteScheduling(id);
            return NoContent();
        }
    }
}
