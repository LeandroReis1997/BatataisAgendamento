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
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> GetAllScheduling()
        {
            return Ok(_mapper.Map<List<AgendamentoListDTO>>(await _bll.GetAllSchedulingAsync()));
        }

        [HttpGet]
        [Route("getbyschedulingid/{id:length(24)}")]
        [Produces(typeof(AgendamentoListDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(AgendamentoListDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> GetBySchedulingId(string id)
        {
            if (_bll.GetBySchedulingAsync(id) == null)
                return NotFound();

            return Ok(_mapper.Map<AgendamentoListDTO>(await _bll.GetBySchedulingAsync(id)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<AgendamentoCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(AgendamentoCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddScheduling([FromBody] AgendamentoCreateDTO schedulingCreateDTO)
        {
            return Ok(await _bll.AddSchedulingAsync(_mapper.Map<AgendamentoInfo>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{id:length(24)}")]
        [Produces(typeof(IEnumerable<AgendamentoCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(AgendamentoCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditScheduling(string id, [FromBody] AgendamentoCreateDTO schedulingUpdateDTO)
        {
            if (schedulingUpdateDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<AgendamentoUpdateDTO>(await _bll.EditSchedulingAsync(id, _mapper.Map<AgendamentoInfo>(schedulingUpdateDTO))));
        }

        [HttpDelete("{id:length(24)}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Delete(string id)
        {
            AgendamentoInfo agendamento = await _bll.GetBySchedulingAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _bll.DeleteSchedulingAsync(agendamento.Id);

            return new ObjectResult(_mapper.Map<AgendamentoDeleteDTO>(agendamento));
        }
    }
}
