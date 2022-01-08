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
    [Route("webapi/schedulingday")]
    [ApiController]
    public class SchedulingDayController : ControllerBase
    {
        private ISchedulingDayBll _bll;
        private readonly IMapper _mapper;

        public SchedulingDayController(IMapper mapper, ISchedulingDayBll agendamentoBll)
        {
            _bll = agendamentoBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<SchedulingDayListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<SchedulingDayListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllScheduling()
        {
            return Ok(_mapper.Map<List<SchedulingDayListDTO>>(_bll.GetAllSchedulingDayAsync()));
        }

        [HttpGet]
        [Route("getbyschedulingdayid/{id}")]
        [Produces(typeof(SchedulingDayListDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingDayListDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetBySchedulingId(int id)
        {
            if (_bll.GetBySchedulingDayIdAsync(id) == null)
                return NotFound();

            return Ok(_mapper.Map<SchedulingDayListDTO>(_bll.GetBySchedulingDayIdAsync(id)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<SchedulingDayCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(SchedulingDayCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddScheduling([FromBody] SchedulingDayCreateDTO schedulingCreateDTO)
        {
            return Ok(await _bll.AddSchedulingDayAsync(_mapper.Map<SchedulingDayInfo>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{id}")]
        [Produces(typeof(IEnumerable<SchedulingDayCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(SchedulingDayCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditScheduling(int id, [FromBody] SchedulingDayCreateDTO schedulingUpdateDTO)
        {
            if (schedulingUpdateDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<SchedulingDayUpdateDTO>(await _bll.EditSchedulingDayAsync(id, _mapper.Map<SchedulingDayInfo>(schedulingUpdateDTO))));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Delete(int id)
        {
            SchedulingDayInfo agendamento = _bll.GetBySchedulingDayIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            await _bll.DeleteSchedulingDayAsync(agendamento.Id);

            return new ObjectResult(_mapper.Map<SchedulingDayDeleteDTO>(agendamento));
        }
    }
}
