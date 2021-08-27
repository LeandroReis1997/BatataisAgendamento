using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll
{
    public class AgendamentoBll : IAgendamentoBll
    {
        private IAgendamentoDal _dal;

        public AgendamentoBll(IAgendamentoDal agendamentoDal)
        {
            _dal = agendamentoDal;
        }

        public async Task<AgendamentoInfo> AddScheduling(AgendamentoInfo scheduling)
        {
            return await _dal.AddSchedulingAsync(new AgendamentoInfo
            {
                Id = scheduling.Id,
                Dia = DateTime.Now.Date,
                Horario = DateTime.Now.ToString("HH:mm")
            });
        }

        public async Task<string> DeleteScheduling(string id)
        {
            return await _dal.DeleteScheduling(id);
        }

        public async Task<AgendamentoInfo> EditScheduling(string id, AgendamentoInfo scheduling)
        {
            return await _dal.EditSchedulingAsync(id, scheduling);
        }

        public List<AgendamentoInfo> GetAllScheduling()
        {
            return _dal.GetAllScheduling();
        }

        public AgendamentoInfo GetByScheduling(string id)
        {
            return _dal.GetBySchedulingId(id);
        }
    }
}
