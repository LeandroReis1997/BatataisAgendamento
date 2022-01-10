using AutoMapper;
using BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO;
using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Info;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Api.Controllers
{
    [Route("webapi/schedulinghour")]
    [ApiController]
    public class SchedulingHourController : ControllerBase
    {
        private ISchedulingHourBll _bll;
        private readonly IMapper _mapper;

        public SchedulingHourController(IMapper mapper, ISchedulingHourBll schedulingHourBll)
        {
            _bll = schedulingHourBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<SchedulingHourListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<SchedulingHourListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> GetAllSchedulingHourAsync()
        {
            return Ok(_mapper.Map<List<SchedulingHourListDTO>>(await _bll.GetAllSchedulingHourAsync()));
        }

        [HttpGet]
        [Route("getbyschedulinghourid/{id}")]
        [Produces(typeof(SchedulingHourListDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(SchedulingHourListDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> GetBySchedulingHourIdAsync(int id)
        {
            if (await _bll.GetBySchedulingHourIdAsync(id) == null)
                return NotFound();

            return Ok(_mapper.Map<SchedulingHourListDTO>(await _bll.GetBySchedulingHourIdAsync(id)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<SchedulingHourCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(SchedulingHourCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddSchedulingHourAsync([FromBody] SchedulingHourCreateDTO schedulingCreateDTO)
        {
            return Ok(await _bll.AddSchedulingHourAsync(_mapper.Map<SchedulingHourInfo>(schedulingCreateDTO)));
        }

        [HttpPut]
        [Route("update/{id}")]
        [Produces(typeof(IEnumerable<SchedulingHourCreateDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(SchedulingHourCreateDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditSchedulingHourAsync(int id, [FromBody] SchedulingHourCreateDTO schedulingUpdateDTO)
        {
            if (schedulingUpdateDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<SchedulingHourUpdateDTO>(await _bll.EditSchedulingHourAsync(id, _mapper.Map<SchedulingHourInfo>(schedulingUpdateDTO))));
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
            SchedulingHourInfo agendamento = await _bll.GetBySchedulingHourIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            await _bll.DeleteSchedulingHourAsync(agendamento.Id);

            return new ObjectResult(_mapper.Map<SchedulingHourDeleteDTO>(agendamento));
        }
    }
}
